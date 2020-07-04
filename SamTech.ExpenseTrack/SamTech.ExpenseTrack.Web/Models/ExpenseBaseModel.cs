using Autofac;
using SamTech.ExpenseTrack.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.ExpenseTrack.Web.Models
{
    public class ExpenseBaseModel : MainBaseModel, IDisposable
    {
        public IExpenseService _expenseSevice;

        public ExpenseBaseModel(IExpenseService expenseService)
        {
            _expenseSevice = expenseService;
        }

        public ExpenseBaseModel()
        {
            _expenseSevice = Startup.AutofacContainer.Resolve<IExpenseService>();
        }

        public void Dispose()
        {
            _expenseSevice?.Dispose();
        }
    }
}
