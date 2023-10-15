using System.Threading;
using EletJatek;

List<Nyul> nyulak = new List<Nyul>();
Szimulacio szimulacio = new Szimulacio();
int MatrixMeret = 25;
int korok = 10;
Console.WriteLine("Hány nyullal szeretné kezdeni a szimulációt?: ");
int kezdonyulak = int.Parse(Console.ReadLine());
for (int i = 0; i < kezdonyulak; i++)
{
    nyulak.Add(new Nyul(i, i));
}
char[,] matrix = new char[MatrixMeret, MatrixMeret];
for (int i = 0; i < MatrixMeret; i++)
{
    for (int j = 0; j < MatrixMeret; j++)
    {
        matrix[i, j] = '0';
    }
}
Kiiras(matrix, MatrixMeret);
for (int i = 0; i < korok; i++)
{
    Thread.Sleep(1000);
    szimulacio.Kor(matrix, nyulak);
    Kiiras(matrix, MatrixMeret);
}

// nyulak.Add(new Nyul(i, j));

void Kiiras(char[,] matrix, int meret)
{
    Console.Clear();
    for (int i = 0; i < meret; i++)
    {
        for (int j = 0; j < meret; j++)
        {
            Console.Write(matrix[i, j]);
        }
        Console.WriteLine();
    }
}
