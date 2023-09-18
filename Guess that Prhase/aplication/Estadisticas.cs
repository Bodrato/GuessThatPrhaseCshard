using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_that_Prhase.aplication
{
    internal class Estadisticas
    {
        public int Puntuacion { get; set; }
        public float Tiempo_promedio { get; set; }
        public int Victorias { get; set; }
        public int Derrotas { get; set; }

        public Estadisticas(int Puntuacion, float Tiempo_promedio, int Victorias, int Derrotas)
        {
            this.Puntuacion = Puntuacion;
            this.Tiempo_promedio = Tiempo_promedio;
            this.Victorias = Victorias;
            this.Derrotas = Derrotas;
        }
    }
}
