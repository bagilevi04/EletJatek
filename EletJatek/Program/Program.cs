using System.Threading;
using EletJatek;

List<Allatok> allatok = new List<Allatok>();
Szimulacio szimulacio = new Szimulacio();
int MatrixMeret = 10;
int korok = 20;
char[,] matrix = new char[MatrixMeret, MatrixMeret];
Random r = new Random();
int kezdoHelyNyul = 4;
int kezdoHelyRoka = 5;


for (int i = 0; i < MatrixMeret; i++)
{
    for (int j = 0; j < MatrixMeret; j++)
    {
        matrix[i, j] = '0';
    }
}

allatok.Add(new Nyul(kezdoHelyNyul, kezdoHelyNyul, '0'));
allatok.Add(new Nyul(kezdoHelyNyul, kezdoHelyNyul + 1, '0'));
allatok.Add(new Roka(kezdoHelyRoka, kezdoHelyRoka, '0', '0'));
allatok.Add(new Roka(kezdoHelyRoka, kezdoHelyRoka + 1, '0', '0'));

matrix[kezdoHelyNyul, kezdoHelyNyul] = 'N';
matrix[kezdoHelyNyul, kezdoHelyNyul + 1] = 'N';
matrix[kezdoHelyRoka, kezdoHelyRoka] = 'R';
matrix[kezdoHelyRoka, kezdoHelyRoka + 1] = 'R';

Kiiras(matrix, MatrixMeret);

for (int i = 0; i < korok; i++)
{
    Thread.Sleep(1000);
    szimulacio.Kor(matrix, allatok);
    Kiiras(matrix, MatrixMeret);
}

void Kiiras(char[,] matrix, int meret)
{
    Console.Clear();
    for (int i = 0; i < meret; i++)
    {
        for (int j = 0; j < meret; j++)
        {
            Console.Write(" " + matrix[i, j]);
        }
        Console.WriteLine();
    }
}
