using MineSweeper.Pages;

namespace MineSweeper
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //implementacion NavigationPage
            MainPage = new NavigationPage(new NewPlayerPage());
        }
    }
}
