using System.ComponentModel;

namespace Models
{

    public class Casilla : INotifyPropertyChanged
    {
        #region propiedades

        private bool _esMina = false;

        private bool _esPisada = false;


        /// <summary>
        /// Se encarga de manejar el evento de selecionar una casilla al selecionar una dependiendo 
        /// del si es activa o el numero de minas adyacentes le asigna una imagen u otra 
        /// notifica a la vista que la imagen a cambiado 
        /// </summary>
        public bool esPisada
        {
            get => _esPisada;
            set
            {
                _esPisada = true;
                if (_esMina == true)
                {

                    Img = "mina.png";
                }
                else
                {
                    switch (NumeroDeMinasCercanas)
                    {
                        case 0:
                            Img = "safe.png";
                            break;
                        case 1:
                            Img = "image1.png";
                            break;
                        case 2:
                            Img = "image2.png";
                            break;
                        case 3:
                            Img = "image3.png";
                            break;
                        case 4:
                            Img = "image4.png";
                            break;
                        case 5:
                            Img = "image5.png";
                            break;
                        case 6:
                            Img = "image6.png";
                            break;
                        case 7:
                            Img = "image7.png";
                            break;
                        case 8:
                            Img = "image8.png";
                            break;
                        default:
                            Img = "default.png";
                            break;
                    }
                }
                OnPropertyChanged(nameof(Img));
            }
        }

        public bool EsMina
        {
            get => _esMina;
            set
            {
                //  si pones esto las minas no estan escondidas Img = "mina.png";
                _esMina = true;
            }
        }
        /// <summary>
        /// Popiedad que se encarga de manejar el numero de minas cercanas a la casilla (para asignar el numero)
        /// </summary>
        public int NumeroDeMinasCercanas { get; set; } = 0;
        /// <summary>
        /// GET de imagen para la vista
        /// </summary>
        public string Img { get; private set; } = "defaultimage.png";



        #endregion
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Casilla() { }
        /// <summary>
        /// implentacion del OnPropertyChanged para notificar a la vista que la imagen de la casilla ha cambido
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
