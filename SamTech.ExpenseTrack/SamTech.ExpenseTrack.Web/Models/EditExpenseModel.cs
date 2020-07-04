using SamTech.ExpenseTrack.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.ExpenseTrack.Web.Models
{
    public class EditExpenseModel : ExpenseBaseModel
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public EditExpenseModel(IExpenseService expenseService) : base(expenseService) { }

        public EditExpenseModel() : base() { }

        public void EditExpense()
        {
            var expense = new Expense
            {
                Id = this.Id,
                Name = this.Name,
                Category = this.Category,
                Amount = this.Amount,
                Date = this.Date
            };

            _expenseSevice.EditExpense(expense);
        }

        public void LoadData(int id)
        {
            var expense = _expenseSevice.GetExpenseById(id);

            if(expense != null)
            {
                Id = expense.Id;
                Name = expense.Name;
                Category = expense.Category;
                Amount = expense.Amount;
                Date = expense.Date;
            }
        }
    }
}
