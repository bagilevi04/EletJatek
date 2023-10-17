using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    public class Roka : Allatok
    {
        public Roka(int x, int y, char fuertek, char nyul) : base(x, y, fuertek)
        {
            Mutato = ++Id;
            PozX = x;
            PozY = y;
            FuErtek = fuertek;
            Ehseg = 10; //Éhség kezdőérték
            Halott = false;
        }

        public override void Eszik(char[,] matrix, List<Allatok> allat)
        {
            switch (FuErtek)
            {
                case 'N':
                    Ehseg += 3;
                    var nyul = allat.Find(x => x.PozX == this.PozX && x.PozY == this.PozY && x is Nyul);
                    nyul.Meghalt(matrix, allat);
                    FuErtek = nyul.FuErtek;
                    break;
                default:
                    break;
            }
        }

        public override void Mozog(char[,] matrix)
        {
            int meret = matrix.GetLength(0);
            int UjPozX = PozX;
            int UjPozY = PozY;
            

            if (PozX + 1 < meret && matrix[PozX + 1, PozY] == 'N')
            {
                UjPozX++;
            }
            else if (PozX - 1 >= 0 && matrix[PozX - 1, PozY] == 'N')
            {
                UjPozX--;
            }
            else if (PozY - 1 >= 0 && matrix[PozX, PozY - 1] == 'N') 
            {
                UjPozY--;
            }
            else if (PozY + 1 < meret && matrix[PozX, PozY+1] == 'N')
            {
                UjPozX++;
            }
            else
            {
                switch (random.Next(1, 5))
                {
                    case 1:
                        if (PozX + 2 < meret)
                        {
                            UjPozX += 2;
                        }
                        break;
                    case 2:
                        if (PozY + 2 < meret)
                        {
                            UjPozY += 2;
                        }
                        break;
                    case 3:
                        if (PozX - 2 >= 0)
                        {
                            UjPozX -= 2;
                        }
                        break;
                    case 4:
                        if (PozY - 2 >= 0)
                        {
                            UjPozY -= 2;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (UjPozX == PozX && UjPozY == PozY)
            {
                return;
            }
            if (matrix[UjPozX, UjPozY] == 'R')
            {
                return;
            }

            matrix[PozX, PozY] = FuErtek;
            PozX = UjPozX;
            PozY = UjPozY;
            FuErtek = matrix[UjPozX, UjPozY];
            matrix[UjPozX, UjPozY] = 'R';
        }

        public override void Szaporodik(char[,] matrix)
        {
            if (PozX == 'R')
            {

            }
        }
    }
}
