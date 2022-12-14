using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BloccoInCoda
    {
        private readonly Blocco[] blocchi = new Blocco[]
        {
            new IBlocco(),
            new JBlocco(),
            new LBlocco(),
            new OBlocco(),
            new SBlocco(),
            new TBlocco(),
            new ZBlocco()
        };

        private readonly Random rnd = new Random();
        public Blocco ProssimoBlocco { get; set; }

        public BloccoInCoda()
        {
            ProssimoBlocco = BloccoRnd();
        }
        private Blocco BloccoRnd()
        {
            return blocchi[rnd.Next(blocchi.Length)];
        }

        public Blocco Aggiorna()
        {
            Blocco blocco = ProssimoBlocco;

            do
            {
                ProssimoBlocco = BloccoRnd();
            }
            while (blocco.ID == ProssimoBlocco.ID);

            return blocco;
        }
    }
}
