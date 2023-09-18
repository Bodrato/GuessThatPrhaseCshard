using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_that_Prhase.aplication
{
    internal class Usuario
    {
        public string Nombre { get; }
        public string Password { get; }
        public string Correo { get; }

        public Usuario(string Nombre, string Password, string Correo)
        {
            this.Nombre = Nombre;
            this.Password = Password;
            this.Correo = Correo;
        }
    }
}
