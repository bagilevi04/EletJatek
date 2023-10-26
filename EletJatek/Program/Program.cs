using System.Threading;
using EletJatek;

List<Allatok> allatok = new List<Allatok>();
Szimulacio szimulacio = new Szimulacio();
int MatrixMeret = 25;
int korok = 1000;
char[,] matrix = new char[MatrixMeret, MatrixMeret];
Random r = new Random();
int kezdoHelyNyul = r.Next(MatrixMeret / 2, MatrixMeret - 1);
int kezdoHelyRoka = r.Next(0, MatrixMeret / 2 - 1);


for (int i = 0; i < MatrixMeret; i++)
{
    for (int j = 0; j < MatrixMeret; j++)
    {
        matrix[i, j] = '0';
    }
}

allatok.Add(new Nyul(kezdoHelyNyul, kezdoHelyNyul, '0'));
allatok.Add(new Nyul(kezdoHelyNyul, kezdoHelyNyul + 1, '0'));
allatok.Add(new Roka(kezdoHelyRoka, kezdoHelyRoka, '0'));
allatok.Add(new Roka(kezdoHelyRoka, kezdoHelyRoka + 1, '0'));

matrix[kezdoHelyNyul, kezdoHelyNyul] = 'N';
matrix[kezdoHelyNyul, kezdoHelyNyul + 1] = 'N';
matrix[kezdoHelyRoka, kezdoHelyRoka] = 'R';
matrix[kezdoHelyRoka, kezdoHelyRoka + 1] = 'R';

Kiiras(matrix, MatrixMeret);

while (allatok.Where(x => x is Nyul).ToList().Count != 0 && allatok.Where(x => x is Roka).ToList().Count != 0)
{
    Thread.Sleep(300);
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
            switch (matrix[i, j])
            {
                case '0':
                    Console.Write("0", Console.BackgroundColor = ConsoleColor.DarkCyan);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case '1':
                    Console.Write("1", Console.BackgroundColor = ConsoleColor.DarkGreen);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case '2':
                    Console.Write("2", Console.BackgroundColor = ConsoleColor.Green);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'N':
                    Console.Write("N", Console.BackgroundColor = ConsoleColor.Gray);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 'R':
                    Console.Write("R", Console.BackgroundColor = ConsoleColor.Red);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine();
    }
}
