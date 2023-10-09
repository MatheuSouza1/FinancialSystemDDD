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
    public class FinancialUserRepository : GenericRepository<FinancialUser>, IFinancialUser
    {
        private readonly DbContextOptions<ContextBase> options;

        public FinancialUserRepository()
        {
            options = new DbContextOptions<ContextBase>();
        }
        public async Task<FinancialUser> GetUserByEmail(string email)
        {
            using(var dataBase = new ContextBase(options))
            {
                return await (
                    from financialUser in dataBase.User
                    where financialUser.Email == email
                    select financialUser).AsNoTracking().FirstOrDefaultAsync();

                //return await dataBase.User.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);
            }
        }

        public async Task<List<FinancialUser>> ListAllFinancialUserFromSystem(int id)
        {
            using (var dataBase = new ContextBase(options))
            {
                return await dataBase.User.Where(user => user.SystemId== id).AsNoTracking().ToListAsync();
            }
        }

        public async Task RemoveUser(List<FinancialUser> financialUsers)
        {
            using (var dataBase = new ContextBase(options))
            {
                dataBase.User.RemoveRange(financialUsers);
                await dataBase.SaveChangesAsync();
            }
        }
    }
}
