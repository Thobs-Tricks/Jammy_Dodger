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
        private string budget = "";
        public HomeVM()
        {
            if (Caching.GetCache<decimal>("Budget Amount") == 0)
            {
                Budget = "0.0";
                _= Shell.Current.DisplayAlert("Set Budget", "You have not set a budget yet. Please set your budget in the Settings page.", "OK");
            }
            else
            {
                var getBudget = Caching.GetCache<decimal>("Budget Amount");
                Budget = getBudget.ToString();
            }

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

        //Goto Add Expense Popup Page
        [RelayCommand]
        public async Task GotoAddExpense()
        {
            await AppShell.Current.ShowPopupAsync(new AddExpensePage(this));
        }

        [RelayCommand]
        public async void ClosePop()
        {
            await popup.CloseAsync();
        }

        [ObservableProperty]
        private ObservableCollection<string> categories;

        [ObservableProperty]
        private string selectedCategory;

        [ObservableProperty]
        private string amount;

        public void CalculatePercentage()
        {
            // Implement your percentage calculation logic here
            var budgetAmount = Caching.GetCache<decimal>("Budget Amount");

            if (decimal.TryParse(Amount, out decimal expenseAmount) && budgetAmount > 0)
            {
                var percentage = (expenseAmount / budgetAmount) * 100;
                // You can store or display this percentage as needed
                ChooseMonster(percentage);
            }else
            {

            }

        }



        public void ChooseMonster(decimal percenatage)
        {
            // Implement your monster choosing logic here based on the percentage
            if (percenatage < 20)
            {
                // Choose monster A

            }
            else if (percenatage < 50)
            {
                // Choose monster B
            }
            else if (percenatage < 80)
            {
                // Choose monster C
            }
            else
            {
                // Choose monster D
            }
        }


        [RelayCommand]
        private void SaveExpense()
        {
            IsBusy = true;

            try
            {
                if (string.IsNullOrWhiteSpace(Amount) || string.IsNullOrWhiteSpace(SelectedCategory))
                {
                    _ = Shell.Current.DisplayAlert("Error", "Please fill in all fields.", "OK");
                    return;
                }
                if (!decimal.TryParse(Amount, out decimal expenseAmount) || expenseAmount <= 0)
                {
                    _ = Shell.Current.DisplayAlert("Error", "Please enter a valid amount.", "OK");
                    return;
                }

                // Save the expense to your data storage (e.g., database, file, etc.)
                // Example: ExpenseService.SaveExpense(new Expense { Amount = expenseAmount, Category = SelectedCategory, Date = DateTime.Now });

                var newExpense = new ExpenseModel()
                {
                    Price = expenseAmount,
                    Category = SelectedCategory,
                };

                var existingExpenses = Caching.GetCache<ObservableCollection<ExpenseModel>>("ExpensesList") ?? new ObservableCollection<ExpenseModel>();
                existingExpenses.Add(newExpense);
                Caching.SetCache("ExpensesList", existingExpenses);


                // Calculate percentage and choose monster
                CalculatePercentage();

                // Update budget display
                var budgetAmount = Caching.GetCache<decimal>("Budget Amount");
                var value = (budgetAmount - expenseAmount);

                Budget = value.ToString();
                AmountLeft = value;

                // Clear input fields
                Amount = string.Empty;
                SelectedCategory = null;


                // Close the popup
                ClosePop();



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

        [ObservableProperty]
        private decimal amountLeft;

        [ObservableProperty]
        private string monsterHealth;

        [ObservableProperty]
        private Color expenseColor;

        [RelayCommand]
        public void AfterClose()
        {
            if (value > 0)
            {
                for (int r = 1; r =< Amount; r += 2)
                {
                    Amount -= r
                }



            }
            else
            {
                for (int r = 1; r =< Amount; r += 2)
                {
                    Amount -= r
                }

                ExpenseColor = Color.FromArgb("#E53935")
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
