using Guess_that_Prhase.aplication;

namespace Guess_that_Prhase.view
{
    public partial class FrmEstadisticas : Form
    {
        public FrmEstadisticas()
        {
            InitializeComponent();
            lblPuntuacion.Text = Convert.ToString(GestionUsuarios.E.Puntuacion);
            lblTiempoPromedio.Text = Convert.ToString(GestionUsuarios.E.Tiempo_promedio);
            lblVictorias.Text = Convert.ToString(GestionUsuarios.E.Victorias);
            lblDerrotas.Text = Convert.ToString(GestionUsuarios.E.Derrotas);
        }
    }
}
