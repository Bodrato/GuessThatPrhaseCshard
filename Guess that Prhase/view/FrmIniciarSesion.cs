using Guess_that_Prhase.aplication;
using System.Text.RegularExpressions;

namespace Guess_that_Prhase.view
{
    public partial class FrmIniciarSesion : Form
    {
        public FrmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string password = txtContraseña.Text;
            Regex pattern = new Regex(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@" +
                         "[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,4})$");

            if (!string.IsNullOrEmpty(correo) || !string.IsNullOrEmpty(password))
            {
                Match match = pattern.Match(correo);
                if (!match.Success)
                {
                    lblMensaje.Text = "Correo inválido";
                }
                else
                {
                    try
                    {
                        if (GestionUsuarios.VerificarDisponibilidad(correo, password))
                        {
                            lblMensaje.Text = "";
                            FrmMenu menu = new FrmMenu();
                            menu.Show();
                        }
                        else
                        {
                            lblMensaje.Text = GestionUsuarios.Error;
                        }
                    }catch
                    {
                        lblMensaje.Text = GestionUsuarios.Error;
                    }
                }
            }
            else
            {
                lblMensaje.Text = "Tienes que rellenar los campos";
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistrarUsuario frmRegistrarUsuario = new FrmRegistrarUsuario();
            frmRegistrarUsuario.Show();
        }
    }
}
