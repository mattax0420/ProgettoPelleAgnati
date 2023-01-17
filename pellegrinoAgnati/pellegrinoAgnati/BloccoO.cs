using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class BloccoO : Blocco
    {
        private Pos[][] blocchetti = new Pos[][]
        {
            new Pos[] { new(0,0),new(0,1),new(1,0),new(1,1) } //unico stato di rotazione del blocco quadrato
        };
        public override int IDBlocco => 4; //identificatore per il random

        protected override Pos[][] Blocchetto => blocchetti; //in base alla rotazione grazie al get nella classe Blocco varierà la posizione dei blocchetti

        protected override Pos InizioOffset => new Pos(0,4); //posizione iniziale
        override public BloccoO getInstance()
        {
            return new BloccoO();
        }
    }
}
