using Finance_Quest.DataStorage;
using Finance_Quest.Models;
using Finance_Quest.Views.Home_Extended;
using System.Collections.ObjectModel;

namespace Finance_Quest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("AddExpensePage", typeof(AddExpensePage));
            Routing.RegisterRoute("QuizPage", typeof(QuizPage));

            var existingWeeklyBudget = Caching.GetCache<ObservableCollection<WeeklyBudgetModel>>("WeeklyBudget") ?? new ObservableCollection<WeeklyBudgetModel>();

            existingWeeklyBudget.Add(new WeeklyBudgetModel
            {
                Week = "Week 1",
                BudgetAmount = 1500.00,
                Balance = 1500.00,
                ProgressValue = 100
            });

            Caching.SetCache("WeeklyBudget", existingWeeklyBudget);
        }
    }
}
