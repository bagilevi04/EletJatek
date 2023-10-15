using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletJatek
{
    internal class Roka : Allatok
    {
        public Roka(int x, int y, char fuertek) : base(x, y, fuertek)
        {
        }

        public override void Eszik(char[,] matrix)
        {
            throw new NotImplementedException();
        }

        public override void Mozog(char[,] matrix)
        {
            throw new NotImplementedException();
        }
    }
}
