using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Blocco
    {
        protected abstract Posizione[][] Piastra { get; }

        protected abstract Posizione InizioOffset { get; }
        public abstract int ID { get; }

        private int rotazione;
        private Posizione offset;

        public Blocco()
        {
            offset = new Posizione(InizioOffset.Riga, InizioOffset.Colonna);
        }

        public IEnumerable<Posizione> PosizionePiastra()
        {
            foreach(Posizione p in Piastra[rotazione])
            {
                yield return new Posizione(p.Riga+offset.Riga,p.Colonna+offset.Colonna);
            } 
        }

        public void MetodoRotazione1()
        {
            rotazione = (rotazione + 1) % Piastra.Length;
        }

        public void MetodoRotazione2()
        {
            if (rotazione == 0)
            {
                rotazione = Piastra.Length - 1;
            }
            else
            {
                rotazione--;
            }
        }

        public void Movimento(int riga,int colonna)
        {
            offset.Riga = riga;
            offset.Colonna=colonna;
        }

        public void Reset()
        {
            rotazione = 0;
            offset.Riga = InizioOffset.Riga;
            offset.Colonna = InizioOffset.Colonna;
        }
    }
}
