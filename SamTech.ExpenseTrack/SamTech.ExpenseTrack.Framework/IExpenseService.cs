using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public interface IExpenseService : IDisposable
    {
        void AddExpense(Expense expense);
        (IList<Expense> records, int total, int totalDisplay) GetExpense(int pageIndex, int pageSize, string searchText, string sortText);
        void EditExpense(Expense expense);
        Expense GetExpenseById(int id);
        Expense DeleteExpense(int id);
    }
}
