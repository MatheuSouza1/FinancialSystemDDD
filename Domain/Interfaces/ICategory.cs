using Domain.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategory : InterfaceGeneric<Category>
    {
        Task<List<Category>> GetAllCategoriesFromUser(string email);
    }
}
