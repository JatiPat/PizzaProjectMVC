using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Models.ViewModels
{
    public class PizzaVM //VM for ViewModel
    {
        public Pizza Pizza { get; set; }
        [ValidateNever] //Makes it so it doesn't get valided if it's null during ModelState.IsValid
        public IEnumerable<SelectListItem> PizzaStyleList { get; set; }
    }
}
