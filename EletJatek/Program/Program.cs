﻿using System.Threading;
using EletJatek;

List<Allatok> allatok = new List<Allatok>();
Szimulacio szimulacio = new Szimulacio();
int MatrixMeret = 25;
int korok = 20;
char[,] matrix = new char[MatrixMeret, MatrixMeret];
Random r = new Random();
int kezdoHely = r.Next(MatrixMeret / 2, MatrixMeret - 1);


for (int i = 0; i < MatrixMeret; i++)
{
    for (int j = 0; j < MatrixMeret; j++)
    {
        matrix[i, j] = '0';
    }
}

allatok.Add(new Nyul(kezdoHely, kezdoHely, '0'));
allatok.Add(new Nyul(kezdoHely, kezdoHely + 1, '0'));
allatok.Add(new Roka(kezdoHely, kezdoHely, '0'));
allatok.Add(new Roka(kezdoHely, kezdoHely + 1, '0'));

matrix[kezdoHely, kezdoHely] = 'N';
matrix[kezdoHely, kezdoHely + 1] = 'N';

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
