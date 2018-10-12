using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2___Killer_Sudoku
{
    class Generador
    {
        public int[,] Numbers { get; private set; }
        public List<Piece> pieces;
        public  int ColmAndRow;
        public int[,] piezas;
        public int[] piezasAnterior;
        public int contadordePiezas = 0;
        public int[,] sudoku;

        public Generador(int tam) {
            ColmAndRow = tam;
            NumberGenerator();
            Imprimir(Numbers);
            Update(ColmAndRow+1);
            PieceGenerator();
            Imprimir(Numbers);

        }

        private bool Verifica(int[,] matriz, int f, int c, int num, int tam)
        {
            for(int i=0; i < tam; i++)
            {
                if (matriz[f, i] == num || matriz[i, c] == num)
                {
                    return false;
                }
            }
            return true; 
        }
        private void NumberGenerator() {
            Numbers = new int[ColmAndRow, ColmAndRow];
            pieces = new List<Piece>();
            piezas = new int[ColmAndRow, ColmAndRow];
            sudoku= new int[ColmAndRow, ColmAndRow];
            piezasAnterior = new int[ColmAndRow+1];
            int n=1;
            int cont = 1;
            Random aleatorio = new Random();
            for(int i = 0; i < ColmAndRow; i++)
            {
                for(int j=0; j < ColmAndRow; j++)
                {
                    if (n <= ColmAndRow)
                    {
                        Numbers[i, j] = n;
                        n++;
                    }
                    else
                    {
                        Numbers[i, j] = n % ColmAndRow ;
                        n++;
                    }
                }
                n = cont + 1;
                cont++;
            }
         

        }
        private void ChangeCells(int v1, int v2) {
            int[] a, b;
            a= new int[ColmAndRow];
            b = new int[ColmAndRow];
            for (int i = 0; i < ColmAndRow; i++)
            {
                a[i] = Numbers[v1, i];
                b[i] = Numbers[v2, i];
            }
            for (int i=0; i< ColmAndRow; i++)
            {
                Numbers[v1, i] = b[i];
                Numbers[v2, i] = a[i];
            }
        }



        
        private void Update(int grid) {
            int[] filasListas = new int[ColmAndRow];
            int cont = 0;
            for (int i = 0; i < grid; i++)
            {
                var rnd1 = new Random(Guid.NewGuid().GetHashCode());
                var rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int x = rnd1.Next(0, ColmAndRow);
                int y = rnd2.Next(0, ColmAndRow);
                Console.WriteLine("x=" + x + "y=" + y);
                if (x != y )
                {
                    Console.WriteLine("Entró");
                    ChangeCells(x, y);
                    //filasListas[cont] = x;
                    //filasListas[cont + 1] = y;
                    //cont += 2;
                }
            }
        }
        public void PieceGenerator() {
            int[,] cell = new int[ColmAndRow, ColmAndRow];
            var rnd1 = new Random(Guid.NewGuid().GetHashCode());
            var rnd2 = new Random(Guid.NewGuid().GetHashCode());
            int piece, symbol;
            int cont = 0;
            int val;
            for(int i=0; i < ColmAndRow; i++)
            {
                for(int j=0; j < ColmAndRow; j++)
                {
                    
                    piece = rnd1.Next(2, 21);
                    symbol= rnd1.Next(1, 3);
                    val = values(symbol);
                    if (!SearchCell(cell, i, j))
                    {
                        Console.WriteLine(i + "." + j);
                        switch (piece)
                        {
                            case 2:
                                if (PieceTwo(cell, i, j)&&(!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(piece, symbol,0, i, j, i, j + 1, i, j + 2, i, j + 3,val,val,val,val));
                                    cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i, j + 3] = 2;
                                    this.piezasAnterior[cont]  = cell[i, j];

                                }
                                else
                                {
                                    cell= PobrarOtrasPiezas(cell,i,j,symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 3:
                                if (PieceThree(cell, i, j)&& (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(3, symbol,0, i, j, i + 1, j, i + 2, j, i + 3, j, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 3, j] = 3;
                                    this.piezasAnterior[cont] = cell[i, j];

                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 4:
                                if (PieceFour(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(4, symbol,0, i, j, i + 1, j, i + 2, j, i + 2, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 2, j + 1] = 4;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 5:
                                if (PieceFive(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(5, symbol,0, i, j, i + 1, j - 2, i + 1, j - 1, i + 1, j, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j - 2] = cell[i + 1, j - 1] = cell[i + 1, j] = 5;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 6:
                                if (PieceSix(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(6, symbol,0, i, j, i, j + 1, i + 1, j + 1, i + 2, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i + 1, j + 1] = cell[i + 2, j + 1] = 6;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 7:
                                if (PieceSeven(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(7, symbol,0, i, j, i, j + 1, i, j + 2, i + 1, j, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j] = 7;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 8:
                                if (PieceEight(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(8, symbol,0, i, j, i, j + 1, i + 1, j, i + 1, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i + 1, j] = cell[i + 1, j + 1] = 8;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                
                                break;
                            case 9:
                                if (PieceNine(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(9, symbol,0, i, j, i + 1, j, i + 2, j, i + 2, j - 1, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 2, j - 1] = 9;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                               
                                break;
                            case 10:
                                if (PieceTen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(10, symbol,0, i, j, i, j + 1, i, j + 2, i + 1, j + 2, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j + 2] = 10;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                    
                                break;
                            case 11:
                                if (PieceEleven(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(11, symbol,0, i, j, i, j + 1, i + 1, j, i + 2, j, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i + 1, j] = cell[i + 2, j] = 11;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                  
                                break;
                            case 12:
                                if (PieceTwelve(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(12, symbol,0, i, j, i + 1, j, i + 1, j + 1, i + 1, j + 2, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 1, j + 2] = 12;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                     
                                break;
                            case 13:
                                if (PieceThirteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(13, symbol,0, i, j, i, j + 1, i + 1, j - 1, i + 1, j, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i + 1, j - 1] = cell[i + 1, j] = 13;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                break;
                            case 14:
                                if (PieceFourteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(14, symbol,0, i, j, i + 1, j, i + 1, j + 1, i + 2, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 2, j + 1] = 14;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                    
                                break;
                            case 15:
                                if (PieceFifteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(15, symbol,0, i, j, i, j + 1, i + 1, j + 1, i + 1, j + 2, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i + 1, j + 1] = cell[i + 1, j + 2] = 15;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                 
                                break;
                            case 16:
                                if (PieceSixteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(16, symbol,0, i, j, i + 1, j, i + 1, j - 1, i + 2, j - 1, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 1, j - 1] = cell[i + 2, j - 1] = 16;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                
                                break;
                            case 17:
                                if (PieceSeventeen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(17, symbol,0, i, j, i, j + 1, i, j + 2, i + 1, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j + 1] = 17;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                      
                                break;
                            case 18:
                                if (PieceEighteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(18, symbol,0, i, j, i + 1, j, i + 1, j + 1, i + 2, j, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 2, j] = 18;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
          
                                break;
                            case 19:
                                if (PieceNineteen(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(19, symbol,0, i, j, i + 1, j - 1, i + 1, j, i + 1, j + 1, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j - 1] = cell[i + 1, j] = cell[i + 1, j + 1] = 19;
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                   
                                break;
                            case 20:
                                if (PieceTwenty(cell, i, j) && (!PiezasAnteriores(piece)))
                                {
                                    pieces.Add(new Piece(20, symbol,0, i, j, i + 1, j - 1, i + 1, j, i + 2, j, val, val, val, val));
                                    cell[i, j] = cell[i + 1, j - 1] = cell[i + 1, j] = cell[i + 2, j] = 20;
                                    this.piezasAnterior[cont] = cell[i, j];

                                }
                                else
                                {
                                    cell = PobrarOtrasPiezas(cell, i, j, symbol,val);
                                    this.piezasAnterior[cont] = cell[i, j];
                                }
                  
                                break;     
                        }
                        cont++;
                        contadordePiezas++;
                        if(cont == ColmAndRow)
                        {
                            cont = 0;
                        }
                    }
        
                }
            }
            piezas = cell;

        }
        private bool PiezasAnteriores(int newPiece) {
            bool bandera = false;
            for(int i=0; i < piezasAnterior.Length; i++)
            {
                if (piezasAnterior[i] == newPiece)
                {
                    bandera = true;
                }
            }
            return bandera;
        }
        public int [,] PobrarOtrasPiezas(int[,]cell, int i, int j, int symbol, int val)
        {
            if (PieceSixteen(cell, i, j) && (!PiezasAnteriores(16)))
            {
                pieces.Add(new Piece(16, symbol,0, i, j, i + 1, j, i + 1, j - 1, i + 2, j - 1, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 1, j - 1] = cell[i + 2, j - 1] = 16;
            }
            else if (PieceNineteen(cell, i, j) && (!PiezasAnteriores(19)))
            {
                pieces.Add(new Piece(19, symbol,0, i, j, i + 1, j - 1, i + 1, j, i + 1, j + 1, val, val, val, val));
                cell[i, j] = cell[i + 1, j - 1] = cell[i + 1, j] = cell[i + 1, j + 1] = 19;
            }

            else if (PieceFive(cell, i, j) && (!PiezasAnteriores(5)))
            {
                pieces.Add(new Piece(5, symbol,0, i, j, i + 1, j - 2, i + 1, j - 1, i + 1, j, val, val, val, val));
                cell[i, j] = cell[i + 1, j-2] = cell[i + 1, j-1] = cell[i + 1, j] = 5;
            }
            else if (PieceSix(cell, i, j) && (!PiezasAnteriores(6)))
            {
                pieces.Add(new Piece(6, symbol,0, i, j, i, j+1, i + 1, j +1, i + 2, j+1, val, val, val, val));
                cell[i, j] = cell[i, j+1] = cell[i + 1, j + 1] = cell[i + 2, j+1] = 6;
            }
            else if (PieceSeven(cell, i, j) && (!PiezasAnteriores(7)))
            {
                pieces.Add(new Piece(7, symbol,0,i,j,i,j+1,i,j+2,i+1,j, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j] = 7;
            }
            else if (PieceEight(cell, i, j) && (!PiezasAnteriores(8)))
            {
                pieces.Add(new Piece(8, symbol,0, i, j, i, j + 1, i + 1, j, i + 1, j + 1, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i + 1, j] = cell[i + 1, j + 1] = 8;
            }
            else if (PieceNine(cell, i, j) && (!PiezasAnteriores(9)))
            {
                pieces.Add(new Piece(9, symbol,0, i, j, i + 1, j, i + 2, j, i + 2, j - 1, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 2, j - 1]=9;
            }
            else if (PieceTwo(cell, i, j) && (!PiezasAnteriores(2)))
            {
                pieces.Add(new Piece(2, symbol,0, i, j, i, j + 1, i, j + 2, i, j + 3, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i, j + 3] = 2;
            }
            else if (PieceTen(cell, i, j) && (!PiezasAnteriores(10)))
            {
                pieces.Add(new Piece(10, symbol,0, i, j, i, j + 1, i, j + 2, i + 1, j + 2, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j + 2] = 10;
            }
            else if (PieceFourteen(cell, i, j) && (!PiezasAnteriores(14)))
            {
                pieces.Add(new Piece(14, symbol,0, i, j, i + 1, j, i + 1, j + 1, i + 2, j + 1, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 2, j + 1] = 14;
            }
            else if (PieceThree(cell, i, j) && (!PiezasAnteriores(3)))
            {
                pieces.Add(new Piece(3, symbol,0, i, j, i + 1, j, i + 2, j, i + 3, j, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 3, j] = 3;
            }
            else if (PieceEleven(cell, i, j) && (!PiezasAnteriores(11)))
            {
                pieces.Add(new Piece(11, symbol,0, i, j, i, j + 1, i + 1, j, i + 2, j, val, val, val, val));
                cell[i,j]=cell[i,j+1]=cell[i+1,j]=cell[i+2,j]= 11;

            }
            else if (PieceFour(cell, i, j) && (!PiezasAnteriores(4)))
            {
                pieces.Add(new Piece(4, symbol,0, i, j, i + 1, j, i + 2, j, i + 2, j + 1, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 2, j] = cell[i + 2, j + 1] = 4;
            }
            else if (PieceTwelve(cell, i, j) && (!PiezasAnteriores(12)))
            {
                pieces.Add(new Piece(12,symbol,0,i,j,i+1,j,i+1,j+1,i+1,j+2, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 1, j + 2] = 12;
            }
            else if (PieceThirteen(cell, i, j) && (!PiezasAnteriores(13)))
            {
                pieces.Add(new Piece(13, symbol,0,i,j,i,j+1,i+1,j-1,i+1,j, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i + 1, j - 1] = cell[i + 1, j] = 13;
            }

            else if(PieceFifteen(cell, i, j) && (!PiezasAnteriores(15)))
            {
                pieces.Add(new Piece(15, symbol,0,i,j,i,j+1,i+1,j+1,i+1,j+2, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i + 1, j + 1] = cell[i + 1, j + 2]=15;
            }

            else if (PieceSeventeen(cell, i, j) && (!PiezasAnteriores(17)))
            {
                pieces.Add(new Piece(17, symbol,0, i, j, i, j + 1, i, j + 2, i + 1, j + 1, val, val, val, val));
                cell[i, j] = cell[i, j + 1] = cell[i, j + 2] = cell[i + 1, j + 1]=17;
            }
            else if (PieceEighteen(cell, i, j) && (!PiezasAnteriores(18)))
            {
                pieces.Add(new Piece(18, symbol,0, i, j, i + 1, j, i + 1, j + 1, i + 2, j, val, val, val, val));
                cell[i, j] = cell[i + 1, j] = cell[i + 1, j + 1] = cell[i + 2, j]=18;
            }

            else if (PieceTwenty(cell, i, j) && (!PiezasAnteriores(20)))
            {
                pieces.Add(new Piece(20, symbol,0, i, j,i+1,j-1,i+1,j,i+2,j, val, val, val, val));
                cell[i, j] = cell[i + 1, j - 1] = cell[i + 1, j] = cell[i + 2, j] = 20;
            }
            else if (PieceOne(cell, i, j))
            {
                pieces.Add(new Piece(1, symbol,0, i, j, -1, -1, -1, -1, -1, -1, val, val, val, val));
                cell[i, j] = 1;
            }
            return cell;
        }
        private bool PieceOne(int[,] cell, int x, int y)
        {
            if(SearchCell(cell, x, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceTwo(int[,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y)||SearchCell(cell, x, y+1)||SearchCell(cell,x,y+2)||SearchCell(cell,x,y+3))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceThree(int[,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 2, y) || SearchCell(cell, x + 3, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceFour(int[,] cell, int x, int y)
        {
            if  (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 2, y) || SearchCell(cell, x + 2, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceFive(int[,] cell, int x, int y)
        {
            if(SearchCell(cell, x,y)||SearchCell(cell, x+1,y-2)||SearchCell(cell, x + 1, y - 1) || SearchCell(cell, x + 1, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceSix(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x, y + 1) || SearchCell(cell, x + 1, y + 1) || SearchCell(cell, x + 2, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceSeven(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x, y + 1) || SearchCell(cell, x, y + 2) || SearchCell(cell, x + 1, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceEight(int [,] cell, int x, int y)
        {
            if(SearchCell(cell,x,y )|| SearchCell(cell, x, y+1)||SearchCell(cell, x+1,y)|| SearchCell(cell,x + 1, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceNine(int [,] cell, int x, int y)
        {
            if(SearchCell(cell, x, y)||SearchCell(cell,x+1,y)||SearchCell(cell, x + 2, y) || SearchCell(cell, x + 2, y - 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceTen(int [,] cell, int x, int y)
        {
            if(SearchCell(cell, x,y)||SearchCell(cell, x,y+1)||SearchCell(cell, x, y+2)||SearchCell(cell, x + 1, y + 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceEleven(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x, y + 1) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 2, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
        private bool PieceTwelve(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 1, y + 1) || SearchCell(cell, x + 1, y + 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceThirteen(int [,] cell, int x, int y)
        {
            if(SearchCell(cell, x,y)||SearchCell(cell, x,y+1)||SearchCell(cell,x+1,y-1)||SearchCell(cell, x + 1, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceFourteen(int [,] cell ,int x, int y)
        {
            if(SearchCell(cell, x,y)||SearchCell(cell,x+1,y)||SearchCell(cell, x + 1, y + 1) || SearchCell(cell, x + 2, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceFifteen(int [,] cell, int x, int y)
        {
            if(SearchCell(cell, x, y) || SearchCell(cell, x, y + 1) || SearchCell(cell, x + 1, y + 1) || SearchCell(cell, x + 1, y + 2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceSixteen(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 1, y - 1) || SearchCell(cell, x + 2, y - 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ImprimirPiezas(List<Piece> p)
        {
            foreach (Piece pieza in p)
            {
                Console.WriteLine("figura: " + pieza.Figure + " simbolo: " + pieza.symbol + " resultado: " + pieza.resultado +
                    " celda1: " + pieza.cell1[0] + "," + pieza.cell1[1] + " celda2: " + pieza.cell2[0] + "," + pieza.cell2[1] +
                    " celda3: " + pieza.cell3[0] + "," + pieza.cell3[1] + " celda4:" + pieza.cell4[0] + "," + pieza.cell4[1]);
            }
        }
        private bool PieceSeventeen(int [,] cell, int x, int y)
        {
            if(SearchCell(cell,x,y)||SearchCell(cell,x,y+1)||SearchCell(cell,x,y+2)||SearchCell(cell, x + 1, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool PieceEighteen(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 1, y + 1) || SearchCell(cell, x + 2, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceNineteen(int [,] cell, int x, int y)
        {
            if (SearchCell(cell, x, y) || SearchCell(cell, x + 1, y - 1) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 1, y + 1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool PieceTwenty(int [,] cell, int x, int y)
        {
            if(SearchCell(cell, x, y) || SearchCell(cell, x + 1, y - 1) || SearchCell(cell, x + 1, y) || SearchCell(cell, x + 2, y))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool SearchCell(int[,] cell, int x, int y)
        {
            
            if(x>=ColmAndRow || y >= ColmAndRow|| x<0 || y<0)
            {
                return true;
            }
            else if (cell[x, y] != 0)
            {
                 return true;
            }
            else
            {
                 return false;
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
        public override string ToString()
        {
            var SB = new StringBuilder();
            for(int i=0; i< ColmAndRow; i++)
            {
                for(int j=0; j< ColmAndRow; i++)
                {
                    SB.Append(Numbers[i,j]);
                }
            }
            return base.ToString();
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
