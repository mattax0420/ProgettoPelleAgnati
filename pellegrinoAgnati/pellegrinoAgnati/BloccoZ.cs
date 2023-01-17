using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class BloccoZ : Blocco
    {
        private Pos[][] blocchetti = new Pos[][]
        {
             new Pos[] {new(0,0), new(0,1), new (1,1), new(1,2)},  //primo stato di rotazione
             new Pos[] {new(0,2), new(1,1), new (1,2), new(2,1)},  //secondo stato di rotazione
             new Pos[] {new(1,0), new(1,1), new (2,1), new(2,2)},  //terzo stato di rotazione
             new Pos[] {new(0,1), new(1,0), new (1,1), new(2,0)},  //quarto stato di rotazione
        };

        public override int IDBlocco => 7; //identificatore del blocco per utilizzo del random

        protected override Pos[][] Blocchetto => blocchetti; //in base alla rotazione grazie al get nella classe Blocco varierà la posizione dei blocchetti

        protected override Pos InizioOffset => new Pos(0,3); //posizione iniziale 
        override public BloccoZ getInstance()
        {
            return new BloccoZ();
        }
    }
}
