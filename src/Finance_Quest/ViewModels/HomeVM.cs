using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Finance_Quest.ViewModels
{
    public partial class HomeVM : ObservableObject
    {
        [ObservableProperty]
        private string welcomeText = "Welcome to Finance Quest!";


        public HomeVM()
        {
            
        }


        [RelayCommand]
        public async Task GotoAddExpense()
        {
            await Shell.Current.GoToAsync("AddExpensePage");
        }
    }
}
