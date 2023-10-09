using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FinancialUserService : IFinancialUserService
    {
        private readonly IFinancialUser _IfinancialUser;

        public FinancialUserService(IFinancialUser ifinancialUser)
        {
            _IfinancialUser = ifinancialUser;
        }

        public async Task RegisterUser(FinancialUser financialUser)
        {
            await _IfinancialUser.Add(financialUser);
        }
    }
}
