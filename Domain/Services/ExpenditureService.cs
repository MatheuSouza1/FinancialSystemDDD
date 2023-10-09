using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ExpenditureService : IExpenditureServices
    {
        private readonly IExpenditure _Iexpenditure;

        public ExpenditureService(IExpenditure Iexpenditure)
        {
            _Iexpenditure = Iexpenditure;
        }
        public async Task AddExpenditure(Expenditure expenditure)
        {
            var valid = expenditure.ValidateStringProp(expenditure.Name, "name");
            DateTime date = DateTime.UtcNow;
            expenditure.RegisterDate = date;
            expenditure.year = date.Year;
            expenditure.month = date.Month;
            if (valid)
            {
                await _Iexpenditure.Add(expenditure);
            }
        }

        public async Task UpdateExpenditure(Expenditure expenditure)
        {
            var valid = expenditure.ValidateStringProp(expenditure.Name, "name");
            DateTime data = DateTime.UtcNow;
            expenditure.AltDate = data;
            if (expenditure.IsPaid)
            {
                expenditure.PayDate = data;
            }
            if (valid)
            {
                await _Iexpenditure.Update(expenditure);
            }
        }
    }
}
