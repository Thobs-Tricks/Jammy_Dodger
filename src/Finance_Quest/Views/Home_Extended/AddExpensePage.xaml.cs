using CommunityToolkit.Maui.Views;
using Finance_Quest.ViewModels;

namespace Finance_Quest.Views.Home_Extended;

public partial class AddExpensePage : Popup
{
	public AddExpensePage(HomeVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
        vm.popup = this;
    }
}
