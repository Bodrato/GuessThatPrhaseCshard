using Guess_that_Prhase.aplication;
using Newtonsoft.Json;
using System.Text;

namespace Guess_that_Prhase.view
{
    public partial class FrmJuego : Form
    {
        private List<Frase> frases;
        private Frase fraseSecreta;
        private StringBuilder secreta;
        private bool victoria = false;
        private int ronda;
        private System.Timers.Timer timer;
        private float[] tiempoTardado;

        public FrmJuego()
        {
            try
            {
                // Lee el archivo JSON
                using (StreamReader sr = new StreamReader("en.json"))
                {
                    // Convierte el contenido del archivo a una lista de objetos Frase
                    string jsonContent = sr.ReadToEnd();
                    this.frases = JsonConvert.DeserializeObject<List<Frase>>(jsonContent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            List<Frase> frasesFiltradas = new List<Frase>();
            foreach (Frase frase in frases)
            {
                if (frase.Prhase.Length <= 50)
                {
                    frasesFiltradas.Add(frase);
                }
            }

            Random numAleatorio = new Random();

            this.frases = frasesFiltradas;

            fraseSecreta = frases[numAleatorio.Next(0, frases.Count)];

            InitializeComponent();

            Partida();
            lblTurno.Text = Convert.ToString(ronda);
        }

        public void Partida()
        {
            tiempoTardado = new float[] { 0 };
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) => tiempoTardado[0]++;
            timer.Start();
            this.ronda = 1;
            Console.WriteLine(fraseSecreta.Prhase);
            secreta = new StringBuilder();

            for (int i = 0; i < fraseSecreta.Prhase.Length; i++)
            {
                if (fraseSecreta.Prhase[i] == ' ' || fraseSecreta.Prhase[i] == '.'
                    || fraseSecreta.Prhase[i] == ',' || fraseSecreta.Prhase[i] == '\''
                    || fraseSecreta.Prhase[i] == '-')
                {
                    secreta.Append(fraseSecreta.Prhase[i]);
                }
                else
                {
                    secreta.Append('*');
                }
            }
            Console.WriteLine(secreta);
            lblFraseSecreta.Text = secreta.ToString();
        }

        public bool ComprobarVictoria(string cadena, string frase)
        {
            return cadena == frase;
        }

        private void btnLetra_Click(object sender, EventArgs e)
        {
            try
            {
                char letra = txtLetra.Text[0];
                // Buscamos la letra en la frase secreta
                int index = fraseSecreta.Prhase.IndexOf(letra);
                int cont = 0;
                while (index != -1)
                {
                    // Si la letra está en la frase, la reemplazamos en la cadena secreta
                    secreta = new StringBuilder(secreta.ToString().Substring(0, index) + letra + secreta.ToString().Substring(index + 1));

                    // Buscamos la siguiente ocurrencia de la letra
                    index = fraseSecreta.Prhase.IndexOf(letra, index + 1);
                    cont++;
                }
                cont = cont * 5;
                GestionUsuarios.E.Puntuacion = GestionUsuarios.E.Puntuacion + cont;
                // Imprimimos la frase secreta actualizada
                lblFraseSecreta.Text = secreta.ToString();
                if (ComprobarVictoria(secreta.ToString(), fraseSecreta.Prhase))
                {
                    victoria = true;
                    TerminarPartida();
                }
                else
                {
                    SiguienteRonda();
                }
            }
            catch (Exception ex)
            {
                SiguienteRonda();
            }
        }

        private void btnFrase_Click(object sender, EventArgs e)
        {
            string cadena = txtFrase.Text;
            if (ComprobarVictoria(cadena, fraseSecreta.Prhase))
            {
                victoria = true;
                secreta = new StringBuilder(cadena);
                GestionUsuarios.E.Puntuacion = GestionUsuarios.E.Puntuacion + 50;
            }
            lblFraseSecreta.Text = secreta.ToString();
            if (ComprobarVictoria(secreta.ToString(), fraseSecreta.Prhase))
            {
                victoria = true;
                TerminarPartida();
            }
            else
            {
                SiguienteRonda();
            }
        }
        public void TerminarPartida()
        {
            timer.Stop();
            if (victoria)
            {
                GestionUsuarios.E.Tiempo_promedio = GestionUsuarios.E.Tiempo_promedio + tiempoTardado[0];
                GestionUsuarios.E.Tiempo_promedio = GestionUsuarios.E.Tiempo_promedio / 2;
                GestionUsuarios.E.Victorias = GestionUsuarios.E.Victorias + 1;
                GestionUsuarios.E.Puntuacion = GestionUsuarios.E.Puntuacion + 100;
            }
            else
            {
                GestionUsuarios.E.Derrotas = GestionUsuarios.E.Derrotas + 1;
                GestionUsuarios.E.Puntuacion = GestionUsuarios.E.Puntuacion - 100;
            }
            GestionUsuarios.ActualizarEstadisticas();
            if (victoria)
            { 
                label2.Text = "Ganaste, el autor es " + fraseSecreta.Author;
            }
            else
            {
                lblFraseSecreta.Text = fraseSecreta.Prhase;
                label2.Text = "Perdiste, el autor es " + fraseSecreta.Author;
            }

            CerrarVentana();
        }

        public async void CerrarVentana()
        {
            await Task.Delay(10000);
            this.Close();
        }


        public void SiguienteRonda()
        {
            this.ronda++;
            if (this.ronda == 21)
            {
                TerminarPartida();
            }
            else
            {
                lblTurno.Text = Convert.ToString(ronda);
            }
        }
    }
}
