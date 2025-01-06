using Microsoft.IdentityModel.Tokens;
using MineSweeper.Models.NewPlayer;
using MineSweeper.Pages;

namespace MineSweeper.Pages;

public partial class NewPlayerPage : ContentPage
{
    private NewPlayerPageVM _viewModel;

    public NewPlayerPage()
    {
        _viewModel = new NewPlayerPageVM();
        InitializeComponent();
        BindingContext = _viewModel;
    }

    /// <summary>
    /// Navega a Mainpage si el nombre no es null o empty 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnContinueClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_viewModel.Nombre))
        {
            // Navegar a MainPage pasando el nombre
            await Navigation.PushAsync(new MainPage(_viewModel.Nombre));
        }
        else
        {
            await DisplayAlert("Error", "Por favor, ingrese su nombre antes de continuar.", "Aceptar");
        }
    }
}
