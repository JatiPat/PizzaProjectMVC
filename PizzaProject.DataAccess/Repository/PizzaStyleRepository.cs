using PizzaProject.DataAccess.Data;
using PizzaProject.DataAccess.Repository.IRepository;
using PizzaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.DataAccess.Repository
{
    public class PizzaStyleRepository : Repository<PizzaStyle>, IPizzaStyleRepository
    {
        private PizzaDbContext _dbContext;
        public PizzaStyleRepository(PizzaDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
 

        public void Update(PizzaStyle pizzaStyle)
        {
           _dbContext.PizzaStyles.Update(pizzaStyle);

        }
    }
}
