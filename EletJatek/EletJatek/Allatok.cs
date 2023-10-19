using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    public abstract class Allatok
    {
        static int Id = 0;
        public bool Halott { get; set; }
        public int Mutato { get; init; }
        public int PozX { get; set; }
        public int PozY { get; set; }
        public char FuErtek { get; set; }
        public int Jollakottsag { get; set; }

        private static readonly Random random = new Random();

        protected int KovPoz => random.Next(1, 5);
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

        protected bool Bekovetkezette(int szazalek)
        {
            return random.Next(0, 100) < szazalek;
        }

        public void Meghalt(char[,] matrix, List<Allatok> allatok)
        {
            matrix[PozX, PozY] = FuErtek;
            allatok.Remove(this);
        }

        public abstract void Eszik(char[,] matrix, List<Allatok> allat);
        public abstract void Mozog(char[,] matrix);
        public abstract void Szaporodik(char[,] matrix, List<Allatok> allat);
    }
}
