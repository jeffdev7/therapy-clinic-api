using clinic.CrossCutting.Dto;
using clinic.domain.Repository.Interfaces;
using FluentValidation;

namespace clinic.CrossCutting.Validation
{
    public class AddAppointmentValidator : AbstractValidator<AppointmentRequestViewModel>
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        public AddAppointmentValidator(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;

            RuleFor(_ => _.RequestedTime)
                .Must(UniqueSlot)
                .WithMessage("This date is already booked.");

            RuleFor(_ => _.Phone.Number)
                .Matches("^\\(?[1-9]{2}\\)? ?(?:[2-8]|9[1-9])[0-9]{3,4}[- ]?[0-9]{4}$")
                .WithMessage("Wrong format.");
        }

        private bool UniqueSlot(NewAppointmentTimeSlotViewModel appointment)
        {
            var timeSlots = _timeSlotRepository.GetAll().ToList();

            foreach (var timeSlot in timeSlots)
            {
                if (timeSlot.Start == appointment.Start
                   && timeSlot.End == appointment.End
                   && timeSlot.IsBooked is false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
