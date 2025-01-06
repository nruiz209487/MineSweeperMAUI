using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Models.NewPlayer
{
    public class NewPlayerPageVM
    {
        public string Img { get; } = "https://www.gifcen.com/wp-content/uploads/2022/03/pepe-the-frog-gif-1.gif";

        /// <summary>
        /// Propiedad nombre que simplemente interactua con la vista
        /// </summary>
        private string _nombre = "";
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nombre = value;
                }

            }
        }
    }
}
