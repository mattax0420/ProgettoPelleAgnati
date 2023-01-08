using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public abstract class Blocco
    {
        protected abstract Pos[][] Blocchetto { get; } //piastra che costituisce un intera forma
        protected abstract Pos InizioOffset { get; } //posizione iniziale dei blocchi che compongono la forma
        public abstract int IDBlocco { get; } //ID della forma costituita dai blocchetti

        private int StatoRotazione; //rotazione del blocco
        private Pos offset;
        public Blocco()
        {
            offset = new Pos(InizioOffset.Riga, InizioOffset.Colonna);
        }

        public IEnumerable<Pos> BlocchettoPos()       
        {
            foreach (Pos p in Blocchetto[StatoRotazione]) //per ogni rotazione scambio i blocchetti con lo spazio vuoto
            {
                yield return new Pos(p.Riga + offset.Riga, p.Colonna + offset.Colonna); //yield specifica il valore successivo
            }
        }

        public void RotazioneSinistra()
        {
            StatoRotazione = (StatoRotazione + 1) % Blocchetto.Length; //metodo per la rotazione a sinistra
        }
        public void RotazioneDestra()
        {
            if(StatoRotazione == 0)
                StatoRotazione=Blocchetto.Length-1; //metodo per la rotazione a destra
            else
                StatoRotazione--;
        }
        public void Movimento(int rig,int colon) //metodo per lo spostamento verso destra e sinistra
        {
            offset.Riga += rig;
            offset.Colonna += colon;
        }
    }
}
