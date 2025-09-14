using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Finance_Quest.DataStorage;
using Finance_Quest.Models;
using Finance_Quest.Views.Home_Extended;
using System.Collections.ObjectModel;

namespace Finance_Quest.ViewModels
{
    public partial class HomeVM : ObservableObject
    {
        public Popup popup;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private WeeklyBudgetModel weeklyBudget;

        public HomeVM()
        {
            // Initialize categories
            Categories = new ObservableCollection<string>
            {
                "Food",
                "Transport",
                "Shopping",
                "Entertainment",
                "Other"
            };
        }

        [RelayCommand]
        public void InitiateHome()
        {
            var existingWeeklyBudget = Caching.GetCache<ObservableCollection<WeeklyBudgetModel>>("WeeklyBudget");

            if(existingWeeklyBudget != null && existingWeeklyBudget.Count > 0)
            {
                WeeklyBudget = existingWeeklyBudget[0];

            }
            else
            {

            }

        }

        //Goto Add Expense Popup Page
        [RelayCommand]
        public async Task GotoAddExpense()
        {
            await AppShell.Current.ShowPopupAsync(new AddExpensePage(this));
        }

        [RelayCommand]
        public async void ClosePop()
        {
            // Clear input fields
            ExpenseAmount = string.Empty;
            SelectedCategory = null;
            await popup.CloseAsync();
        }

        [ObservableProperty]
        private ObservableCollection<string> categories;

        [ObservableProperty]
        private string selectedCategory;


        [ObservableProperty]
        private ExpenseModel expenseMdl;

        [ObservableProperty]
        private string expenseAmount;

        [ObservableProperty]
        private string monsterHealth = "0.0";

        [ObservableProperty]
        private Color expenseColor = Color.FromArgb("#F5F0E6");

        [RelayCommand]
        private void SaveExpense()
        {
            IsBusy = true;

            try
            {
                if (string.IsNullOrWhiteSpace(ExpenseAmount) || string.IsNullOrWhiteSpace(SelectedCategory))
                {
                    _ = Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                    return;
                }
                if (!double.TryParse(ExpenseAmount, out double expenseAmount) || expenseAmount <= 0)
                {
                    _ = Shell.Current.DisplayAlert("Error", "Please enter a valid amount.", "OK");
                    return;
                }

                // Save the expense to your data storage (e.g., database, file, etc.)
                var newExpense = new ExpenseModel()
                {
                    Price = expenseAmount,
                    Category = SelectedCategory,
                };


                ExpenseMdl = newExpense;

                var newBalance = (WeeklyBudget.Balance - expenseAmount);
                WeeklyBudget.Balance = newBalance;

                // Close the popup
                ClosePop();

                AfterClose();

                _ = Toast.Make("Expense added successfully.").Show();
            }
            catch (Exception ex)
            {
                _ = Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }


        [RelayCommand]
        public void AfterClose()
        {
            if(WeeklyBudget.Balance > 0)
            {
                ExpenseColor = Color.FromArgb("E53935");

                var value = ((WeeklyBudget.BudgetAmount - WeeklyBudget.Balance) / WeeklyBudget.BudgetAmount) * 100;
                var value2 = 100 - value;

                for(double r = WeeklyBudget.Balance; r >= value2; r--)
                {
                    WeeklyBudget.ProgressValue = (int)value2;
                }

                MonsterHealth = "100";

            }
            else
            {
                ExpenseColor = Color.FromArgb("E53935");

              

                
            }
        }


        //Goto Quiz Page
        [RelayCommand]
        public async Task GotoQuiz()
        {
            await AppShell.Current.GoToAsync(nameof(QuizPage));
        }

    }
}
