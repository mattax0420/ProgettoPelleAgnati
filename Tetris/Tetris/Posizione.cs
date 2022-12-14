using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Posizione
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }

        public Posizione(int riga, int colonna)
        {
            Riga = riga;
            Colonna = colonna;
        }
    }
}
