using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.CrossCutting.Validation;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class AppointmentRequestServices : IAppointmentRequestServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRequestRepository _appointmentRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly ApplicationContext _context;

        public AppointmentRequestServices(IMapper mapper, IAppointmentRequestRepository appointmentRepository,
            ITimeSlotRepository timeSlotRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task<ErrorOr<AppointmentRequestViewModel>> Add(AppointmentRequestViewModel vm)
        {
            List<Error> validationErrors = new List<Error>();
            var timeSlot = _timeSlotRepository.GetAll()
                .SingleOrDefault(_ => _.Start == vm.RequestedTime.Start
            && _.End == vm.RequestedTime.End
            && _.IsBooked == false);

            AppointmentRequest termine = _mapper.Map<AppointmentRequest>(vm);

            var result = new AddAppointmentValidator(_timeSlotRepository).Validate(vm);

            if (!result.IsValid)
            {
                validationErrors = result.Errors.Select(_ => Error.Validation(_.PropertyName, _.ErrorMessage)).ToList();

                return ErrorOr<AppointmentRequestViewModel>.From(validationErrors);
            }

            timeSlot!.IsBooked = true;
            _context.Entry(timeSlot).State = EntityState.Modified;
            _timeSlotRepository.Update(timeSlot);

            termine.RequestedTime = timeSlot;
            _context.RequestedAppointments.Add(termine);

            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentRequestViewModel>(termine);

            //foreach (var timeSlot in timeSlots)
            //{
            //    if (timeSlot.Start == termine.RequestedTime.Start
            //        && timeSlot.End == termine.RequestedTime.End
            //        && timeSlot.IsBooked is false)
            //    {
            //        timeSlot.IsBooked = true;
            //        _context.Entry(timeSlot).State = EntityState.Modified;
            //        _timeSlotRepository.Update(timeSlot);

            //        termine.RequestedTime = timeSlot;
            //        _context.RequestedAppointments.Add(termine);

            //        await _context.SaveChangesAsync();
            //        return _mapper.Map<AppointmentRequestViewModel>(termine);
            //    }
            //}

        }

        public IEnumerable<GetAppointmentRequestViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<GetAppointmentRequestViewModel>>(_appointmentRepository
                .GetAll()
                .Include(_ => _.RequestedTime)
                .OrderBy(_ => _.RequestedTime.IsBooked));
        }

        public async Task<bool> Remove(Guid id)
        {
            AppointmentRequest termine = await _context.RequestedAppointments
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (termine == null)
                return false;
            _context.RequestedAppointments.Remove(termine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AppointmentRequestViewModel> Update(AppointmentRequestViewModel vm)
        {
            AppointmentRequest termine = _mapper.Map<AppointmentRequest>(vm);
            _context.RequestedAppointments.Update(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentRequestViewModel>(termine);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}