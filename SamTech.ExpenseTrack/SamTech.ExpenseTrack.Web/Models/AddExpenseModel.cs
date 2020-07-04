using Autofac;
using SamTech.ExpenseTrack.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamTech.ExpenseTrack.Web.Models
{
    public class AddExpenseModel : ExpenseBaseModel
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public AddExpenseModel(IExpenseService expenseService) : base(expenseService) { }

        public AddExpenseModel() : base() { }

        public void AddExpense()
        {
            var expense = new Expense
            {
                Name = this.Name,
                Category =this.Category,
                Amount = this.Amount,
                Date = this.Date
            };

            _expenseSevice.AddExpense(expense);
        }

    }
}
