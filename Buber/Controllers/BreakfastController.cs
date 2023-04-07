using Buber.Contracts.Breakfast;
using Buber.Models;
using Buber.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Buber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastController : ApiController
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(request);

            if (requestToBreakfastResult.IsError)
            {
                return Problem(requestToBreakfastResult.Errors);
            }

            var breakfast = requestToBreakfastResult.Value;
            
            ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

            return createBreakfastResult.Match(
                created => CreatedAtGetBreakfast(breakfast),
                error => Problem(error));
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(
                breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors));

            //if (getBreakfastResult.IsError &&
            //    getBreakfastResult.FirstError == Errors.Breakfast.NotFound)
            //{
            //    return NotFound();
            //}

            //var breakfast = getBreakfastResult.Value;

            //BreakfastResponse response = MapBrealfastResponse(breakfast);

            //return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {

            //ErrorOr<Breakfast> requestToBreakfastResult = new Breakfast.Create(
            //    request.Name,
            //    request.Description,
            //    request.StartDateTime,
            //    request.EndDateTime,
            //    request.Savory,
            //    request.Sweet,
            //    id);
            //if (requestToBreakfastResult.IsError)
            //{
            //    return Problem(requestToBreakfastResult.Errors);
            //}
            //var breakfast = requestToBreakfastResult.Value;



            ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.Create(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet,
                id);

                if (requestToBreakfastResult.IsError)
                {
                    return Problem(requestToBreakfastResult.Errors);
                }
                var breakfast = requestToBreakfastResult.Value;

            ErrorOr<UpsertedBreakfast> upsertedBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);
             
            // TODO return 201 if a new breakfast was created

            return upsertedBreakfastResult.Match(
                upserted => upserted.isNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
                errors => Problem(errors));
        }
        
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {

            ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

            return deleteBreakfastResult.Match(
                deleted => NoContent(),
                errors => Problem(errors)
                );
        }

        private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        {
            return new BreakfastResponse(
                            breakfast.Id,
                            breakfast.Name,
                            breakfast.Description,
                            breakfast.StartDateTime,
                            breakfast.EndDateTime,
                            breakfast.LastModifiedDataTime,
                            breakfast.Savory,
                            breakfast.Sweet);
        }
        
        private IActionResult CreatedAtGetBreakfast(Breakfast breakfast)
        {
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: MapBreakfastResponse(breakfast));
        }
    }
}
