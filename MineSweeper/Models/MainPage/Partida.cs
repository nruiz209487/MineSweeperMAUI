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
    public class Partida : INotifyPropertyChanged
    {

        public string NombreJugador { get; set; } = "";
        public bool JuegoGanado { get; private set; } = false;
        public int Nivel { get; private set; } = 0;
        public ManejadoraColumnas objManejadoraColumnas { get; } = new ManejadoraColumnas();
        public List<List<Casilla>>? ListadoDeCasillas { get; private set; } = new List<List<Casilla>>();


        /// <summary>
        /// Se encaraga de contar el numero de casillas restantes cuando estas llegan a zero llama a InicializarNuevoNivel();
        /// </summary>
        private int _numeroDeCasillasSegurasRestantes;
        public int NumeroDeCasillasSegurasRestantes
        {
            get => _numeroDeCasillasSegurasRestantes;
            private set
            {
                _numeroDeCasillasSegurasRestantes = Math.Max(0, value);
                if (_numeroDeCasillasSegurasRestantes == 0)
                {
                    InicializarNuevoNivel();
                }
            }
        }

        public Partida()
        {
            InicializarNuevoNivel();
        }

        /// <summary>
        /// Se encarga de disminuir el numero de casillas
        /// </summary>
        public void DisminuirNumeroDeCasillasRestantes() { NumeroDeCasillasSegurasRestantes--; }


        /// <summary>
        /// Funcion que se encarga de inicizializar un nuevo nivel del jeugo
        /// </summary>
        private void InicializarNuevoNivel()
        {
            Nivel++;
            ListadoDeCasillas = BL.Service.NuevoNivel(Nivel);

            if (ListadoDeCasillas == null)
            {
                Nivel--;
                JuegoGanado = true;
            }
            else
            {
                NumeroDeCasillasSegurasRestantes = BL.Service.NumeroDeMinasSeguras;

                for (int i = 0; i < ListadoDeCasillas.Count; i++)
                {
                    objManejadoraColumnas.ActualizarColumna(i, ListadoDeCasillas[i]);

                }
                OnPropertyChanged(nameof(ListadoDeCasillas));
            }

        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
