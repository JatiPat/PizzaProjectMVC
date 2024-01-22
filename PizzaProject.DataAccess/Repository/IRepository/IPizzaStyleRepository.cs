using PizzaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.DataAccess.Repository.IRepository
{
    public interface IPizzaStyleRepository : IRepository<PizzaStyle>
    {
        void Update(PizzaStyle pizzaStyle);
     
    }
}
