using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Models.ViewModel
{
    public class NewProductVM
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Product Image URL")]
        [Required(ErrorMessage = "Price is required")]

        public string ImageURL { get; set; }

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Price is required")]
        public string BrandName { get; set; }

        [Display(Name = "Capacity")]
        [Required(ErrorMessage = "Capacity is required")]
        public string Capacity { get; set; }



        //Relationships
        [Display(Name = "Select dealer(s)")]
        [Required(ErrorMessage = "Dealer(s) is required")]
        public List<int> DealerIds { get; set; }

    }
}


