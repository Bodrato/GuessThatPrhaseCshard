using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_that_Prhase.aplication
{
    internal class Frase
    {
        public string Prhase { get; }
        public string Author { get; }

        public Frase (string Prhase, string Author)
        {
            this.Prhase = Prhase;
            this.Author = Author;
        }
    }
}
