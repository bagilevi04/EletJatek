using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EletJatek
{
    public class Szimulacio
    {
        private void Fu(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case '0':
                            matrix[i, j] = '1';
                            break;
                        case '1':
                            matrix[i, j] = '2';
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void AllatokAKorben(char[,] matrix, List<Allatok> mozgoAllatok, List<Allatok> osszesAllatok)
        {
            foreach (var allat in mozgoAllatok)
            {
                allat.Ehezik();
                if (allat.Halott)
                {
                    allat.Meghalt(matrix, osszesAllatok);
                    continue;
                }
                allat.Szaporodik(matrix, osszesAllatok);
                allat.Mozog(matrix);
                allat.Eszik(matrix, osszesAllatok);
            }
        }
        public void Kor(char[,] matrix, List<Allatok> allatok)
        {
            AllatokAKorben(matrix, allatok.Where(x => x is Nyul).ToList(), allatok);
            AllatokAKorben(matrix, allatok.Where(x => x is Roka).ToList(), allatok);
            Fu(matrix);
        }
    }
}
