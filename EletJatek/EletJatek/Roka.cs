using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    public class Roka : Allatok
    {
        public char NyulErtek { get; set; }
        public Roka(int x, int y, char fuertek, char nyul) : base(x, y, fuertek)
        {
            Mutato = ++Id;
            PozX = x;
            PozY = y;
            FuErtek = fuertek;
            Ehseg = 10; //Éhség kezdőérték
            Halott = false;
            NyulErtek = nyul;
        }

        public override void Eszik(char[,] matrix)
        {
            switch (NyulErtek)
            {
                case 'N':
                    Ehseg += 3;

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
            int mozog = random.Next(1, 9);

            if (PozX++ < meret && PozX++ == 'N')
            {
                UjPozX++;
            }
            else if (PozX-- >= 0 && PozX-- == 'N')
            {
                UjPozX--;
            }
            else if (PozY++ < meret && PozY++ == 'N')
            {
                UjPozY++;
            }
            else if (PozY-- >= 0 && PozY-- == 'N') 
            {
                UjPozY--;
            }
            else if (PozX + 2 < meret && PozX + 2 == 'N')
            {
                UjPozX += 2;
            }
            else if (PozX - 2 >= 0 && PozX - 2 == 'N')
            {
                UjPozX -= 2;
            }
            else if (PozY + 2 < meret && PozY + 2 == 'N')
            {
                UjPozY += 2;
            }
            else if (PozY - 2 >= 0 && PozY - 2 == 'N')
            {
                UjPozY -= 2;
            }
            else if (PozX++ < meret && PozY++ < meret && matrix[PozX++, PozY++] == 'N')
            {
                UjPozX++;
                UjPozY++;
            }
            else if (PozX++ < meret && PozY-- >= 0 && matrix[PozX++, PozY--] == 'N')
            {
                UjPozX++;
                UjPozY--;
            }
            else if (PozX-- >= 0 && PozY++ < meret && matrix[PozX--, PozY++] == 'N')
            {
                UjPozX--;
                UjPozY++;
            }
            else if (PozX-- >= 0 && PozY-- >= 0 && matrix[PozX--, PozY--] == 'N')
            {
                UjPozX--;
                UjPozY--;
            }
            else
            {
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
                    case 5:
                        if (PozX++ < meret && PozY++ < meret)
                        {
                            UjPozX++;
                            UjPozY++;
                        }
                        break;
                    case 6:
                        if (PozX++ < meret && PozY-- >= 0)
                        {
                            UjPozX++;
                            UjPozY--;
                        }
                        break;
                    case 7:
                        if (PozX-- >= 0 && PozY++ < meret)
                        {
                            UjPozX--;
                            UjPozY++;
                        }
                        break;
                    case 8:
                        if (PozX-- >= 0 && PozY-- >= 0)
                        {
                            UjPozX--;
                            UjPozY--;
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
            NyulErtek = matrix[UjPozX, UjPozY];
            matrix[UjPozX, UjPozY] = 'R';
        }
    }
}
