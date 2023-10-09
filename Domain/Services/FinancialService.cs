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
    public class FinancialService : IFinancialService
    {
        private readonly IFinancial _Ifinancial;

        public FinancialService(IFinancial ifinancial)
        {
            _Ifinancial = ifinancial;
        }

        public async Task AddFinancialSystem(Financial financial)
        {
            var valid = financial.ValidateStringProp(financial.Name, "name");
            if (valid)
            {
                DateTime date = DateTime.Now;

                financial.MonthlyClosing = 1;
                financial.Year = date.Year;
                financial.Month = date.Month;
                financial.YearCopy = date.Year;
                financial.CopyMonth = date.Month;
                financial.CreateCopy = true;

                await _Ifinancial.Add(financial);
            }
        }

        public async Task UpdateFinancialSystem(Financial financial)
        {
            var valid = financial.ValidateStringProp(financial.Name, "name");
            if (valid)
            {
                financial.MonthlyClosing = 1;
                await _Ifinancial.Update(financial);
            }
        }
    }
}
