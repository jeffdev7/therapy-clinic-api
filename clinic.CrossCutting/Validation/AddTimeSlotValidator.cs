using clinic.CrossCutting.Dto;
using clinic.domain.Repository.Interfaces;
using FluentValidation;

namespace clinic.CrossCutting.Validation
{
    public class AddTimeSlotValidator : AbstractValidator<TimeSlotViewModel>
    {
        public AddTimeSlotValidator()
        {
            RuleFor(_ => _.Start)
                .Must(IsValidDate)
                .WithMessage("It's not a valid date.");

            RuleFor(_ => _.End)
                .Must(IsValidDate)
                .WithMessage("It's not a valid date.");

            RuleFor(dt => dt)  
                .Must(dt => dt.End > dt.Start && (dt.End - dt.Start).TotalMinutes >= 30)
                .WithMessage("It's not a valid time.");
        }

        private static bool IsValidDate(DateTime date)
        {
            if (date.Date >= DateTime.Today)
                return true;
            return false;
        }
    }
}
