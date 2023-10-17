using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    public abstract class Allatok
    {
        protected static int Id = 0;
        public bool Halott { get; set; }
        public int Mutato { get; init; }
        public int PozX { get; set; }
        public int PozY { get; set; }
        public char FuErtek { get; set; }
        public int Jollakottsag { get; set; }

        protected static readonly Random random = new Random();

        protected Allatok(int x, int y, char fuertek)
        {
            Mutato = ++Id;
            PozX = x;
            PozY = y;
            FuErtek = fuertek;
            Jollakottsag = 3; //Éhség kezdőérték
            Halott = false;
        }

        public void Ehezik()
        {
            Jollakottsag--;
            if (Jollakottsag == 0)
            {
                Halott = true;
            }
        }

        public void Meghalt(char[,] matrix, List<Allatok> allatok)
        {
            if (Halott)
            {
                allatok.Remove(this);
                matrix[PozX, PozY] = FuErtek;
            }

        }

        public abstract void Eszik(char[,] matrix, List<Allatok> allat);
        public abstract void Mozog(char[,] matrix);
        public abstract void Szaporodik(char[,] matrix, List<Allatok> allat);
    }
}
