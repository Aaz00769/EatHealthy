using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatHealthy.Web.ViewModels.Day
{
    public class DayFormInputModel
    {
        [Required]
        public DateTime Date { get; set; }

        [StringLength(1000)]
        public string? Note { get; set; }

        public List<Guid> SelectedMealIds { get; set; } = new();
        public Guid Id { get; set; }
    }
}
