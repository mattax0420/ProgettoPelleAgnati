using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class EstraiBlocco
    {
        private Blocco[] blocchi = new Blocco[]    //inizializzo tutti i blocchi che andrò ad estrarre con il random
        {
            new BloccoI(),
            new BloccoJ(),
            new BloccoL(),
            new BloccoO(),
            new BloccoS(),
            new BloccoT(),
            new BloccoZ(),
        };

        private Random randomizza = new Random();

        public Blocco prossimoBlocco { get; private set; }

        public EstraiBlocco()
        {
             prossimoBlocco = BloccoCasuale();  //estrae il prossimo blocco
        }

        private Blocco BloccoCasuale()
        {
            return blocchi[randomizza.Next(blocchi.Length)];    //estrae il blocco
        }

        public Blocco Aggiorna()    //aggiorna l'estrazione
        {
            Blocco blocco = prossimoBlocco;

            do
            {
                prossimoBlocco = BloccoCasuale();
            }
            while (blocco.IDBlocco == prossimoBlocco.IDBlocco);

            return blocco;
        }

    }
}
