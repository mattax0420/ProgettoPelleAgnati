using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class OBlocco : Blocco
    {
        private readonly Posizione[][] piastra = new Posizione[][]
        {
            new Posizione[]{new Posizione(0,0),new Posizione(0,1),new Posizione(1,0),new Posizione(1,1)}
        };

        public override int ID => 4;
        protected override Posizione InizioOffset => new Posizione(0,4);
        protected override Posizione[][] Piastra => piastra;
    }
}
