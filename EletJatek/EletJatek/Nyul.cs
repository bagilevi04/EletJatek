namespace EletJatek
{
    public class Nyul
    {
        static int Id = 0;
        public int mutato { get; init; }
        public int NyPozX { get; set; }
        public int NyPozY { get; set; }
        public int Hunger { get; set; }
        public char FuErtek { get; set; }
        
        private static readonly Random random = new Random();

        public Nyul(int x, int y, char fuertek)
        {
            mutato = ++Id;
            NyPozX = x;
            NyPozY = y;
            Hunger = 5; //Éhség kezdőérték
            FuErtek = fuertek;
        }

        public void NyulMozog(char[,] matrix)
        {
            int meret = matrix.GetLength(0);
            int UjPozX = NyPozX;
            int UjPozY = NyPozY;
            int mozog = random.Next(1, 5);
            
            switch (mozog)
            {
                case 1:
                    if (NyPozX + 1 < meret)
                    {
                        UjPozX += 1;
                    }
                    break;
                case 2:
                    if (NyPozX - 1 >= 0)
                    {
                        UjPozX -= 1;
                    }
                    break;
                case 3:
                    if (NyPozY + 1 < meret)
                    {
                        UjPozY += 1;
                    }
                    break;
                case 4:
                    if (NyPozY - 1 >= 0)
                    {
                        UjPozY -= 1;
                    }
                    break;
                default:
                    break;
            }
            if (UjPozX == NyPozX && UjPozY == NyPozY)
            {
                return;
            }
            if (matrix[UjPozX, UjPozY] == 'N')
            {
                return;
            }
            matrix[NyPozX, NyPozY] = FuErtek;
            NyPozX = UjPozX;
            NyPozY = UjPozY;
            FuErtek = matrix[UjPozX, UjPozY];
            matrix[UjPozX, UjPozY] = 'N';
        }
    }
}