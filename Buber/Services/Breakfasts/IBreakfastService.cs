using Buber.Models;
using ErrorOr;

namespace Buber.Services.Breakfasts
{
    public interface IBreakfastService
    {

        ErrorOr<Created>CreateBreakfast(Breakfast breakfast);
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        ErrorOr<Deleted>DeleteBreakfast(Guid id);
        ErrorOr<UpsertedBreakfast>UpsertBreakfast(Breakfast breakfast);
    }
}
