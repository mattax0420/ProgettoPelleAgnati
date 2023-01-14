using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    //classe che genera il prossimo blocco che cadrà
    /*
     queue è un array con tutte le forme 
     getRandom ne randomizza una 
     
     */
    public class randomGeneratoreBlocchi
    {
        private readonly Blocco[] queue = new Blocco[]
        {
            new BloccoI(),
            new BloccoJ(),
            new BloccoL(),
            new BloccoO(),
            new BloccoS(),
            new BloccoT(),
            new BloccoZ()
        };
        /*NB
         questo è il blocco che vedrà il giocatore nella imageBox del blocco che sta arrivando 
         */
        public Blocco next { get; set; }

        private readonly Random random = new Random();


        private Blocco getRandom()
        {
            return queue[random.Next(queue.Length)];
        }

        /*
         
         */
        public Blocco getAndUpdate()
        {
            Blocco blocco = next;

            do
            {
                next = getRandom();
            } while (blocco.IDBlocco == next.IDBlocco); //STESSA FORMA
            return blocco;
        }
//costr
        public randomGeneratoreBlocchi()
        {
            next= getRandom();
        }



    }
}
