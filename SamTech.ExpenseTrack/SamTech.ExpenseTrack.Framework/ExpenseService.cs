using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseUnitOfWork _expenseUnitOfWork;

        public ExpenseService(IExpenseUnitOfWork expenseUnitOfWork)
        {
            _expenseUnitOfWork = expenseUnitOfWork;
        }
        public void AddExpense(Expense expense)
        {
            var count = _expenseUnitOfWork.ExpenseRepository.GetCount(x => x.Name == expense.Name);
            if(count > 0)
            {
                throw new DuplicationException("Item Name Already Exists", nameof(expense.Name));
            }
            
            _expenseUnitOfWork.ExpenseRepository.Add(expense);
            _expenseUnitOfWork.Save();
        }

        public Expense DeleteExpense(int id)
        {
            var expense = _expenseUnitOfWork.ExpenseRepository.GetById(id);
            _expenseUnitOfWork.ExpenseRepository.Remove(expense);
            _expenseUnitOfWork.Save();
            return expense;
        }

        public void Dispose()
        {
            _expenseUnitOfWork?.Dispose();
        }

        public void EditExpense(Expense expense)
        {
            var count = _expenseUnitOfWork.ExpenseRepository.GetCount(x => x.Name == expense.Name && x.Id != expense.Id);
            if(count > 0)
            {
                throw new DuplicationException("Item Name Already Exists", nameof(expense.Name));
            }

            var existingItem = _expenseUnitOfWork.ExpenseRepository.GetById(expense.Id);
            existingItem.Name = expense.Name;
            existingItem.Category = expense.Category;
            existingItem.Date = expense.Date;
            existingItem.Amount = expense.Amount;

            _expenseUnitOfWork.Save();
        }

        public (IList<Expense> records, int total, int totalDisplay) GetExpense(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _expenseUnitOfWork.ExpenseRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public Expense GetExpenseById(int id)
        {
            return _expenseUnitOfWork.ExpenseRepository.GetById(id);
        }
    }
}
