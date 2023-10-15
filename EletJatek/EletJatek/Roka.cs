using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    public class Roka : Allatok
    {
        public Roka(int x, int y, char fuertek) : base(x, y, fuertek)
        {
        }

        public override void Eszik(char[,] matrix)
        {
            throw new NotImplementedException();
        }

        public override void Mozog(char[,] matrix)
        {
            int meret = matrix.GetLength(0);
            int UjPozX = PozX;
            int UjPozY = PozY;
            int mozog = random.Next(1, 5);

            switch (mozog)
            {
                case 1:
                    if (PozX + 2 < meret)
                    {
                        UjPozX += 2;
                    }
                    break;
                case 2:
                    if (PozX - 2 >= 0)
                    {
                        UjPozX -= 2;
                    }
                    break;
                case 3:
                    if (PozY + 2 < meret)
                    {
                        UjPozY += 2;
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

        
    }
}
