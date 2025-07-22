

namespace AspNetCoreArchTemplate.Data.Repository
{
    using AspNetCoreArchTemplate.Data.Repository.Interfaces;
    using EatHealthy.Data;
    using EatHealthy.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(EatHealthyDbContext context) 
            : base(context)
        {
        }
    }
}
