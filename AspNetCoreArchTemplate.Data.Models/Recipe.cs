using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreArchTemplate.Data.Models
{
    [Comment("User-created recipe")]
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid CreatedByUserId { get; set; }

        public bool IsPublic { get; set; } = false;

        public bool IsApprovedByAdmin { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public ICollection<RecipeProduct> RecipeProducts { get; set; } = new List<RecipeProduct>();
    }
}
