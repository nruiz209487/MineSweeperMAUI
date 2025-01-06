using MineSweeper.Models.ErrorPage;
using MineSweeper.Models.MainPage;

namespace MineSweeper.Pages;

public partial class ErrorPage : ContentPage
{
    public ErrorPage()
    {
        ErrorPageVM _viewModel = new ErrorPageVM();
        BindingContext = _viewModel;
        InitializeComponent();
    }
    /// <summary>
    /// Nvega a la pagina de inico
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void GoBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPlayerPage());
    }
}