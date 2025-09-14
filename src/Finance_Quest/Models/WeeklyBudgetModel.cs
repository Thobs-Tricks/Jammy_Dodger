using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Quest.Models
{
    public partial class WeeklyBudgetModel : ObservableObject
    {
        public string Week { get; set; } = string.Empty;
        [ObservableProperty]
        private double budgetAmount;
        [ObservableProperty]
        private double balance;
        [ObservableProperty]
        private int progressValue;
        [ObservableProperty]
        public ObservableCollection<ExpenseModel> Expenses = [];
    }
}
