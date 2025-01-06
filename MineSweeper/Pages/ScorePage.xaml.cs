using MineSweeper.Models.ScorePage;

namespace MineSweeper.Pages;

public partial class ScorePage : ContentPage
{
    public ScorePage()
    {
        try
        {
            InitializeComponent();
            ScorePageVM _viewModel = new ScorePageVM();
            BindingContext = _viewModel;
        }
        catch (Exception)
        {
            Navigation.PushAsync(new ErrorPage());
        }
    }
    /// <summary>
    /// Vuelve a la pagina de inicio
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void GoBackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPlayerPage());
    }
}
