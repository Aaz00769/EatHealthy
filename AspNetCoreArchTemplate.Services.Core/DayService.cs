using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace EatHealthy.Services.Core
{
    public class DayService : IDayService
    {
        private readonly IDayRepository _dayRepository;

        public DayService(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public async Task<IEnumerable<DayViewModel>> GetAllAsync(Guid userId)
        {
            var days = await _dayRepository
                .AllAsNoTracking()
                .Where(d => d.CreatedByUserId == userId)
                .Select(d => new DayViewModel
                {
                    Id = d.Id,
                    Date = d.Date,
                    Note = d.Note,
                    IsCompleted = d.IsCompleted
                })
                .ToListAsync();

            return days;
        }

        public async Task<DayFormInputModel?> GetByIdAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null) return null;

            return new DayFormInputModel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
            };
        }

        public async Task AddAsync(DayFormInputModel model, Guid userId)
        {
            var day = new Day
            {
                Date = model.Date,
                Note = model.Note,
                CreatedByUserId = userId
            };

            await _dayRepository.AddAsync(day);
            await _dayRepository.SaveChangesAsync();
        }

        public async Task EditAsync(Guid id, DayFormInputModel model)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null) return;

            day.Date = model.Date;
            day.Note = model.Note;

            await _dayRepository.UpdateAsync(day);
            await _dayRepository.SaveChangesAsync();
        }

        public async Task<bool> MarkAsCompletedAsync(Guid id)
        {
            var day = await _dayRepository.GetByIdAsync(id);
            if (day == null) return false;

            day.IsCompleted = true;
            await _dayRepository.SaveChangesAsync();
            return true;
        }
    }

}
*/