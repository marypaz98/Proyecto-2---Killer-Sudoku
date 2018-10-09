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
        public int clmAndRow;
        public int[,] sudoku;
        public List<Piece> piezas;
        public int[,] pieces;

        public Solver(int tam)
        {
            clmAndRow = tam;
            sudoku = new int[clmAndRow, clmAndRow];
            piezas = new List<Piece>();
            pieces = new int[clmAndRow, clmAndRow];
            infoArchivo = archivoSudoku.ReadFile();
            getSudoku();
     
    
            
            resolver();

        }
        public void getSudoku()
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
            matriz= matriz.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            piezas = piezas.Replace(" ", "");
            getMatriz(matriz);
            getPiece(piezas);
        }


        public void getMatriz(string matriz)
        {
            int contador = 0;
            string caracter = "";
            string[] caracteres = matriz.Split('?');
            for(int i=0; i < clmAndRow; i++)
            {
                for (int j = 0; j < clmAndRow; j++)
                {
                    if (contador < caracteres.Length)
                    {
                      
                        if (caracteres[contador] != "\n" || caracteres[contador] != "\r" || caracteres[contador] != "\r\n")
                        {
                            caracter = caracteres[contador];
                            Int32.TryParse(caracter, out sudoku[i, j]);
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }
                }
            }

        }
        public void getPiece(string pieza)
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
                    if (figura != 1)
                    {
                        this.pieces[row1, clm1] = this.pieces[row2, clm2] = this.pieces[row3, clm3] = this.pieces[row4, clm4] = figura;
                    }
                    else
                    {
                        this.pieces[row1, clm1] = figura;
                    }
                    piezas.Add(new Piece(figura, simbolo, resultado, row1, clm1, row2, clm2, row3, clm3, row4, clm4));
                }
             
                
                
            }

         //   ImprimirPiezas(piezas);
        }
        public  bool isSafe(int[,] matriz, int num, int row, int col)
        {
      
            // row has the unique (row-clash) 
            for (int i=0; i < matriz.GetLength(0); i++)
            {
                // if the number we are trying to  
                // place is already present in  
                // that row, return false;
                if (matriz[row, i] == num)
                {
                    return false;
                }
            }
            for(int j=0; j < matriz.GetLength(0); j++)
            {
                // if the number we are trying to 
                // place is already present in 
                // that column, return false;
                if (matriz[j, col] == num)
                {
                    return false;
                }
            }

            return true;
        }

        public  bool solveSudoku(int[,] matriz, int n)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i=0; i<n; i++)
            {
                for(int j=0; j < n; j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }
            if (isEmpty)
            {
                return true;
            }
            // else for each-row backtrack 
            for (int num = 1; num <= n; num++)
            {
                if(isSafe(matriz,num,row, col))
                {
                    Console.WriteLine("SI ENTRO");
                    matriz[row, col] = num;
                    if (solveSudoku(matriz, n))
                    {
                        Console.WriteLine("MM");
                        // print(matriz, n);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("no entiendo que hace");
                        matriz[row, col] = 0; //replace it
                    }
                }
            }
            return false;
        }
        private  bool validarPiezas(int[,] matriz, int num, int row, int col)
        {

            if (!isSafe(matriz, num, row, col))
            {
                Console.WriteLine("FALSE");
                return false;
            }
            else
            {
                foreach (Piece p in piezas)
                {
                    Console.WriteLine("?");
                    if (num > p.resultado)
                    {
                        Console.WriteLine("falso");
                        return false;

                    }
                    if (p.symbol == 1)
                    {
                        Console.WriteLine("si");
                        if (validarSuma(p, num, row, col))
                        {
                            if (p.cell1[0] == row && p.cell1[1] == col)
                            {
                                p.valor1 = num;
                            }
                            else if (p.cell2[0] == row && p.cell2[1] == col)
                            {
                                p.valor2 = num;
                            }
                            else if (p.cell3[0] == row && p.cell3[1] == col)
                            {
                                p.valor3 = num;
                            }
                            else if (p.cell4[0] == row && p.cell4[1] == col)
                            {
                                p.valor4 = num;
                            }
                            Console.WriteLine("verdadero");
                            return true;

                        }
                    }

                    /* else if (signo == 2)
                     {
                         if (validarMultiplicacion(p, num, row, col))
                         {
                             if (p.cell1[0] == row && p.cell1[1] == col)
                             {
                                 p.valor1 = num;
                             }
                             else if (p.cell2[0] == row && p.cell2[1] == col)
                             {
                                 p.valor2 = num;
                             }
                             else if (p.cell3[0] == row && p.cell3[1] == col)
                             {
                                 p.valor3 = num;
                             }
                             else if (p.cell4[0] == row && p.cell4[1] == col)
                             {
                                 p.valor4 = num;
                             }
                             return true;
                         }
                     }

                     */
                }
            }
            Console.WriteLine("Ultimo falso");
            return false;
        }
       /* private bool validarMultiplicacion(Piece p, int num, int row, int col)
        {
            if ((p.cell1[0] == row && p.cell1[1] == col))
            {
                if (p.valor2 * p.valor3 * p.valor4 * num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell2[0] == row && p.cell2[1] == col)
            {
                if (p.valor1 * p.valor3 * p.valor4 * num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell3[0] == row && p.cell3[1] == col)
            {
                if (p.valor1 * p.valor2 * p.valor4 * num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell4[0] == row && p.cell4[1] == col)
            {
                if (p.valor1 * p.valor2 * p.valor3 * num > p.resultado)
                {
                    return false;
                }
            }
            return true;

        }*/
        private bool validarSuma(Piece p, int num, int row, int col)
        {
            if ((p.cell1[0] == row && p.cell1[1] == col))
            {
                if (p.valor2 + p.valor3 + p.valor4 + num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell2[0] == row && p.cell2[1] == col)
            {
                if (p.valor1 + p.valor3 + p.valor4 + num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell3[0] == row && p.cell3[1] == col)
            {
                if (p.valor1 + p.valor2 + p.valor4 + num > p.resultado)
                {
                    return false;
                }
            }
            else if (p.cell4[0] == row && p.cell4[1] == col)
            {
                if (p.valor1 + p.valor2 + p.valor3 + num > p.resultado)
                {
                    return false;
                }
            }
            return true;

        }
        public  void resolver()
        {
            int N = sudoku.GetLength(0);
     
            if (solveSudoku(sudoku, N))
            {
                Imprimir(sudoku);
   
            }
            else
            {
                Console.WriteLine("No solución");
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

