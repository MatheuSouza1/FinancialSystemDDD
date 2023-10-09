using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class FinancialRepository : GenericRepository<Financial>, IFinancial
    {
        private readonly DbContextOptions<ContextBase> option;

        public FinancialRepository()
        {
            option = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Financial>> GetAllFinancialSystemsFromUser(string email)
        {
            using (var dataBase = new ContextBase(option))
            {
                return await
                    (from financial in dataBase.FinancialSystem
                     join financialUser in dataBase.User on financial.Id equals financialUser.SystemId
                     where financialUser.Email.Equals(email)
                     select financial).AsNoTracking().ToListAsync();
            }
        }
    }
}
