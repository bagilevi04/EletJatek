using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EletJatek
{
    public class Szimulacio
    {
        public void Kor(char[,] matrix, List<Nyul> nyulak)
        {
            foreach (var nyul in nyulak)
            {
                nyul.NyulMozog(matrix);
            }

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
    }
}
