using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Seeding.Dtos
{
    public static class RoleData
    {
        public static List<string> GetRoles() => new()
        {
            "Administrator",
            "User"
        };
    }
}
