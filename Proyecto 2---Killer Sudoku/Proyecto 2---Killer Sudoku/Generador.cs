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

        public Generador() {
            NumberGenerator();
            Update(10);

        }

        private void NumberGenerator() {
            Numbers = new int[9, 9];
            pieces = new List<Piece>();
            for (int i = 0; i < 9; i++) {
                for (int j=0; j<9; j++){
                    Numbers[i, j] = (i*3+i/3+j)%9+1;
                }
            }
            Console.WriteLine(Numbers[0, 0].ToString() + Numbers[0, 1].ToString() + Numbers[0, 2].ToString() + Numbers[0, 3].ToString()
+ Numbers[0, 4].ToString() + Numbers[0, 5].ToString() + Numbers[0, 6].ToString() + Numbers[0, 7].ToString() + Numbers[0, 8].ToString());
            Console.WriteLine(Numbers[1, 0].ToString() + Numbers[1, 1].ToString() + Numbers[1, 2].ToString() + Numbers[1, 3].ToString()
              + Numbers[1, 4].ToString() + Numbers[1, 5].ToString() + Numbers[1, 6].ToString() + Numbers[1, 7].ToString() + Numbers[1, 8].ToString());
            Console.WriteLine(Numbers[2, 0].ToString() + Numbers[2, 1].ToString() + Numbers[2, 2].ToString() + Numbers[2, 3].ToString()
                          + Numbers[2, 4].ToString() + Numbers[2, 5].ToString() + Numbers[2, 6].ToString() + Numbers[2, 7].ToString() + Numbers[2, 8].ToString());
            Console.WriteLine(Numbers[3, 0].ToString() + Numbers[3, 1].ToString() + Numbers[3, 2].ToString() + Numbers[3, 3].ToString()
              + Numbers[3, 4].ToString() + Numbers[3, 5].ToString() + Numbers[3, 6].ToString() + Numbers[3, 7].ToString() + Numbers[3, 8].ToString());
            Console.WriteLine(Numbers[4, 0].ToString() + Numbers[4, 1].ToString() + Numbers[4, 2].ToString() + Numbers[4, 3].ToString()
                          + Numbers[4, 4].ToString() + Numbers[4, 5].ToString() + Numbers[4, 6].ToString() + Numbers[4, 7].ToString() + Numbers[4, 8].ToString());
            Console.WriteLine(Numbers[5, 0].ToString() + Numbers[5, 1].ToString() + Numbers[5, 2].ToString() + Numbers[5, 3].ToString()
                          + Numbers[5, 4].ToString() + Numbers[5, 5].ToString() + Numbers[5, 6].ToString() + Numbers[5, 7].ToString() + Numbers[5, 8].ToString());
            Console.WriteLine(Numbers[6, 0].ToString() + Numbers[6, 1].ToString() + Numbers[6, 2].ToString() + Numbers[6, 3].ToString()
                          + Numbers[6, 4].ToString() + Numbers[6, 5].ToString() + Numbers[6, 6].ToString() + Numbers[6, 7].ToString() + Numbers[6, 8].ToString());
            Console.WriteLine(Numbers[7, 0].ToString() + Numbers[7, 1].ToString() + Numbers[7, 2].ToString() + Numbers[7, 3].ToString()
                          + Numbers[7, 4].ToString() + Numbers[7, 5].ToString() + Numbers[7, 6].ToString() + Numbers[7, 7].ToString() + Numbers[7, 8].ToString());
            Console.WriteLine(Numbers[8, 0].ToString() + Numbers[8, 1].ToString() + Numbers[8, 2].ToString() + Numbers[8, 3].ToString()
              + Numbers[8, 4].ToString() + Numbers[8, 5].ToString() + Numbers[8, 6].ToString() + Numbers[8, 7].ToString() + Numbers[8, 8].ToString());
            Console.WriteLine("-----------------------------------------------------");


        }
        private void ChangeCells(int v1, int v2) {
            int[] a, b;
            a= new int[9];
            b = new int[9];
            for (int i = 0; i < 9; i++)
            {
                a[i] = Numbers[v1, i];
                b[i] = Numbers[v2, i];
            }
            for (int i=0; i<9; i++)
            {
                Numbers[v1, i] = b[i];
                Numbers[v2, i] = a[i];
            }
            Console.WriteLine("V1" + v1 + "V2" + v2);
            Console.WriteLine("a= "+a[0].ToString()+a[1].ToString()+a[2].ToString()+a[3].ToString()+a[4].ToString()+a[5].ToString()+a[6].ToString()+a[7].ToString()+a[8].ToString());
            Console.WriteLine("b=" + b[0].ToString() + b[1].ToString() + b[2].ToString() + b[3].ToString() + b[4].ToString() + b[5].ToString() + b[6].ToString() + b[7].ToString() + b[8].ToString());
            Console.WriteLine("Numbers[v1]=" + Numbers[v1,0].ToString(),Numbers[v1,1].ToString(),Numbers[v1,2].ToString()
                , Numbers[v1,3].ToString(), Numbers[v1,4].ToString(), Numbers[v1,5].ToString(), Numbers[v1,6].ToString(), Numbers[v1,7].ToString(),
                Numbers[v1,8].ToString());
            Console.WriteLine("Numbers[v2]=" + Numbers[v2, 0].ToString(), Numbers[v2, 1].ToString(), Numbers[v2, 2].ToString()
    , Numbers[v2, 3].ToString(), Numbers[v2, 4].ToString(), Numbers[v2, 5].ToString(), Numbers[v2, 6].ToString(), Numbers[v2, 7].ToString(),
    Numbers[v2, 8].ToString());


        }




        private void Update(int grid) {
            for(int i=0; i<grid; i++)
            {
                var rnd1 = new Random(Guid.NewGuid().GetHashCode());
                var rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int x = rnd1.Next(0, 9);
                int y = rnd2.Next(0, 9);
                Console.WriteLine("x=" + x + "y="+y);
                if (x!=y)
                {
                    Console.WriteLine("Entró");
                    ChangeCells(x, y);
                }
            }
            Console.WriteLine(Numbers[0, 0].ToString() + Numbers[0, 1].ToString() + Numbers[0, 2].ToString() + Numbers[0, 3].ToString()
    + Numbers[0, 4].ToString() + Numbers[0, 5].ToString() + Numbers[0, 6].ToString() + Numbers[0, 7].ToString() + Numbers[0, 8].ToString());
            Console.WriteLine(Numbers[1, 0].ToString() + Numbers[1, 1].ToString() + Numbers[1, 2].ToString() + Numbers[1, 3].ToString()
              + Numbers[1, 4].ToString() + Numbers[1, 5].ToString() + Numbers[1, 6].ToString() + Numbers[1, 7].ToString() + Numbers[1, 8].ToString());
            Console.WriteLine(Numbers[2, 0].ToString() + Numbers[2, 1].ToString() + Numbers[2, 2].ToString() + Numbers[2, 3].ToString()
                          + Numbers[2, 4].ToString() + Numbers[2, 5].ToString() + Numbers[2, 6].ToString() + Numbers[2, 7].ToString() + Numbers[2, 8].ToString());
            Console.WriteLine(Numbers[3, 0].ToString() + Numbers[3, 1].ToString() + Numbers[3, 2].ToString() + Numbers[3, 3].ToString()
              + Numbers[3, 4].ToString() + Numbers[3, 5].ToString() + Numbers[3, 6].ToString() + Numbers[3, 7].ToString() + Numbers[3, 8].ToString());
            Console.WriteLine(Numbers[4, 0].ToString() + Numbers[4, 1].ToString() + Numbers[4, 2].ToString() + Numbers[4, 3].ToString()
                          + Numbers[4, 4].ToString() + Numbers[4, 5].ToString() + Numbers[4, 6].ToString() + Numbers[4, 7].ToString() + Numbers[4, 8].ToString());
            Console.WriteLine(Numbers[5, 0].ToString() + Numbers[5, 1].ToString() + Numbers[5, 2].ToString() + Numbers[5, 3].ToString()
                          + Numbers[5, 4].ToString() + Numbers[5, 5].ToString() + Numbers[5, 6].ToString() + Numbers[5, 7].ToString() + Numbers[5, 8].ToString());
            Console.WriteLine(Numbers[6, 0].ToString() + Numbers[6, 1].ToString() + Numbers[6, 2].ToString() + Numbers[6, 3].ToString()
                          + Numbers[6, 4].ToString() + Numbers[6, 5].ToString() + Numbers[6, 6].ToString() + Numbers[6, 7].ToString() + Numbers[6, 8].ToString());
            Console.WriteLine(Numbers[7, 0].ToString() + Numbers[7, 1].ToString() + Numbers[7, 2].ToString() + Numbers[7, 3].ToString()
                          + Numbers[7, 4].ToString() + Numbers[7, 5].ToString() + Numbers[7, 6].ToString() + Numbers[7, 7].ToString() + Numbers[7, 8].ToString());
            Console.WriteLine(Numbers[8, 0].ToString() + Numbers[8, 1].ToString() + Numbers[8, 2].ToString() + Numbers[8, 3].ToString()
              + Numbers[8, 4].ToString() + Numbers[8, 5].ToString() + Numbers[8, 6].ToString() + Numbers[8, 7].ToString() + Numbers[8, 8].ToString());
            Console.WriteLine("-----------------------------------------------------");


        }

        /*
        public void PieceGenerator()
        
        {
            List<int[,]> cell = new List<int[,]>();
            var rnd1 = new Random(Guid.NewGuid().GetHashCode());
            var rnd2 = new Random(Guid.NewGuid().GetHashCode());
            for (int i=0; i<9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int x = rnd1.Next(1, 8);
                    int y = rnd2.Next(1, 8);
                    if (x == 1)
                    {
                        if ((!SearchCell(cell, i, j)) & (!SearchCell(cell, i, j + 1)) & (!SearchCell(cell, i, j + 2)) & (!SearchCell(cell, i, j + 3)))
                        {
                            pieces.Add(new Piece(x, y, i, j, i, j + 1, i, j + 2, i, j + 3));
                        }

                    }
                    else if (x == 2)
                    {
                        if ((!SearchCell(cell, i, j)) & (!SearchCell(cell, i, j + 1)) & (!SearchCell(cell, i, j + 2)) & (!SearchCell(cell, i+1, j + 2)))
                        {
                            pieces.Add(new Piece(x, y, i, j, i, j + 1, i, j + 2, i+1, j + 2));
                        }
                    }
                    else if (x == 3)
                    {
                        if ((!SearchCell(cell, i, j)) & (!SearchCell(cell, i, j + 1)) & (!SearchCell(cell, i, j + 2)) & (!SearchCell(cell, i -1, j + 2)))
                        {
                            pieces.Add(new Piece(x, y, i, j, i, j + 1, i, j + 2, i -1, j + 2));
                        }
                    }
                    else if (x == 4)
                    {
                        if ((!SearchCell(cell, i, j)) & (!SearchCell(cell, i+1, j)) & (!SearchCell(cell, i, j+1)) & (!SearchCell(cell, i+1, j+1)))
                        {

                        }


                    }
                }
            }        
        }
        public bool SearchCell(List<int[,]> cell, int x, int y)
        {
            bool z = false;
            for(int i=0; i< cell.Capacity; i++) {
                int row = cell[i][0,0];
                int clm = cell[i][0, 1];
                if(row==x & clm == y)
                {
                    z = true; 
                }
            }
            return z;
        } */
        public override string ToString()
        {
            var SB = new StringBuilder();
            for(int i=0; i< 9; i++)
            {
                for(int j=0; j<9; i++)
                {
                    SB.Append(Numbers[i,j]);
                }
            }
            return base.ToString();
        }
    }
}
