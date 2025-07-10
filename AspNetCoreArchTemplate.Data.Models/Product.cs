using AspNetCoreArchTemplate.GCommon.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AspNetCoreArchTemplate.Data.Models
{
    [Comment("Product")]
    public class Product
    {
        [Comment("Product ID")]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 150,ErrorMessage = "Calories must be more then 1 and less then 150")]
        public int Calories { get; set; }

        public int? Proteins { get; set; }

        public int Vitamins {  get; set; }

    }
}
