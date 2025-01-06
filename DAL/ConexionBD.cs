using DAL;
using Microsoft.Data.SqlClient;
using Models;

namespace DAL
{
    public class ConexionBD
    {
        /// <summary>
        /// Inserta el resultado de la partida en la DB
        /// </summary>
        /// <param name="obj"></param>
        public static void InsertarNuevaPartida(JuegoModel obj)
        {
            using (SqlConnection conexion = getConexion())
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand miComando = new SqlCommand("INSERT INTO Juego (NombreJugador, NumeroDeMinasRestantes, NivelAlcanzado, JuegoGanado) VALUES (@NombreJugador, @NumeroDeMinasRestantes, @NivelAlcanzado, @JuegoGanado)", conexion))
                    {
                        miComando.Parameters.AddWithValue("@NombreJugador", obj.NombreJugador);
                        miComando.Parameters.AddWithValue("@NumeroDeMinasRestantes", obj.NumeroDeMinasRestantes);
                        miComando.Parameters.AddWithValue("@NivelAlcanzado", obj.NivelAlcanzado);
                        miComando.Parameters.AddWithValue("@JuegoGanado", obj.JuegoGanado);

                        miComando.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// LLama a la DB y recive el listado de partidas 
        /// </summary>
        /// <returns> un listado del objeto JuegoModel </returns>
        public static List<JuegoModel> ObtenerListadoDePartidas()
        {
            List<JuegoModel> listado = new List<JuegoModel>();

            using (SqlConnection conexion = getConexion())
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand miComando = new SqlCommand("SELECT * FROM Juego \r\nORDER BY NivelAlcanzado DESC, NumeroDeMinasRestantes ASC;", conexion))
                    {
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            while (miLector.Read())
                            {

                                JuegoModel juegoObj = new JuegoModel();

                                juegoObj.Id = (int)miLector["Id"];
                                juegoObj.NombreJugador = (string)miLector["NombreJugador"];
                                juegoObj.NumeroDeMinasRestantes = (int)miLector["NumeroDeMinasRestantes"];
                                juegoObj.NivelAlcanzado = (int)miLector["NivelAlcanzado"];
                                juegoObj.JuegoGanado = (bool)miLector["JuegoGanado"];
                                listado.Add(juegoObj);
                            }
                        }
                    }
                }
            }

            return listado;
        }

        /// <summary>
        ///  obtiene la conexion con la Db
        /// </summary>
        /// <returns>devuelvve un obj SqlConnection </returns>
        private static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {
                miConexion.ConnectionString = "server=nruiz-nervion.database.windows.net;database=nruizDB ;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";
                miConexion.Open();

            }
            catch (Exception)
            {
                throw;
            }

            return miConexion;
        }


    }
}

