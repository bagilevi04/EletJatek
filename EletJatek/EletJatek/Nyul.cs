﻿namespace EletJatek
{
    public class Nyul : Allatok
    {
        public Nyul(int x, int y, char fuertek) : base(x, y, fuertek)
        {
            Mutato = ++Id;
            PozX = x;
            PozY = y;
            FuErtek = fuertek;
            Ehseg = 3; //Éhség kezdőérték
            Halott = false;
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
                    if (PozX + 1 < meret)
                    {
                        UjPozX += 1;
                    }
                    break;
                case 2:
                    if (PozX - 1 >= 0)
                    {
                        UjPozX -= 1;
                    }
                    break;
                case 3:
                    if (PozY + 1 < meret)
                    {
                        UjPozY += 1;
                    }
                    break;
                case 4:
                    if (PozY - 1 >= 0)
                    {
                        UjPozY -= 1;
                    }
                    break;
                default:
                    break;
            }
            if (UjPozX == PozX && UjPozY == PozY)
            {
                return;
            }
            if (matrix[UjPozX, UjPozY] == 'N' || matrix[UjPozX, UjPozY] == 'R' || matrix[UjPozX, UjPozY] == '0' || matrix[UjPozX, UjPozY] == '1')
            {
                return;
            }
            matrix[PozX, PozY] = FuErtek;
            PozX = UjPozX;
            PozY = UjPozY;
            FuErtek = matrix[UjPozX, UjPozY];
            matrix[UjPozX, UjPozY] = 'N';
        }

        public override void Eszik(char[,] matrix, List<Allatok> _)
        {
            switch (FuErtek)
            {
                case '0':
                    return;
                case '1':
                    Ehseg++;
                    FuErtek = '0';
                    break;
                case '2':
                    Ehseg += 2;
                    FuErtek = '1';
                    break;
                default:
                    break;
            }
        }

        public override void Szaporodik(char[,] matrix)
        {
            if (PozX++ != 'N' && PozX-- != 'N' && PozY++ != 'N' && PozY-- != 'N')
            {
                return;
            }
            int szuletik = random.Next(1,5);
            switch (szuletik)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}