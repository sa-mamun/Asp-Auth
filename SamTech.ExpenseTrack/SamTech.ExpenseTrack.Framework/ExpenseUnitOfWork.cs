using SamTech.ExpenseTrack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public class ExpenseUnitOfWork : UnitOfWork, IExpenseUnitOfWork
    {
        public IExpenseRepository ExpenseRepository { get; set; }

        public ExpenseUnitOfWork(FrameworkContext context, IExpenseRepository expenseRepository)
            : base(context)
        {
            ExpenseRepository = expenseRepository;
        }
    }
}
