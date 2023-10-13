using System.Numerics;

Mezo mezo = new Mezo();
Nyul nyul = new Nyul();
Roka roka = new Roka();

MatriX.Kiiras();


Console.ReadLine();
class Mezo
{
    public static int Meret { get; private set; } = 10;
    public static int[,] Fu { get; private set; } = new int[Meret, Meret];
    public Mezo()
    {
        for (int x = 0; x < Meret; x++)
        {
            for (int y = 0; y < Meret; y++)
            {
                Fu[x, y] = 0;
            }
        }
    }
}
class Allat
{
    public static int[,] Matrix { get; protected set; } = new int[Mezo.Meret, Mezo.Meret];
}
class Nyul : Allat
{
    readonly int meret = Mezo.Meret;
    public Nyul()
    {
        Random random = new Random();
        for (int x = 0; x < meret; x++)
        {
            for (int y = 0; y < meret; y++)
            {
                Matrix[x, y] = 0;
            }
        }
    }
}
class Roka : Allat
{
    readonly int meret = Mezo.Meret;
    public Roka()
    {
        Random random = new Random();
        for (int x = 0; x < meret; x++)
        {
            for (int y = 0; y < meret; y++)
            {
                Matrix[x, y] = 0;
            }
        }
    }
}
class MatriX
{
    public static int[,] Matrix { get; private set; } = new int[Mezo.Meret, Mezo.Meret];
    public static void Kiiras()
    {
        for (int x = 0; x < Mezo.Meret; x++)
        {
            for (int y = 0; y < Mezo.Meret; y++)
            {
                Matrix[x, y] = Mezo.Fu[x, y];
                Matrix[x, y] = Nyul.Matrix[x, y];
                Matrix[x, y] = Roka.Matrix[x, y];
            }
        }
        for (int x = 0; x < Mezo.Meret; x++)
        {
            for (int y = 0; y < Mezo.Meret; y++)
            {
                Console.Write(Matrix[x, y]);
            }
            Console.WriteLine();
        }
    }
}