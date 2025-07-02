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
