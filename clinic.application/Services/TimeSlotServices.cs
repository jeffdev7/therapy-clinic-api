﻿using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class TimeSlotServices : ITimeSlotServices
    {
        private readonly IMapper _mapper;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly ApplicationContext _context;

        public TimeSlotServices(IMapper mapper, ITimeSlotRepository timeSlotRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _timeSlotRepository = timeSlotRepository;
            _context = context;
        }

        public async Task<TimeSlotViewModel> AddTimeSlot(TimeSlotViewModel vm)
        {
            TimeSlot termine = _mapper.Map<TimeSlot>(vm);
            _context.TimeSlots.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<TimeSlotViewModel>(termine);
        }

        public IEnumerable<TimeSlotViewModel> GetTimeSlot()
        {
            return _mapper.Map<IEnumerable<TimeSlotViewModel>>(_timeSlotRepository.GetAll());
        }
        public async Task<TimeSlotViewModel> Update(TimeSlotViewModel vm)
        {
            TimeSlot termine = _mapper.Map<TimeSlot>(vm);
            _context.TimeSlots.Update(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<TimeSlotViewModel>(termine);
        }


        public IEnumerable<TimeSlotViewModel> GetAvailableTimeSlots()
        {
            var availableSlots = _timeSlotRepository.GetAll().Where(_ => _.IsBooked == false);
            return _mapper.Map<IEnumerable<TimeSlotViewModel>>(availableSlots);
        }

        public IQueryable<TimeSlotViewModel> GetAll()
        {
            return _timeSlotRepository.GetAll()
                 .Select(_ => new TimeSlotViewModel
                 {
                     Id = _.Id,
                     Start = _.Start,
                     End = _.End,
                     IsBooked = _.IsBooked
                 }).OrderByDescending(_ => _.IsBooked == false);
        }
        public async Task<bool> Remove(Guid id)
        {
            TimeSlot timeSlot = await _context.TimeSlots
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (timeSlot == null)
                return false;
            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
            return true;
        }
        public TimeSlotViewModel GetById(Guid id)
        {
            var timeSlot = _timeSlotRepository.GetById(id);
            return _mapper.Map<TimeSlotViewModel>(timeSlot);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}