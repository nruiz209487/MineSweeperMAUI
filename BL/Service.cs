using Models;
using System.Collections;
using System.Collections.Generic;

namespace BL
{
    public class Service
    {
        #region reglas de juego
        /// <summary>
        /// Popiedad de numero de mmero de minas seguras (sirve para saber cuando un nivel ha sido complentado)
        /// cada vez que se aumenta el nivel la popiedad se actualiza en la funcion NuevoNivel(int dificultad)
        /// </summary>
        public static int NumeroDeMinasSeguras { get; private set; } = 0;

        /// <summary>
        /// Inicializa un listado de minas dependiendo del parametro de dificultad
        /// </summary>
        /// <param name="dificultad"></param>
        /// <returns>un listadode casillas o null si el nivel no existe </returns>
        public static List<List<Casilla>>? NuevoNivel(int dificultad)
        {
            int numeroDeCasillas = 1;
            int numeroDeMinasActivasPorColumna = 1;
            int numeroDeColumnas = 1;
            List<List<Casilla>>? juego = new List<List<Casilla>>();


            switch (dificultad)
            {
                case 1:
                    numeroDeMinasActivasPorColumna = 1;
                    numeroDeCasillas = 8;
                    numeroDeColumnas = 10;
                    break;
                case 2:
                    numeroDeMinasActivasPorColumna = 2;
                    numeroDeCasillas = 10;
                    numeroDeColumnas = 12;
                    break;
                case 3:
                    numeroDeMinasActivasPorColumna = 3;
                    numeroDeCasillas = 12;
                    numeroDeColumnas = 14;
                    break;
                case 4:
                    numeroDeMinasActivasPorColumna = 4;
                    numeroDeCasillas = 14;
                    numeroDeColumnas = 16;
                    break;

                default:
                    juego = null;
                    break;
            }

            if (juego != null)
            {
                NumeroDeMinasSeguras = (numeroDeCasillas - numeroDeMinasActivasPorColumna) * numeroDeColumnas;
                RellenarJuego(numeroDeCasillas, numeroDeMinasActivasPorColumna, numeroDeColumnas, juego);
                DesarodenarJuego(juego);
                AsignarNumeroDeMinasCercanas(juego);
            }
            return juego;
        }

        /// <summary>
        /// Compureba las casillas alrededor de  cada casilla y ccuenta su numero de minas cercanas finalmente llama a get de NumeroDeMinasCercanas y asigna el valor
        /// </summary>
        /// <param name="juego"></param>
        private static void AsignarNumeroDeMinasCercanas(List<List<Casilla>> juego)
        {
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 }; // Desplazamientos en x
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 }; // Desplazamientos en y
            int minasCercanas;
            for (int x = 0; x < juego.Count; x++)
            {
                for (int y = 0; y < juego[x].Count; y++)
                {
                    // Inicializa el contador
                    minasCercanas = 0;

                    // Recorre las 8 posiciones 
                    for (int i = 0; i < 8; i++)
                    {
                        int nx = x + dx[i];
                        int ny = y + dy[i];

                        // Verifica si la posicion  está en el tablero
                        if (nx >= 0 && nx < juego.Count && ny >= 0 && ny < juego[x].Count)
                        {
                            // Cuenta la mina
                            if (juego[nx][ny].EsMina)
                            {
                                minasCercanas++;
                            }
                        }
                    }

                    // Asigna las minas cercanas
                    juego[x][y].NumeroDeMinasCercanas = minasCercanas;
                }
            }
        }




        /// <summary>
        /// Rellean el lisatdo
        /// </summary>
        /// <param name="numeroDeCasillas"></param>
        /// <param name="numeroDeMinasActivas"></param>
        /// <param name="numeroDeColumnas"></param>
        /// <param name="juego"></param>
        private static void RellenarJuego(int numeroDeCasillas, int numeroDeMinasActivas, int numeroDeColumnas, List<List<Casilla>> juego)
        {
            List<Casilla> x;
            for (int i = 0; i < numeroDeColumnas; i++)
            {
                x = new List<Casilla>();
                juego.Add(x);
            }

            Casilla nuevaMina;
            foreach (List<Casilla> columna in juego)
            {
                for (int i = 0; i < numeroDeCasillas - numeroDeMinasActivas; i++)
                {
                    nuevaMina = new Casilla();
                    columna.Add(nuevaMina);

                }
                for (int i = 0; i < numeroDeMinasActivas; i++)
                {
                    nuevaMina = new Casilla();
                    nuevaMina.EsMina = true;
                    columna.Add(nuevaMina);

                }
            }
        }

        /// <summary>
        /// Desoorderna el listado
        /// </summary>
        /// <param name="juego"></param>
        private static void DesarodenarJuego(List<List<Casilla>> juego)
        {
            Random rng = new Random();

            foreach (List<Casilla> columna in juego)
            {
                int n = columna.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Casilla temp = columna[k];
                    columna[k] = columna[n];
                    columna[n] = temp;
                }
            }
        }

        #endregion
        #region Base de datos


        /// <summary>
        /// LLama a la DAL y recive el listado de partidas 
        /// </summary>
        /// <returns> un listado del objeto JuegoModel </returns>
        public static List<JuegoModel> ObtenerListadoDePartidas()
        {
            return DAL.ConexionBD.ObtenerListadoDePartidas();

        }
        /// <summary>
        /// Inserta el resultado de la partida en la DB llama a la DAL
        /// </summary>
        /// <param name="obj"></param>
        public static void InsertarNuevaPartida(JuegoModel obj)
        {
            DAL.ConexionBD.InsertarNuevaPartida(obj);
        }
        #endregion
    }


}
