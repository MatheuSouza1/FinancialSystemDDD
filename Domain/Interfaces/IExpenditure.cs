using Domain.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExpenditure : InterfaceGeneric<Expenditure>
    {
        Task<List<Expenditure>> GetAllExpenditure(string email);
        Task<List<Expenditure>> GetAllPastDueExpenditure(string email);
    }
}
