using Guess_that_Prhase.aplication;
using System.Text.RegularExpressions;

namespace Guess_that_Prhase.view
{
    public partial class FrmRegistrarUsuario : Form
    {
        public FrmRegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblMensaje.ForeColor = Color.Red;
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string password = txtPassword.Text;
            Regex pattern = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@" +
                         "[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,4})$");

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(password))
            {
                lblMensaje.ForeColor = Color.Red;
                Match match = pattern.Match(correo);
                if (!match.Success)
                {
                    lblMensaje.Text = "Correo inválido";
                }
                else
                {
                    if (GestionUsuarios.RegistrarUsuario(new Usuario(nombre, password, correo)))
                    {
                        lblMensaje.ForeColor = Color.Black;
                        lblMensaje.Text = "Usuario registrado correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = GestionUsuarios.Error;
                    }
                }
            }
            else
            {
                lblMensaje.Text = "Tienes que rellenar todos los campos";
            }
        }
    }
}
