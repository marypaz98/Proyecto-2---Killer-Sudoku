using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2___Killer_Sudoku
{
    class savePossibilities
    {
        public List<int[]> pos;
        public int resultado;
        public int simbolo;
        public savePossibilities(int r, int s,List<int[]> p)
        {
            pos = p;
            resultado = r;
            simbolo = s;
        }
    }
}
