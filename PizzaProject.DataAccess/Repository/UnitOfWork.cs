using PizzaProject.DataAccess.Data;
using PizzaProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private PizzaDbContext _dbContext;
        public IPizzaStyleRepository Style { get; private set; }
        public IPizzaRepository Pizza { get; private set; }
        public UnitOfWork(PizzaDbContext dbContext) 
        {
            _dbContext = dbContext;
            Style = new PizzaStyleRepository(_dbContext);
            Pizza = new PizzaRepository(_dbContext);
        }

       
        public void Save()
        {
            _dbContext.SaveChanges();   
        }
    }
}
