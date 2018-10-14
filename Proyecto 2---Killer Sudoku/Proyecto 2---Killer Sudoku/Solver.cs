using System;
using System.Collections;
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
        public int[,] Sudoku;
        public bool res=true;
        private List<int[]> posibilidades;
        private List<savePossibilities> posListas;
        


        public Solver(int tam, int[,] s)
        {
            
            clmAndRow = tam;
            Sudoku = s;
            sudoku = new int[clmAndRow, clmAndRow];
            piezas = new List<Piece>();
            pieces = new int[clmAndRow, clmAndRow];
            posListas = new List<savePossibilities>();
            posibilidades = new List< int[]>();
            String[] pos = crearVector(clmAndRow);
 
            infoArchivo = archivoSudoku.ReadFile();
            getSudoku();
            listaPosibilidades(pos, "", 4, clmAndRow);
            ImprimirPosibilades(posibilidades);
              resolver();

        }
        public String[] crearVector (int tam)
        {
            String[] elements = new string[tam];
            for (int i=1; i <= tam; i++)
            {
                elements[i - 1] = i.ToString() ;
            }
            return elements;
            
        }
        public void listaPosibilidades(String[] elem, String act, int n, int r)
        {
            if (n == 0)
            {
                posibilidades.Add(new int[4]);
                String[] comb = act.Split(',');
                
                
                int[] com = new int[comb.Length-1];
                for(int i=0; i < comb.Length-1; i++)
                {
                    com[i] = int.Parse(comb[i]);
                }
                for(int i=0; i < com.Length; i++)
                {
                    posibilidades[posibilidades.Count - 1][i] = com[i];
                }
            }
            else
            {
                for(int i=0; i < r; i++)
                {
                    listaPosibilidades(elem, act + elem[i] + ",", n - 1, r);
                }
            }
        }
        public void getSudoku()
        {
            String matriz = "";
            String piezas = "";
            String caracter = infoArchivo.Substring(0, 1);
            int contador = 1;
            while (caracter != "&")
            {
                if (caracter != " " && caracter != "\n")
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
            matriz = matriz.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            piezas = piezas.Replace(" ", "");
            getMatriz(matriz);
            getPiece(piezas);
        }


        public void getMatriz(string matriz)
        {
            int contador = 0;
            string caracter = "";
            string[] caracteres = matriz.Split('?');
            for (int i = 0; i < clmAndRow; i++)
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
            int val;
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
                    val = values(simbolo);
                    piezas.Add(new Piece(figura, simbolo, resultado, row1, clm1, row2, clm2, row3, clm3, row4, clm4, val, val, val, val));
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
                if (matriz[row, i] == num||matriz[i,col]==num)
                {
                    return false;
                }
            }

            return true;
        }
        private  bool buscarPosibilidades(int resultado, int simbolo)
        {
           
            if(posListas.Exists(x => x.resultado == resultado && x.simbolo==simbolo))
            {
                return true;
            }
            return false;
        }
        private List<int[]> devolverPosibilidades(int resultado, int simbolo)
        {

            savePossibilities save = posListas.Find(delegate (savePossibilities s)
             {
                 return s.resultado == resultado&& s.simbolo==simbolo;
             });
            return save.pos;
        }
        public bool solvSudoku(int[,] matriz, int n, List<Piece> piece)
        {
            Piece pieza =new Piece(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
            bool isEmpty = true;
            int cont = 0;
            int c = 0;
            foreach(Piece p in piece)
            {
                if (!p.resuelto&&p.Figure!=1)
                {
                    Console.WriteLine("a");
                    pieza = p;
                    isEmpty = false;
                    break;
                }
                cont++;
            }

            if (isEmpty)
            {
                return true;
            }
            int r1 = pieza.cell1[0];
            int c1 = pieza.cell1[1];
            int r2 = pieza.cell2[0];
            int c2 = pieza.cell2[1];
            int r3 = pieza.cell3[0];
            int c3 = pieza.cell3[1];
            int r4 = pieza.cell4[0];
            int c4 = pieza.cell4[1];
            bool si = false;
            List<int[]> posibleCombinaciones;
            
            if (buscarPosibilidades(pieza.resultado,pieza.symbol))
            {
                posibleCombinaciones = devolverPosibilidades(pieza.resultado, pieza.symbol);
            }
            else {
                posibleCombinaciones = generarCombinaciones(pieza.resultado, pieza.symbol);
                posListas.Add(new savePossibilities(pieza.resultado,pieza.symbol,posibleCombinaciones));
            }
            int uno, dos, tres, cuatro;
            
            for(int i=0; i< posibleCombinaciones.Count&&!si;i++)
            {
                int n1, n2, n3, n4;
 
                uno = posibleCombinaciones.ElementAt(i)[0];
                dos = posibleCombinaciones.ElementAt(i)[1];
                tres = posibleCombinaciones.ElementAt(i)[2];
                cuatro = posibleCombinaciones.ElementAt(i)[3];
                
                n1 = uno;
                n2 = dos;
                n3 = tres;
                n4 = cuatro;
             //   Console.WriteLine(uno + " " + dos + " " + tres + " "+cuatro);
                if (match_Piece(matriz, uno, dos, tres, cuatro, pieza))
                {
                    si = true;
                }
                else if(match_Piece(matriz, uno, dos, cuatro, tres, pieza))
                {
                    tres = n4;
                    cuatro = n3;
                    si = true;
                }
                else if(match_Piece(matriz, uno, tres, dos, cuatro, pieza))
                {
                    dos = n3;
                    tres = n2;
                    si=true;
                }
                else if(match_Piece(matriz, uno, tres, cuatro, dos, pieza))
                {
                    dos = n3;
                    tres = n4;
                    cuatro = n2;
                    si = true;
                }
                else if(match_Piece(matriz, uno, cuatro, dos, tres, pieza))
                {
                    dos = n4;
                    tres = n2;
                    cuatro = n3;
                    si = true;
                }
                else if(match_Piece(matriz, uno, cuatro, tres, dos, pieza))
                {
                    dos = n4;
                    cuatro = n2;
                    si = true;
                }
                else if (match_Piece(matriz, dos, uno, tres, cuatro, pieza))
                {
                    uno = n2;
                    dos = n1;
                    si = true;
                }
                else if(match_Piece(matriz, dos, uno, cuatro, tres, pieza))
                {
                    uno = n2;
                    dos = n1;
                    tres = n4;
                    cuatro = n3;
                    si = true;
                }
                else if (match_Piece(matriz, dos, tres, uno, cuatro, pieza))
                {
                    uno = n2;
                    dos = n3;
                    tres = n1;
                    si = true;
                }
                else if(match_Piece(matriz, dos, tres, cuatro, uno, pieza))
                {
                    uno = n2;
                    dos = n3;
                    tres = n4;
                    cuatro = n1;
                    si = true;
                }
                else if(match_Piece(matriz, dos, cuatro, uno, tres, pieza))
                {
                    uno = n2;
                    dos = n4;
                    tres = n1;
                    cuatro = n3;
                    si = true;
                }
                else if(match_Piece(matriz, dos, cuatro, tres, uno, pieza))
                {
                    uno = n2;
                    dos = n4;
                    cuatro = n1;
                    si = true;
                }
                else if (match_Piece(matriz, tres, uno, dos, cuatro, pieza)) {
                    uno = n3;
                    dos = n1;
                    tres = n2;
                    si = true;
                }
                else if(match_Piece(matriz, tres, uno, cuatro, dos, pieza))
                {
                    uno = n3;
                    dos = n1;
                    tres = n4;
                    cuatro = n2;
                    si = true;
                }
                else if(match_Piece(matriz, tres, dos, uno, cuatro, pieza))
                {
                    uno = n3;
                    tres = n1;
                    si =true;
                }
                else if(match_Piece(matriz, tres, dos, cuatro, uno, pieza))
                {
                    uno = n3;
                    tres = n4;
                    cuatro = n1;
                    si = true;
                }
                else if(match_Piece(matriz, tres, cuatro, uno, dos, pieza))
                {
                    uno = n3;
                    dos = n4;
                    tres = n1;
                    cuatro = n2;
                    si = true;
                }
                else if (match_Piece(matriz, tres, cuatro, dos, uno, pieza)) {
                    uno = n3;
                    dos = n4;
                    tres = n2;
                    cuatro = n1;
                    si = true;
                }
                else if (match_Piece(matriz, cuatro, uno, dos, tres, pieza))
                {
                    uno = n4;
                    dos = n1;
                    tres = n2;
                    cuatro = n3;
                    si = true;
                }
                else if(match_Piece(matriz, cuatro, uno, tres, dos, pieza))
                {
                    uno = n4;
                    dos = n1;
                    cuatro = n2;
                    si = true;
                }
                else if (match_Piece(matriz, cuatro, dos, uno, tres, pieza))
                {
                    uno = n4;
                    tres = n1;
                    cuatro = n3;
                    si = true;
                }
                else if(match_Piece(matriz, cuatro, dos, tres, uno, pieza))
                {
                    uno = n4;
                    cuatro = n1;
                    si = true;
                }
                else if(match_Piece(matriz, cuatro, tres, uno, dos, pieza))
                {
                    uno = n4;
                    dos = n3;
                    tres = n1;
                    cuatro = n2;
                    si = true;
                }
                else if(match_Piece(matriz, cuatro, tres, dos, uno, pieza))
                {
                    uno = n4;
                    dos = n3;
                    tres = n2;
                    cuatro = n1;
                    si = true;
                }
                if (isFull(matriz, n))
                {
                    return true;
                }
                if (si)
                {
                    matriz[pieza.cell1[0], pieza.cell1[1]]=uno;
                    matriz[pieza.cell2[0], pieza.cell2[1]] = dos;
                    matriz[pieza.cell3[0], pieza.cell3[1]] = tres;
                    matriz[pieza.cell4[0], pieza.cell4[1]] = cuatro;
                    pieza.resuelto = true;
                    piece.ElementAt(cont).resuelto = true;
                    if(solvSudoku(matriz, n , piece))
                    {
                        return true;
                    }
                    else
                    {
                        piece.ElementAt(cont).resuelto = false;
                        si = false;
                        matriz[pieza.cell1[0], pieza.cell1[1]] = 0;
                        matriz[pieza.cell2[0], pieza.cell2[1]] = 0;
                        matriz[pieza.cell3[0], pieza.cell3[1]] = 0;
                        matriz[pieza.cell4[0], pieza.cell4[1]] = 0;
                    }
                }
            }
            return false;


        }
     
        public  void resolver()
        {
            int N = sudoku.GetLength(0);
            if (solvSudoku(sudoku, N, piezas))
            {
                Imprimir(sudoku);
   
            }
            else
            {
                res = false;
                Console.WriteLine("No solución");
            }
        }

        private List<int[]> generarCombinaciones(int result, int symbol)
        {
            if (symbol ==1)
            {
                return generateSum(result);
            }
            else
            {
                return generateMul(result);
            }
        }
        private List<int[]> generateSum(int result)
        {
            List<int[]> res= new List<int[]>();
            int[] con = new int[4];

            foreach (int[] i in posibilidades)
            {
                if (i[0] + i[1] + i[2] + i[3]==result)
                {
                    con[0] = i[0];
                    con[1] = i[1];
                    con[2] = i[2];
                    con[3] = i[3];
                    res.Add(new int[4]);
                    for (int j = 0; j < con.Length; j++)
                    {
                        res[res.Count - 1][j] = con[j];
                    }
                }
            }
            return res;
        }
        private List<int[]> generateMul(int result)
        {
            List<int[]> res = new List<int[]>();
            int[] con = new int[4];

            foreach (int[] i in posibilidades)
            {
                if (i[0] * i[1] * i[2] * i[3] == result)
                {
                    con[0] = i[0];
                    con[1] = i[1];
                    con[2] = i[2];
                    con[3] = i[3];
                    res.Add(new int[4]);
                    for (int j = 0; j < con.Length; j++)
                    {
                        res[res.Count - 1][j] = con[j];
                    }
                }
            }
            return res;
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
        public void ImprimirPosibilades(List<int[]> p)
        {
            int x= 0;
            Console.WriteLine("posibilidades: "+posibilidades.Count);   
            foreach(int[] pos in p)
            {
                Console.WriteLine(x);
                x++;
                Console.WriteLine(pos[0] + " " + pos[1] + " " + pos[2] + " " + pos[3]);
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
        
        public int values(int symbol)
        {
            if (symbol == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private bool matchOtherPiece(int v1, int v2, int v3, int v4, Piece p)
        {
            if (v1 == v2)
            {
                if (p.cell1[0] == p.cell2[0] || p.cell1[1] == p.cell2[1])
                {
                    return false;
                }
            }
            else if (v1 == v3)
            {
                if (p.cell1[0] == p.cell3[0] || p.cell1[1] == p.cell3[1])
                {
                    return false;
                }
            }
            else if (v1 == v4)
            {
                if (p.cell1[0] == p.cell4[0] || p.cell1[1] == p.cell4[1])
                {
                    return false;
                }
            }
            else if (v2 == v3)
            {
                if (p.cell2[0] == p.cell3[0] || p.cell2[1] == p.cell3[1])
                {
                    return false;
                }
            }
            else if (v2 == v4)
            {
                if (p.cell2[0] == p.cell4[0] || p.cell2[1] == p.cell4[1])
                {
                    return false;
                }
            }
            else if (v3 == v4)
            {
                if (p.cell3[0] == p.cell4[0] || p.cell3[1] == p.cell4[1])
                {
                    return false;
                }
            }
            return true;

        }
        private bool isFull(int[,] matriz, int n)
        {
            for(int i=0; i < n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool match_Piece(int[,] matriz,int v1, int v2, int v3, int v4,Piece p)
        {
            /*    if (cont != clmAndRow*100000)
                {
                    return false;
                }*/
            if (!matchOtherPiece(v1,v2,v3,v4,p))
            {
                return false;
            }
            else if ((isSafe(matriz, v1, p.cell1[0], p.cell1[1]) == false) || (isSafe(matriz, v2, p.cell2[0], p.cell2[1]) == false) || (isSafe(matriz, v3, p.cell3[0], p.cell3[1]) == false) || (isSafe(matriz, v4, p.cell4[0], p.cell4[1]) == false))
            { 
                return false;
            }
            return true;

        }


    }
}

