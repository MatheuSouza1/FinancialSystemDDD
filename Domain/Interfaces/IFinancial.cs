using Domain.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFinancial : InterfaceGeneric<Financial>
    {
        Task<List<Financial>> GetAllFinancialSystemsFromUser(string email);
    }
}
