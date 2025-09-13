using Finance_Quest.Views.Home_Extended;

namespace Finance_Quest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("AddExpensePage", typeof(AddExpensePage));
        }
    }
}
