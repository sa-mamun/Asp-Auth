using System;
using System.Collections.Generic;
using System.Text;

namespace SamTech.ExpenseTrack.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
