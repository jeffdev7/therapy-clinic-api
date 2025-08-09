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
                .WithMessage("Insira uma data válida.");

            RuleFor(_ => _)
             .Must(_ => DefaultBeginStartTimeExist(_.Start, userId))
             .WithMessage("Hora inicial pode colidir com outro agendamento.");

            RuleFor(_ => _.End)
                .Must(IsValidDate)
                .WithMessage("Insira uma data válida.");

            RuleFor(dt => dt)
                .Must(dt => dt.End > dt.Start && (dt.End - dt.Start).TotalMinutes >= 30)
                .WithMessage("Insira uma hora válida.");

            RuleFor(dt => dt)
                .Must(dt => DoesTimeAlreadyExist(dt.Start, dt.End, userId))
                .WithMessage("Já existe um horário criado com esta hora.");
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

            if (dates.T1.Any() && dates.T2.Any() || dates.T1.Any() || dates.T2.Any())
                return false;
            return true;

        }
        private bool DefaultBeginStartTimeExist(DateTime startTime, string userId)
        {
            var startDt = DateTime.SpecifyKind(startTime, DateTimeKind.Utc);
            var result = _timeSlotRepository.GetStartTimeRange(userId);

            foreach (var date in result)
            {
                if (date.Date == startDt.Date
                    && date.Hour == startDt.Hour
                    && (startDt.AddMinutes(30) - date).TotalMinutes <= 59)
                    return false;
            }
            
            return true;

        }
    }
}
