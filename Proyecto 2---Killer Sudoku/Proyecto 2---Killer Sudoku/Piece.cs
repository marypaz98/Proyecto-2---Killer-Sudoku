using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2___Killer_Sudoku
{
    class Piece
    {
        int Figure; //1= Letra I, 2= Letra L, 3= Letra J, 4= Letra O, 5= Letra T, 6= Letra S, 7=Letra Z, 8= solo un cuadro 
        int symbol; //1= suma, 2=multiplicación
        int[] cell1= new int[2];
        int[] cell2 = new int[2];
        int[] cell3 = new int[2];
        int[] cell4 = new int[2];

        public Piece(int fig, int symb, int row1, int clm1, int row2, int clm2, int row3, int clm3, int row4, int clm4)
        {
            this.Figure = fig;
            this.symbol = symb;
            this.cell1[0] = row1;
            this.cell1[1] = clm1;
            this.cell2[0] = row2;
            this.cell2[1] = clm2;
            this.cell3[0] = row3;
            this.cell3[1] = clm3;
            this.cell4[0] = row4;
            this.cell4[1] = clm4;
        }
    }
}
