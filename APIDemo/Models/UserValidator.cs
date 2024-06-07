using FluentValidation;

namespace APIDemo.Models
{
    public class UserValidator:AbstractValidator<UserModel> 
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Enter name");
            RuleFor(u => u.Contact)
                .NotEmpty().WithMessage("Enter Contact");
            RuleFor(u => u.Email)
                .NotEmpty().EmailAddress().WithMessage("Enter Email");
            RuleFor(u => u.EventDate)
                .NotEmpty().WithMessage("Enter Event Date")
                .Must(BeValidEventDate).WithMessage("Event Date must be in the future");

        }
        private bool BeValidEventDate(DateTime date)
        {
            
            if (date <= DateTime.Now)
                return false;

            
            if (date > DateTime.Now.AddDays(30))
                return false;

            
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return false;

            if (date.Year != DateTime.Now.Year || date.Month != DateTime.Now.AddMonths(1).Month)
                return false;

            return true;
        }
    }

}
        