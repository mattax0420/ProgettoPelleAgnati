using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Griglia
    {
        private readonly int[,] grid;

        public int Riga { get; }
        public int Colonna { get; }

        public int this[int r, int c]
        {
            get=> grid[r, c];
            set => grid[r, c] = value;   
        }

        public Griglia(int riga,int colonna)
        {
            this.Riga = riga;   
            this.Colonna = colonna;
            grid = new int[riga, colonna];
        }

        public bool Pieno(int r,int c)
        {
            return r >= 0 && r<Riga && c >= 0 && c<Colonna;
        }

        public bool Vuoto(int r,int c)
        {
            return Pieno(r, c) && grid[r, c] == 0;
        }

        public bool RigaPiena(int r)
        {
            for(int c=0;c<Colonna; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool RigaVuota(int r)
        {
            for (int c = 0; c < Colonna; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void CancellaRigaPiena(int r)
        {
            for(int c = 0; c < Colonna; c++)
            {
                grid[r,c] = 0;
            }
        }

        private void SpostaRiga(int r,int numeroRiga)
        {
            for(int c = 0; c < Colonna; c++)
            {
                grid[r + numeroRiga, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int PulisciRiga()
        {
            int cleared=0;
            for(int r = Riga - 1; r >= 0; r--)
            {
                if (RigaPiena(r))
                {
                    CancellaRigaPiena(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    SpostaRiga(r, cleared);
                }
            }
            return cleared;
        }
    }
}
