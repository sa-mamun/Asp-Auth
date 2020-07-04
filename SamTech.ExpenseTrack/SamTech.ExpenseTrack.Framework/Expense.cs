using SamTech.ExpenseTrack.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace SamTech.ExpenseTrack.Framework
{
    public class Expense : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
