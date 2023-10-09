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
    public class CategoryRepository : GenericRepository<Category>, ICategory
    {
        private readonly DbContextOptions<ContextBase> options;

        public CategoryRepository()
        {
            options = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Category>> GetAllCategoriesFromUser(string email)
        {
            using (var dataBase = new ContextBase(options))
            {
                return await (from financial in dataBase.FinancialSystem
                              join category in dataBase.Category on financial.Id equals category.SystemId
                              join financialUser in dataBase.User on financial.Id equals financialUser.SystemId
                              where financialUser.Email.Equals(email) && financial.ActualSystem
                              select category).AsNoTracking().ToListAsync();
            }
        }
    }
}
