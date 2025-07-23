using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace EatHealthy.Services.Core
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IDayRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IEnumerable<MealViewModel>> GetAllAsync(Guid userId)
        {
            var days = await _mealRepository
                .AllAsNoTracking()
                .Where(d => d.CreatedByUserId == userId)
                .Select(d => new MealViewModel
                {
                    Id = d.Id,
                    Date = d.Date,
                    Note = d.Note,
                    IsCompleted = d.IsCompleted
                })
                .ToListAsync();

            return days;
        }

        public async Task<MealFormInputModel?> GetByIdAsync(Guid id)
        {
            var day = await _mealRepository.GetByIdAsync(id);
            if (day == null) return null;

            return new MealFormInputModel
            {
                Id = day.Id,
                Date = day.Date,
                Note = day.Note,
            };
        }

        public async Task AddAsync(MealFormInputModel model, Guid userId)
        {
            var day = new Meal
            {
                Date = model.Date,
                Note = model.Note,
                CreatedByUserId = userId
            };

            await _mealRepository.AddAsync(day);
            await _mealRepository.SaveChangesAsync();
        }

        public async Task EditAsync(Guid id, MealFormInputModel model)
        {
            var day = await _mealRepository.GetByIdAsync(id);
            if (day == null) return;

            day.Date = model.Date;
            day.Note = model.Note;

            await _mealRepository.UpdateAsync(day);
            await _mealRepository.SaveChangesAsync();
        }

        public async Task<bool> MarkAsCompletedAsync(Guid id)
        {
            var day = await _mealRepository.GetByIdAsync(id);
            if (day == null) return false;

            day.IsCompleted = true;
            await _mealRepository.SaveChangesAsync();
            return true;
        }
    }
}
*/