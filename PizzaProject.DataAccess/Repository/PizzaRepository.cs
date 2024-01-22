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
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        private PizzaDbContext _dbContext;
        public PizzaRepository(PizzaDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
 

        public void Update(Pizza pizza)
        {
           _dbContext.Pizzas.Update(pizza);

        }
    }
}
