using Microsoft.Maui.Controls;
using MineSweeper.Pages;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Models.MainPage
{
    internal class MainPageVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Objeto juego ya inicializado
        /// </summary>
        public Partida NuevoJuego { get; set; } = new Partida();

        /// <summary>
        /// objeto CasillaSelecionada que interactua con la vista y maneja la logica del
        /// juego si la casilla no es una mina ni ha sido pisada anteriormente pone el esPisada a true  y resta el nuemro de minas restantes llamando a NuevoJuego.DisminuirNumeroDeCasillasRestantes();
        /// </summary>
        private Casilla? _casillaSelecionada;
        public Casilla? CasillaSelecionada
        {
            get => _casillaSelecionada;
            set
            {
                if (_casillaSelecionada != value && value != null)
                {
                    _casillaSelecionada = value;
                    if (!_casillaSelecionada.EsMina && !_casillaSelecionada.esPisada)
                    {
                        _casillaSelecionada.esPisada = true;
                        NuevoJuego.DisminuirNumeroDeCasillasRestantes();
                    }
                }
                OnPropertyChanged(nameof(CasillaSelecionada));
            }
        }
        public MainPageVM() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }


}

