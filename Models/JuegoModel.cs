using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Clase que sirve para representar los resultados de las partidas guardados en la DB
    /// no esta relacionada directamente con el VM del mismo model 
    /// su funcion es la interacion con la DB
    /// </summary>
    public class JuegoModel
    {
        #region popiedades
        public int Id { get; set; }
        public string NombreJugador { get; set; } = "";
        public int NivelAlcanzado { get; set; }
        public int NumeroDeMinasRestantes { get; set; }
        public bool JuegoGanado { get; set; } = false;
        /// <summary>
        ///popriedad aitoimplementada _estadoDelJuego simpleemnte es un string para mostar el resultado de la partida 
        ///en la vista en lugar de true o false
        /// </summary>
        private string _estadoDelJuego = "";
        public string EstadoDelJuego
        {
            get
            {
                if (JuegoGanado == true)
                {
                    _estadoDelJuego = "Partida ganada.";
                }
                else
                {

                    _estadoDelJuego = "Partida perdida.";
                }
                return _estadoDelJuego;



            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// contructor vacio
        /// </summary>
        public JuegoModel()
        {
        }
        /// <summary>
        /// constructor con todas las popiedades
        /// </summary>
        /// <param name="nombreJugador"></param>
        /// <param name="nivelAlcanzado"></param>
        /// <param name="numeroDeMinasRestantes"></param>
        /// <param name="juegoGanado"></param>
        public JuegoModel(string nombreJugador, int nivelAlcanzado, int numeroDeMinasRestantes, bool juegoGanado)
        {
            NombreJugador = nombreJugador;
            NivelAlcanzado = nivelAlcanzado;
            NumeroDeMinasRestantes = numeroDeMinasRestantes;
            JuegoGanado = juegoGanado;
        }
        #endregion
    }
}
