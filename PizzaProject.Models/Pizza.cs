using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PizzaProject.Models
{
    public class Pizza
    {
       
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Pizza Name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Ingredients { get; set; }

        //public int Calories { get; set; }

        [Required]
        [Range(0, 100)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Pizza Style")]
        public int PizzaStyleId { get; set; }
        [ForeignKey("PizzaStyleId")]
        [ValidateNever]
        public PizzaStyle PizzaStyle { get; set; }
        [ValidateNever] //Makes it so it doesn't get valided if it's null during ModelState.IsValid
        public string ImageURL { get; set; }
        
        [DisplayName("Vegetarian")]
        public string Veggie {  get; set; }  

    }


        
    
}
