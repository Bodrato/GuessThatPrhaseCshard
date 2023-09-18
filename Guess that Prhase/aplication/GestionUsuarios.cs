using Guess_that_Prhase.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_that_Prhase.aplication
{
    internal class GestionUsuarios
    {
        public static Usuario U { get; set; }
        public static Estadisticas E { get; set; }
        private static BaseDatos Base = new BaseDatos();
        public static string Error { get; set; }

        public static bool RegistrarUsuario(Usuario u)
        {
            return Base.GuardarUsuario(u) == 1;
        }

        public static bool VerificarDisponibilidad(string correo, string password)
        {
            Usuario u2;
            try
            {
                u2 = Base.CargarUsuario(correo);
                if (u2 == null)
                {
                    return false;
                }
                if (!u2.Password.Equals(password))
                {
                    Error = "Correo o contraseña erronea";
                    return false;
                }
            }catch (Exception e)
            {
                Error = e.Message;
                return false;
            }

            U = u2;
            E = Base.ObtenerEstadisticas(U.Correo);
            return true;
        }

        public static void ActualizarEstadisticas()
        {
            Base.ActualizarEstadisticas(E, U.Correo);
        }
    }
}
