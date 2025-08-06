using clinic.CrossCutting.Dto;
using clinic.domain.Repository.Interfaces;
using FluentValidation;

namespace clinic.CrossCutting.Validation
{
    public class AddTimeSlotValidator : AbstractValidator<TimeSlotViewModel>
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        public AddTimeSlotValidator(ITimeSlotRepository timeSlotRepository, string userId)
        {
            _timeSlotRepository = timeSlotRepository;

            RuleFor(_ => _.Start)
                .Must(IsValidDate)
                .WithMessage("It's not a valid date.");

            RuleFor(_ => _.End)
                .Must(IsValidDate)
                .WithMessage("It's not a valid date.");

            RuleFor(dt => dt)
                .Must(dt => dt.End > dt.Start && (dt.End - dt.Start).TotalMinutes >= 30)
                .WithMessage("It's not a valid time.");

            RuleFor(dt => dt)
                .Must(dt => DoesTimeAlreadyExist(dt.Start, dt.End, userId))
                .WithMessage("There is already a timeslot with this time.");
        }

        private static bool IsValidDate(DateTime date)
        {
            if (date.Date >= DateTime.Today)
                return true;
            return false;
        }
        private bool DoesTimeAlreadyExist(DateTime startTime, DateTime endTime, string userId)
        {
            var startDt = DateTime.SpecifyKind(startTime, DateTimeKind.Utc);
            var endDt = DateTime.SpecifyKind(endTime, DateTimeKind.Utc);

            var dates = _timeSlotRepository.GetStartAndEndTime(startDt, endDt, userId);

            if (dates.T1.Any() && dates.T2.Any() || dates.T1.Any())
                return false;
            return true;

        }
    }
}
