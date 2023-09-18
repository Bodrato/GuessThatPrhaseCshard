using Guess_that_Prhase.aplication;

namespace Guess_that_Prhase.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            lblBienvenida.Text = "Bienvenido " + GestionUsuarios.U.Nombre;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            FrmJuego frmJuego = new FrmJuego();
            frmJuego.Show();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas frmEstadisticas = new FrmEstadisticas();
            frmEstadisticas.Show();
        }
    }
}
