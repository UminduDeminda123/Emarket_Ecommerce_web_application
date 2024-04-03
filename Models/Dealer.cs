using eTickets.Data.Base;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Models
{
    public class Dealer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is requierd")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is requierd")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Area is requierd")]
        public string Area { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is requierd")]
        public string Bio { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is requierd")]
        public string PhoneNumber { get; set; }
        
        public List<Dealer_Product> Dealers_Products { get; set; }
    }
}
