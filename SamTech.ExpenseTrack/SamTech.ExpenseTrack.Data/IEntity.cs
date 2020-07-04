using System;

namespace SamTech.ExpenseTrack.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
