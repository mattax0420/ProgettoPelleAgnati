using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class Pos
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }

        public Pos(int rig, int colon)
        {
            Riga = rig;
            Colonna = colon;
        }   
    }
}
