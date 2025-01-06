using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Models.ScorePage
{
    internal class ScorePageVM
    {
        public string Img { get; } = "https://media.tenor.com/r1XpaREawSsAAAAi/pepe-transparent.gif";

        /// <summary>
        /// Listado del historial de partdias no notifica a la lista ya que no se actualiza en tiempo real 
        /// simplemente te muestra el listado presente despues de ser insertado tu partida 
        /// </summary>
        public List<JuegoModel> ListadoDePartidas
        {
            get { return BL.Service.ObtenerListadoDePartidas(); }
        }
        public ScorePageVM() { }
    }
}
