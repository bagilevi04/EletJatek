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
            List<Allatok> halottallat = new List<Allatok>();

            foreach (var allat in mozgoAllatok)
            {
                allat.Ehezik();
                allat.Mozog(matrix);
                allat.Eszik(matrix, osszesAllatok);
                allat.Szaporodik(matrix, osszesAllatok, matrix.GetLength(0));
                if (allat.Halott)
                {
                    halottallat.Add(allat);
                }
            }

            foreach (var halott in halottallat)
            {
                halott.Meghalt(matrix, mozgoAllatok);
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
