using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class BloccoI : Blocco
    {
        private Pos[][] blocchetti = new Pos[][]
        {
             new Pos[] {new(1,0), new(1,1), new (1,2), new(1,3)},  //primo stato di rotazione
             new Pos[] {new(0,2), new(1,2), new (2,2), new(3,2)},  //secondo stato di rotazione
             new Pos[] {new(2,0), new(2,1), new (2,2), new(2,3)},  //terzo stato di rotazione
             new Pos[] {new(0,1), new(1,1), new (2,1), new(3,1)},  //quarto stato di rotazione
        };
        
        protected override Pos[][] Blocchetto => blocchetti;  //in base alla rotazione grazie al get nella classe Blocco varierà la posizione dei blocchetti
        public override int IDBlocco => 1; //identificatore del blocco quando userò il random per estrarre casualmente
        protected override Pos InizioOffset => new Pos(-1,3);   //posizione iniziale
    }
}
