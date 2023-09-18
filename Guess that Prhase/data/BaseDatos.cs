using Guess_that_Prhase.aplication;
using MySqlConnector;

namespace Guess_that_Prhase.data
{
    internal class BaseDatos
    {
        private MySqlCommand cmd;
        private MySqlConnection con = new MySqlConnection();

        public void ConectarMySQL()
        {
            try
            {
                string connectionString = "Server=localhost;Database=javajuego;Uid=root;Pwd=";
                con = new MySqlConnection(connectionString);
                con.Open();
            }
            catch (MySqlException e)
            {
                GestionUsuarios.Error = "No se ha podido acceder a la base de datos";
            }
        }


        public int GuardarUsuario(Usuario u)
        {
            int id = -1;
            try
            {
                ConectarMySQL();

                string insertQuery = "INSERT INTO usuarios(nombre, email, password) VALUES (@nombre, @email, @password)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@email", u.Correo);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.ExecuteNonQuery();

                string selectQuery = "SELECT * FROM usuarios WHERE email = @correo";
                cmd = new MySqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
                MySqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    id = rs.GetInt32("id");
                }
                con.Close();
                ConectarMySQL();
                string estadisticasQuery = "INSERT INTO estadisticas(usuario_id, puntuacion, tiempo_promedio, victorias, derrotas) VALUES (@usuario_id, 0, 0, 0, 0)";
                MySqlCommand cmd2 = new MySqlCommand(estadisticasQuery, con);
                cmd2.Parameters.AddWithValue("@usuario_id", id);
                cmd2.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                if (GestionUsuarios.Error != "")
                {
                    return -1;
                }
                else
                {
                    GestionUsuarios.Error = e.Message;
                    return -1;
                }
            }
            return 1;
        }

        public Usuario CargarUsuario(string correo)
        {
            Usuario usuario = null;
            MySqlDataReader rs = null;

            try
            {
                ConectarMySQL();

                string consulta = "SELECT * FROM usuarios WHERE email = @correo";
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    string nombre = rs.GetString("nombre");
                    string password = rs.GetString("password");

                    usuario = new Usuario(nombre, password, correo);
                }
            }
            catch (Exception e)
            {
                if (GestionUsuarios.Error != "")
                {
                    
                }
                else
                {
                    GestionUsuarios.Error = e.Message;
                }
            }
            finally
            {
                try
                {
                    if (rs != null) rs.Close();
                    if (con != null) con.Close();
                }
                catch (MySqlException e)
                {
                    GestionUsuarios.Error =e.Message;
                }
            }

            return usuario;
        }

        public Estadisticas ObtenerEstadisticas(string correo)
        {
            Estadisticas estadisticas = null;
            MySqlDataReader rs = null;

            try
            {
                ConectarMySQL();

                string consulta = "SELECT * FROM estadisticas WHERE usuario_id IN " +
                                  "(SELECT estadisticas.usuario_id FROM estadisticas, usuarios " +
                                  "WHERE estadisticas.usuario_id = usuarios.id AND usuarios.id = " +
                                  "(SELECT usuarios.id FROM usuarios WHERE usuarios.email = @correo))";
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    int puntuacion = rs.GetInt32("puntuacion");
                    float tiempoPromedio = rs.GetFloat("tiempo_promedio");
                    int victorias = rs.GetInt32("victorias");
                    int derrotas = rs.GetInt32("derrotas");

                    estadisticas = new Estadisticas(puntuacion, tiempoPromedio, victorias, derrotas);
                }
            }
            catch (Exception e)
            {
                if (GestionUsuarios.Error != "")
                {

                }
                else
                {
                    GestionUsuarios.Error = e.Message;
                }
            }
            finally
            {
                try
                {
                    if (rs != null) rs.Close();
                    if (con != null) con.Close();
                }
                catch (MySqlException e)
                {
                    GestionUsuarios.Error = e.Message;
                }
            }

            return estadisticas;
        }

        public void ActualizarEstadisticas(Estadisticas estadisticas, string correo)
        {
            MySqlDataReader rs;
            int id = -1;
            try
            {
                ConectarMySQL();

                string consultaId = "SELECT id FROM usuarios WHERE usuarios.email = @correo";
                MySqlCommand cmd = new MySqlCommand(consultaId, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    id = rs.GetInt32("id");
                }
                con.Close();
                ConectarMySQL();
                string consulta = "UPDATE estadisticas SET puntuacion = @puntuacion, tiempo_promedio = @tiempoPromedio, " +
                                  "victorias = @victorias, derrotas = @derrotas WHERE usuario_id = @id";
                MySqlCommand cmdUpdate = new MySqlCommand(consulta, con);
                cmdUpdate.Parameters.AddWithValue("@puntuacion", estadisticas.Puntuacion);
                cmdUpdate.Parameters.AddWithValue("@tiempoPromedio", estadisticas.Tiempo_promedio);
                cmdUpdate.Parameters.AddWithValue("@victorias", estadisticas.Victorias);
                cmdUpdate.Parameters.AddWithValue("@derrotas", estadisticas.Derrotas);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                if (GestionUsuarios.Error != "")
                {

                }
                else
                {
                    GestionUsuarios.Error = e.Message;
                }
            }
            finally
            {
                try
                {
                    if (con != null) con.Close();
                }
                catch (MySqlException e)
                {
                    GestionUsuarios.Error = e.Message;
                }
            }
        }

    }
}
