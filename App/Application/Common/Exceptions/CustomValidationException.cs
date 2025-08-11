using FluentValidation;

namespace Application.Common.Exceptions
{
    public class CustomValidationException : ValidationException
    {
        public CustomValidationException() : base("One or more validation failures have occurred.")
        {
        }
    }
}

