using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_2___Killer_Sudoku
{
    class File
    {
        TextWriter archivoSudoku;
        public File()
        {

        }
        public void WriteFile(int[,] mat, List<Piece> piezas)
        {
            archivoSudoku = new StreamWriter("killerSudoku.txt");
            string linea = "";
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    linea = String.Concat(linea, mat[f, c], " ");

                }
                archivoSudoku.WriteLine(linea);
                linea = "";
            }
            string otro = "";
            foreach (Piece pieza in piezas)
            {
                if (pieza.Figure != 1)
                {
                    otro = String.Concat("&" ,pieza.Figure, "&", pieza.symbol, "&", pieza.resultado, "&", pieza.cell1[0], "&", pieza.cell1[1]
                        , "&", pieza.cell2[0], "&", pieza.cell2[1], "&", pieza.cell3[0], "&", pieza.cell3[1], "&", pieza.cell4[0], "&", pieza.cell4[1]);
                    archivoSudoku.WriteLine(otro);
                }
                else
                {
                    otro = otro = String.Concat("&",pieza.Figure, "&", pieza.symbol, "&", pieza.resultado, "&", pieza.cell1[0], "&", pieza.cell1[1],"&",-1,"&"
                        ,-1,"&",-1,"&",-1,"&",-1,"&",-1);
                    archivoSudoku.WriteLine(otro);
                }
            }
            archivoSudoku.Close();
        }
        public string ReadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("killerSudoku.txt"))
                {
                    String line = sr.ReadToEnd();
                    return line;

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
            
        }
             
    }
}
