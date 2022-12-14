﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlocco : Blocco
    {
        private readonly Posizione[][] piastra = new Posizione[][]
        {
            new Posizione[] {new Posizione(1,0), new Posizione(1,1), new Posizione(1,2),new Posizione(1,3) },
            new Posizione[] {new Posizione(0,2), new Posizione(1,2), new Posizione(2,2),new Posizione(3,2) },
            new Posizione[] {new Posizione(2,0), new Posizione(2,1), new Posizione(2,2),new Posizione(2,3) },
            new Posizione[] {new Posizione(0,1), new Posizione(1,1), new Posizione(2,1),new Posizione(3,1) }
        };

        public override int ID => 1;
        protected override Posizione InizioOffset => new Posizione(-1,3);
        protected override Posizione[][] Piastra=>piastra;
    }
}