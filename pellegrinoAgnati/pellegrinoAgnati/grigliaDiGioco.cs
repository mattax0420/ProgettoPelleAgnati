using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class grigliaDiGioco
    {
        /*
         la griglia è un array bidimensionale , ci salvo la posizione dei blocchi solo una volta incastrati , durante la caduta non ne tengo traccia ,
         
         */
        private readonly int[,] grid;        // 0--> cella vuota , poi un numero per ogni colore dei blocchi (spazi occupati da un blocco rosso avranno un numero(es 3 ) spazi occupati da un blocco azzurro es.2)


        public int NRighe { get; set; }
        public int NColonne { get; set; }



        /*
         * 
         * PER ACCEDERE IN MODO PIU COMODO ALLE CELLE DELLA GRID (
         * 
         * ES.   IN CLASS GAMESTATE NEL METODO PER PIAZZARE UN BLOCCO       grid[pos.Riga, pos.Colonna] = bloccoCorrente.IDBlocco;   
         * 
         * )
         */
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }


        public grigliaDiGioco()
        {
            NRighe = 20;
            NColonne = 10;
        }
        public grigliaDiGioco(int NRighe, int NColonne) // potrei giocare a una versione con una griglia di dimensioni diverse
        {
            this.NRighe = NRighe;
            this.NColonne = NColonne;
            grid = new int[NRighe, NColonne];
        }

        //vedo se una cella è vuota o occupata
        public bool isEmpty(int r, int c)
        {
            return r >= 0 && r < NRighe && c >= 0 && c < NColonne && grid[r, c] == 0;
        }


        /*CRITERIO CANCELLAZIONE DELLE RIGHE
         * 
         uso un contatore per tenere traccia delle righe che ho cancellato , quando cade un blocco controllo dal basso verso l alto se la riga è piena, 
        se è piena la cancello , e la riga sopra , anche se non piena dovrà "cadere" di n riga , e così via dovranno scalare tutte le righe di -n , dove n è 
         il valore assunto dal contatore(n di righe cancellate e che devo scalare)
         
         */
        public int getNRowCancellate()
        {
            int cancellate = 0;
            for (int r = NRighe - 1; r >= 0; r--)        //dal basso verso l'alto
            {
                if (isFull(r))
                {
                    deleteRow(r);
                    cancellate++;
                }
                else if (cancellate > 0)
                {
                    abbassaRow(r, cancellate);
                    //score++
                }
                    
            }

            return cancellate;
        }
        //1 -> controllo se riga piena 
        public bool isFull(int r)
        {
            bool ret = true;
            for (int c = 0; c < NColonne; c++)
                if (grid[r, c] == 0)
                    ret = false;
            return ret;
        }
        //2->analogamente per lo stesso motivo controllo se è vuota 
        public bool isRowEmpty(int r)
        {
            bool ret = true;
            for (int c = 0; c < NColonne; c++)
                if (grid[r, c] != 0)
                    ret = false;
            return ret;
        }
        //3-> cancello ua riga quando sarà piena
        public void deleteRow(int r)
        {
            for (int c = 0; c < NColonne; c++)
                grid[r, c] = 0;

        }
        //4->sposto la riga in basso 
        public void abbassaRow(int r, int quanto)
        {
            for (int c = 0; c < NColonne; c++)
            {
                grid[r + quanto, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

    }
}
