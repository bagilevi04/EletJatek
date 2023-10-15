namespace EletJatek
{
    public class Nyul
    {
        static int Id = 0;
        public int mutato { get; init; }
        public int PozX { get; set; }
        public int PozY { get; set; }
        public int Hunger { get; set; }
        public char FuErtek { get; set; }

        public Nyul(int x, int y)
        {
            mutato = ++Id;
            PozX = x;
            PozY = y;
            Hunger = 5; //Éhség kezdőérték
        }
    }
}