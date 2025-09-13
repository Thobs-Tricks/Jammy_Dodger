using Finance_Quest.ViewModels;

namespace Finance_Quest.Views.TabPages
{
    public partial class HomePage : ContentPage
    {

        public HomePage(HomeVM vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
