using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class ExpenditureRepository : GenericRepository<Expenditure>, IExpenditure
    {
        private readonly DbContextOptions<ContextBase> options;
        public ExpenditureRepository()
        {
            options = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Expenditure>> GetAllExpenditure(string email)
        {
            using(var dataBase = new ContextBase(options))
            {
                return await (
                    from financial in dataBase.FinancialSystem
                    join category in dataBase.Category on financial.Id equals category.SystemId
                    join financialUser in dataBase.User on financial.Id equals financialUser.SystemId
                    join expenditure in dataBase.Expenditure on financial.Id equals expenditure.CategoryId
                    where financialUser.Email.Equals(email) && financial.Month == expenditure.month && financial.Year == expenditure.year
                    select expenditure).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Expenditure>> GetAllPastDueExpenditure(string email)
        {
            using(var dataBase = new ContextBase(options))
            {
                return await (
                    from financial in dataBase.FinancialSystem
                    join category in dataBase.Category on financial.Id equals category.SystemId
                    join financialUser in dataBase.User on financial.Id equals financialUser.SystemId
                    join expenditure in dataBase.Expenditure on financial.Id equals expenditure.CategoryId
                    where financialUser.Email.Equals(email) && expenditure.month < DateTime.Now.Month && expenditure.year < DateTime.Now.Month && !expenditure.IsPaid
                    select expenditure).AsNoTracking().ToListAsync();
            }
        }
    }
}
