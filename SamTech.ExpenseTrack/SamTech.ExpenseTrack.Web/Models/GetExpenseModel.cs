using SamTech.ExpenseTrack.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.ExpenseTrack.Web.Models
{
    public class GetExpenseModel : ExpenseBaseModel
    {

        public GetExpenseModel(IExpenseService expenseService) : base(expenseService) { }

        public GetExpenseModel() : base() { }

        internal object GetExpense(DataTablesAjaxRequestModel tableModel)
        {
            var data = _expenseSevice.GetExpense(tableModel.PageIndex,
                                                    tableModel.PageSize,
                                                    tableModel.SearchText,
                                                    tableModel.GetSortText(new string[] { "Name", "Category", "Date", "Amount" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Category,
                                record.Date.ToString(),
                                record.Amount.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal string DeleteExpense(int id)
        {
            var model = _expenseSevice.DeleteExpense(id);
            return model.Name;
        }
    }
}
