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
        public double BudgetAmount { get; set; }
        [ObservableProperty]
        public double Balance { get; set; }
        [ObservableProperty]
        public int ProgressValue { get; set; }
        [ObservableProperty]
        public ObservableCollection<ExpenseModel> Expenses { get; set; } = [];
    }
}
