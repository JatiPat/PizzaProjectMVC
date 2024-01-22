using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPizzaStyleRepository Style { get; }
        IPizzaRepository Pizza { get; }

        void Save();

    }
}
