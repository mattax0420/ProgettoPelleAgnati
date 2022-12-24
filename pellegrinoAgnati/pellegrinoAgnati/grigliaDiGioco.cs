using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    internal class grigliaDiGioco
    {
        private int[,] grid;  //metto la virgola nelle quadre per non avere la grid vuota inizialmente perchè provocherebbe errori
        public int Righe { get; set; }
        public int Colonne { get; set; }

        public int this[int r,int c]
        {
            get => grid[r, c];
            set => grid[r,c] = value;
        }

        //costruttore
        public grigliaDiGioco(int righe,int colonne)
        {
            Righe = righe;
            Colonne = colonne;
            grid = new int[righe, colonne]; //creo una griglia con i parametri passati nel costruttore
        }

        public bool controlloDentroGriglia(int r,int c)
        {
            return r >= 0 && r < Righe && c >= 0 && c < Colonne; //controllo se le righe e le colonne sono all'interno della griglia
        }

    }
}
