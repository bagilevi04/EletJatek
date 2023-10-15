using System.Threading;
using EletJatek;

List<Nyul> nyulak = new List<Nyul>();
Szimulacio szimulacio = new Szimulacio();
int MatrixMeret = 25;
int korok = 10;
char[,] matrix = new char[MatrixMeret, MatrixMeret];
Random r = new Random();
int kezdoHely = r.Next(MatrixMeret, MatrixMeret / 2);
nyulak.Add(new Nyul(kezdoHely, kezdoHely));
nyulak.Add(new Nyul(kezdoHely + 1, kezdoHely));
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
