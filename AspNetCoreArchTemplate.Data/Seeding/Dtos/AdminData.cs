using AspNetCoreArchTemplate.Data.Seeding.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Seeding.Dtos
{
    public static class AdminData
    {
        public static AdminInputDto GetAdminInput() => new()
        {
            Email = "admin@example.com",
            Password = "Admin123!"
        };
    }
}
