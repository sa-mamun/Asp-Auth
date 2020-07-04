using SamTech.ExpenseTrack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public interface IExpenseRepository : IRepository<Expense, int, FrameworkContext>
    {

    }
}
