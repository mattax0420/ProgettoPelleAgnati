using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class StatoGioco
    {
        private Blocco bloccoAttuale;
        
        public Blocco BloccoAttuale
        {
            get => bloccoAttuale;
            private set
            {
                bloccoAttuale = value;
                bloccoAttuale.Reset();
            }
        }

        public Griglia grigliaGioco { get; }
        public BloccoInCoda bloccoInCoda { get; }
        public bool Sconfitta { get; private set; }

        public StatoGioco()
        {
            grigliaGioco = new Griglia(22, 10);
            bloccoInCoda = new BloccoInCoda();
            BloccoAttuale = bloccoInCoda.Aggiorna();
        }

        private bool Incastro()
        {
            foreach (Posizione p in BloccoAttuale.PosizionePiastra())
            {
                if (!grigliaGioco.Vuoto(p.Riga, p.Colonna))
                {
                    return false;
                }
            }
            return true;
        }

        public void RuotaBlocco1()
        {
            BloccoAttuale.MetodoRotazione1();
            if (!Incastro())
            {
                BloccoAttuale.MetodoRotazione2();
            }
        }
        public void RuotaBlocco2()
        {
            BloccoAttuale.MetodoRotazione2();
            if (!Incastro())
            {
                BloccoAttuale.MetodoRotazione1();
            }
        }

        public void Sinistra()
        {
            BloccoAttuale.Movimento(0, -1);
            if (!Incastro())
            {
                BloccoAttuale.Movimento(0, 1);
            }
        }
        public void Destra()
        {
            BloccoAttuale.Movimento(0, 1);
            if (!Incastro())
            {
                BloccoAttuale.Movimento(0, -1);
            }
        }

        private bool GameOver()
        {
            return !(grigliaGioco.RigaVuota(0) && grigliaGioco.RigaVuota(1));
        }

        private void PiazzaBlocco()
        {
            foreach (Posizione p in BloccoAttuale.PosizionePiastra())
            {
                grigliaGioco[p.Riga, p.Colonna] = BloccoAttuale.ID;
            }
            grigliaGioco.PulisciRiga();

            if (GameOver())
            {
                Sconfitta = true;
            }
            else
            {
                BloccoAttuale = bloccoInCoda.Aggiorna();
            }
        }

        public void InBasso()
        {
            BloccoAttuale.Movimento(1, 0);

            if (!Incastro())
            {
                BloccoAttuale.Movimento(-1, 0);
                PiazzaBlocco();
            }
        }

    }
}
