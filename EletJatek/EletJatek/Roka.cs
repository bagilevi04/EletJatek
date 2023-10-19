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
            Jollakottsag = 10; //Éhség kezdőérték
        }

        public override void Eszik(char[,] matrix, List<Allatok> allat)
        {
            int maxjollakottsag = 10;
            if (Jollakottsag != maxjollakottsag)
            {
                switch (FuErtek)
                {
                    case 'N':
                        Jollakottsag += 3;
                        var nyul = allat.Find(x => this.PozX == x.PozX && this.PozY == x.PozY && x is Nyul);
                        if (nyul is null)
                        {
                            break;
                        }
                        else
                        {
                            nyul.Meghalt(matrix, allat);
                            FuErtek = nyul.FuErtek;
                        }
                        break;
                    default:
                        break;
                }
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
            else if (PozY + 1 < meret && matrix[PozX, PozY + 1] == 'N')
            {
                UjPozX++;
            }
            else
            {
                switch (KovPoz)
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
            if (UjPozX < 0 || UjPozX >= meret || UjPozY < 0 || UjPozY >= meret || matrix[UjPozX, UjPozY] == 'R')
            {
                return;
            }

            matrix[PozX, PozY] = FuErtek;
            
            PozX = UjPozX;
            PozY = UjPozY;
            FuErtek = matrix[UjPozX, UjPozY];
            matrix[UjPozX, UjPozY] = 'R';
        }

        public override void Szaporodik(char[,] matrix, List<Allatok> allat)
        {
            if (!Bekovetkezette(25)) { return; }
            if (PozX + 1 < matrix.GetLength(0) && matrix[PozX + 1, PozY] == 'R')
            {
                if (PozX - 1 > 0 && matrix[PozX - 1, PozY] != 'R' && matrix[PozX - 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX - 1, PozY, FuErtek));
                    matrix[PozX - 1, PozY] = 'R';
                }
                else if (PozY - 1 > 0 && matrix[PozX, PozY - 1] != 'R' && matrix[PozX, PozY - 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY - 1, FuErtek));
                    matrix[PozX, PozY - 1] = 'R';
                }
                else if (PozY + 1 < matrix.GetLength(0) && matrix[PozX, PozY + 1] != 'R' && matrix[PozX, PozY + 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY + 1, FuErtek));
                    matrix[PozX , PozY + 1] = 'R';
                }
            }
            else if (PozY + 1 < matrix.GetLength(0) && matrix[PozX, PozY + 1] == 'R')
            {
                if (PozX - 1 > 0 && matrix[PozX - 1, PozY] != 'R' && matrix[PozX - 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX - 1, PozY, FuErtek));
                    matrix[PozX - 1, PozY] = 'R';
                }
                else if (PozY - 1 > 0 && matrix[PozX, PozY - 1] != 'R' && matrix[PozX, PozY - 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY - 1, FuErtek));
                    matrix[PozX, PozY - 1] = 'R';
                }
                else if (PozX + 1 < matrix.GetLength(0) && matrix[PozX + 1, PozY] != 'R' && matrix[PozX + 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX + 1, PozY, FuErtek));
                    matrix[PozX + 1, PozY] = 'R';
                }
            }
            else if (PozX - 1 > 0 && matrix[PozX - 1, PozY] == 'R')
            {
                if (PozY + 1 < matrix.GetLength(0) && matrix[PozX, PozY + 1] != 'R' && matrix[PozX, PozY + 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY + 1, FuErtek));
                    matrix[PozX, PozY + 1] = 'R';
                }
                else if (PozY - 1 > 0 && matrix[PozX, PozY - 1] != 'R' && matrix[PozX, PozY - 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY - 1, FuErtek));
                    matrix[PozX, PozY - 1] = 'R';
                }
                else if (PozX + 1 < matrix.GetLength(0) && matrix[PozX + 1, PozY] != 'R' && matrix[PozX + 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX + 1, PozY, FuErtek));
                    matrix[PozX + 1, PozY] = 'R';
                }
            }
            else if (PozY - 1 > 0 && matrix[PozX, PozY - 1] == 'R')
            {
                if (PozX - 1 > 0 && matrix[PozX - 1, PozY] != 'R' && matrix[PozX - 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX - 1, PozY, FuErtek));
                    matrix[PozX - 1, PozY] = 'R';
                }
                else if (PozY + 1 < matrix.GetLength(0) && matrix[PozX, PozY + 1] != 'R' && matrix[PozX, PozY + 1] != 'N')
                {
                    allat.Add(new Roka(PozX, PozY + 1, FuErtek));
                    matrix[PozX, PozY + 1] = 'R';
                }
                else if (PozX + 1 < matrix.GetLength(0) && matrix[PozX + 1, PozY] != 'R' && matrix[PozX + 1, PozY] != 'N')
                {
                    allat.Add(new Roka(PozX + 1, PozY, FuErtek));
                    matrix[PozX + 1, PozY] = 'R';
                }
            }
        }
    }
}