using Domain.Interfaces.Generic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFinancialUser : InterfaceGeneric<FinancialUser>
    {
        Task<List<FinancialUser>> ListAllFinancialUserFromSystem(int id); //This method list all users from a specific system
        Task RemoveUser(List<FinancialUser> financialUsers);

        Task<FinancialUser> GetUserByEmail(string email);
    }
}
