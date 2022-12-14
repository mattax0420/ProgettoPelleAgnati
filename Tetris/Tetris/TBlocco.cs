﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TBlocco : Blocco
    {
        private readonly Posizione[][] piastra = new Posizione[][]
        {
            new Posizione[] {new Posizione(0,1), new Posizione(1,0), new Posizione(1,1),new Posizione(1,2) },
            new Posizione[] {new Posizione(0,1), new Posizione(1,1), new Posizione(1,2),new Posizione(2,1) },
            new Posizione[] {new Posizione(1,0), new Posizione(1,1), new Posizione(1,2),new Posizione(2,1) },
            new Posizione[] {new Posizione(0,1), new Posizione(1,0), new Posizione(1,1),new Posizione(2,1) }
        };

        public override int ID => 6;
        protected override Posizione InizioOffset => new Posizione(0, 3);
        protected override Posizione[][] Piastra => piastra;
    }
}
