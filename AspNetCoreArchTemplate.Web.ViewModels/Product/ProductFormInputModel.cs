using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EatHealthy.Web.ViewModels.ValidationMessages.Product;
using static EatHealthy.Data.Common.EntityConsts.Product;
namespace EatHealthy.Web.ViewModels.Product
{
    public class ProductFormInputModel
    {
        public Guid ProductId { get; set; } 
        [Required(ErrorMessage = NameRequired)]
        [MinLength(NameMinLength,ErrorMessage =(NameLength))]
        [MaxLength(NameMaxLength, ErrorMessage = NameLength)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = CaloriesRequired)]
        [Range(CaloriesMin, CaloriesMax, ErrorMessage = CaloriesRange)]
        public int Calories { get; set; }

        [Range(ProteinsMin, ProteinsMax, ErrorMessage = ProteinsRange)]
        public int? Proteins {  get; set; }
  
        [Range(FatsMin, FatsMax, ErrorMessage = FatsRange)]
        public int? Fats {  get; set; }

        [Range(CarbohydratesMin, CarbohydratesMax, ErrorMessage = CarbohydratesRange)]
        public int? Carbohydrates { get; set; }

    }
}
