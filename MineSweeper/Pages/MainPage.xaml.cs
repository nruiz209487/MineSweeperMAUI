using MineSweeper.Models.MainPage;
using MineSweeper.Pages;
using Models;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MineSweeper
{
    public partial class MainPage : ContentPage
    {
        private MainPageVM _viewModel;
        /// <summary>
        /// Recibe como parametro el nombre del jugador no me quiero crear una variable estatica 
        /// </summary>
        /// <param name="nombre"></param>
        public MainPage(string nombre)
        {

            _viewModel = new MainPageVM();
            _viewModel.NuevoJuego.NombreJugador = nombre;
            BindingContext = _viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        /// <summary>
        /// Navega a la siguiente pagina cuando se gana una partida o se pisa una mina y inserta los datos a la DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageVM.CasillaSelecionada))
                if (_viewModel.CasillaSelecionada?.EsMina == true || _viewModel.NuevoJuego?.JuegoGanado == true)
                {
                    JuegoModel obj;
                    try
                    {
                        obj = new JuegoModel(_viewModel.NuevoJuego.NombreJugador, _viewModel.NuevoJuego.Nivel, _viewModel.NuevoJuego.NumeroDeCasillasSegurasRestantes, _viewModel.NuevoJuego.JuegoGanado);
                        BL.Service.InsertarNuevaPartida(obj);
                        await Navigation.PushAsync(new ScorePage());
                    }
                    catch (Exception)
                    {
                        await Navigation.PushAsync(new ErrorPage());
                    }

                }
        }
    }

}
