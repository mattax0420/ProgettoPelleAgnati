using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class gameState
    {
        //full prop per blocco corrente
        private Blocco bloccoCorrente;

        public Blocco BloccoCorrente
        {
            get => bloccoCorrente;
            private set
            {
                bloccoCorrente = value;
                //quando aggiorno il bloccoCorrente chiamo reset così setto la posizione iniiziale corretta 
                bloccoCorrente.Reset();
            }
        }

        public grigliaDiGioco grid { get; set; }    //NB--> dava errore perchè grigliaDiGioco era internal e non pubblico 
        public randomGeneratoreBlocchi queue { get; set; }
        public bool GameOVer { get; private set; }

        public gameState()
        {
            grid = new grigliaDiGioco(22, 10);
            queue = new randomGeneratoreBlocchi();
            bloccoCorrente = queue.GetAndUpdate();
        }





        /*
         * CONTROLLO 
         Idea 
            giriamo il blocco, se finisce in una pos ambigua tipo fuori dalla grid lo rigiriamo 
         */
        //ROTAZIONE
        public void rotateOrario()
        {
            bloccoCorrente.RotazioneDestra();

            //controllo per ogni tile che compone la forma se ha posizionamento ambiguo tipo fuori dalla grid  --> SPOSTO IN UN METODO 
            /* foreach (Pos p in bloccoCorrente.BlocchettoPos())
             {
                 if (!grid.isEmpty(p.Riga, p.Colonna))
                 {
                     bloccoCorrente.RotazioneSinistra();
                 }
             }*/
            if (!chkPosition())
            {
                bloccoCorrente.RotazioneSinistra();
            }


        }

        //analogo
        public void rotateAntiOrario()
        {
            bloccoCorrente.RotazioneSinistra();
            if (!chkPosition())
            {
                bloccoCorrente.RotazioneDestra();
            }


        }

        //SPOSTAMENTO

        public void moveSinistra()
        {
            bloccoCorrente.Movimento(0, -1);
            if (!chkPosition())
            {
                bloccoCorrente.Movimento(0, 1);
            }
        }
        //analogo
        public void moveDestra()
        {
            bloccoCorrente.Movimento(0, 1);
            if (!chkPosition())
            {
                bloccoCorrente.Movimento(0, -1);
            }
        }


        //come gli altri , però se non è possibile muovere verso il basso il blocco , viene fatto scendere un blocco nuovo
        public void moveGiu()
        {
            bloccoCorrente.Movimento(1, 0);
            if (!chkPosition())
            {
                bloccoCorrente.Movimento(-1, 0);
                piazzaBlocco();
            }
        }










        //metodi utili 

        private bool chkPosition()
        {
            foreach (Pos pos in bloccoCorrente.BlocchettoPos())
            {
                if (!grid.isEmpty(pos.Riga, pos.Colonna))
                    return false;
            }
            return true;
        }

        private bool isGameOver()
        {
            return !(grid.isRowEmpty(0) && grid.isRowEmpty(1));
        }
        private void piazzaBlocco()
        {
            foreach (Pos pos in bloccoCorrente.BlocchettoPos())
            {
                grid[pos.Riga, pos.Colonna] = bloccoCorrente.IDBlocco;
            }
            grid.getNRowCancellate();
            if (isGameOver())
            {
                GameOVer = true;
            }
            else
            {
                bloccoCorrente = queue.GetAndUpdate();
            }

        }
    }
}
