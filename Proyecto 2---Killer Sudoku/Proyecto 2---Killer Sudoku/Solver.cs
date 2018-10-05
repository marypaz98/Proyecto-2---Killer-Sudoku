using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2___Killer_Sudoku
{
    class Solver
    {
        File archivoSudoku = new File();
        String infoArchivo;
        int clmAndRow = 9;
        int[,] sudoku;
        List<Piece> piezas;

        public Solver()
        {
            sudoku = new int[clmAndRow, clmAndRow];
            piezas = new List<Piece>();
            infoArchivo = archivoSudoku.ReadFile();
            llenarSudoku();

        }
        public void llenarSudoku()
        {
            String matriz = "";
            String piezas = "";
            String caracter = infoArchivo.Substring(0, 1); 
            int contador = 1;
            while (caracter != "&")
            {
                if (caracter != " " && caracter!="\n")
                {
                    matriz = String.Concat(matriz, caracter);
                }
                caracter = infoArchivo.Substring(contador, 1);
                contador++;
            }
            for (int i = contador; i < infoArchivo.Length; i++)
            {
                caracter = infoArchivo.Substring(i, 1);
                piezas = String.Concat(piezas, caracter);
            }
            matriz= matriz.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ","");
            piezas = piezas.Replace(" ", "");
            llenarMatriz(matriz);
            llenarPiezas(piezas);
        }


        public void llenarMatriz(string matriz)
        {
            int contador = 0;
            string caracter = "";
            for(int i=0; i < clmAndRow; i++)
            {
                for (int j=0; j < clmAndRow; j++)
                {
                    caracter = matriz.Substring(contador, 1);
                    Int32.TryParse(caracter, out sudoku[i,j]);
                    contador+=1;
                }
            }

        }
        public void llenarPiezas(string pieza)
        {
            int figura=0;
            int simbolo=0;
            int resultado = 0;
            int i = 0;
            int row1, row2, row3, row4, clm1, clm2, clm3, clm4;
            row1 = row2 = row3 = row4 = clm1 = clm2 = clm3 = clm4 = 0;
            string[] caracteres =pieza.Split('&');
            while (i < (caracteres.Length))
            {
                if (caracteres[i] != "\n" || caracteres[i] != "\r\n" || caracteres[i] != "\r")
                {
                    Int32.TryParse(caracteres[i], out figura);
                    i++;
                    Int32.TryParse(caracteres[i], out simbolo);
                    i++;
                    Int32.TryParse(caracteres[i], out resultado);
                    i++;
                    Int32.TryParse(caracteres[i], out row1);
                    i++;
                    Int32.TryParse(caracteres[i], out clm1);
                    i++;
                    Int32.TryParse(caracteres[i], out row2);
                    i++;
                    Int32.TryParse(caracteres[i], out clm2);
                    i++;
                    Int32.TryParse(caracteres[i], out row3);
                    i++;
                    Int32.TryParse(caracteres[i], out clm3);
                    i++;
                    Int32.TryParse(caracteres[i], out row4);
                    i++;
                    Int32.TryParse(caracteres[i], out clm4);
                    i++;
                }
                piezas.Add(new Piece(figura, simbolo,resultado, row1, clm1, row2, clm2, row3, clm3, row4, clm4));
            }


        }
        public void ImprimirPiezas(List<Piece> p)
        {
            foreach (Piece pieza in p)
            {
                Console.WriteLine("figura: " + pieza.Figure + " simbolo: " +pieza.symbol+" resultado: "+pieza.resultado+
                    " celda1: "+pieza.cell1[0]+","+pieza.cell1[1]+" celda2: "+pieza.cell2[0]+","+pieza.cell2[1]+
                    " celda3: "+pieza.cell3[0]+","+pieza.cell3[1]+" celda4:"+pieza.cell4[0]+","+pieza.cell4[1]);
            }
        }
        public void Imprimir(int[,] mat)
        {
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.Write(mat[f, c] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

