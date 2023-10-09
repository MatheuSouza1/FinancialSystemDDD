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
    public class CategoryService : ICategoryService
    {
        private readonly ICategory _Icategory;

        public CategoryService(ICategory Icategory)
        {
            _Icategory = Icategory; 
        }
        public async Task AddCategory(Category category)
        {
            var valid = category.ValidateStringProp(category.Name, "name");
            if (valid)
            {
                await _Icategory.Add(category);
            }
        }

        public async Task UpdateCategory(Category category)
        {
            var valido = category.ValidateStringProp(category.Name, "name");
            if (valido)
            {
                await _Icategory.Update(category);
            }
        }
    }
}
