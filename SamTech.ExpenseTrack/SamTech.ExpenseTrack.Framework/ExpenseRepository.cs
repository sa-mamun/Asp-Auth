using SamTech.ExpenseTrack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Framework
{
    public class ExpenseRepository : Repository<Expense, int, FrameworkContext>, IExpenseRepository
    {
        public ExpenseRepository(FrameworkContext context)
            :base (context)
        {

        }
    }
}
