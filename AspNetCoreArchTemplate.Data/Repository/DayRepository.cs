using AspNetCoreArchTemplate.Data.Repository.Interfaces;
using EatHealthy.Data;
using EatHealthy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Repository
{
    public class DayRepository : BaseRepository<Day, Guid>, IDayRepository
    {
        public DayRepository(EatHealthyDbContext context) : base(context)
        {

        }
    }
}
