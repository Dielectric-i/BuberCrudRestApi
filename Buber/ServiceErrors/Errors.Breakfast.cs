using ErrorOr;

namespace Buber.ServiceErrors
{
    public static class Errors
    {
        public static class Breakfast
        {
            public static Error NotFound => Error.NotFound(
                code: "Breakfast.NotFound",
                description: "Breakfast not found"
                );
            public static Error InvalidName => Error.Validation(
                code: "Breakfast.InvalidName",
                description: $"Breakfast name must be at least {Models.Breakfast.MinNameLenght} " +
                $"charaster long and most {Models.Breakfast.MaxNameLenght} charaster long"
                );
            public static Error InvalidDescription => Error.Validation(
                code: "Breakfast.Description",
                description: $"Breakfast description must be at least {Models.Breakfast.MinDescriptionLenght} " +
                $"charaster long and most {Models.Breakfast.MaxDescriptionLenght} charaster long"
                );
        }
    }
}
