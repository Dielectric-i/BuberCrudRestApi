using Buber.Models;

namespace Buber.Services.Breakfasts
{
    public interface IBreakfastService
    {

        void CreateBreakfast(Breakfast breakfast);
        void DeleteBreakfast(Guid id);
        Breakfast GetBreakfast(Guid id);
        void UpsertBreakfast(Breakfast breakfast);
        //void GetBreakfast(Guid id);
        //BreakfastResponse UpdateBreakfast(Guid id, UpsertBreakfastRequest request);
        //BreakfastResponse DeleteBreakfast(Guid id);
    }
}
