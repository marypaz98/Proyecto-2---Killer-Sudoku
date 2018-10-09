using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_2___Killer_Sudoku
{
    public partial class Form1 : Form
    {
        private Generador _generador;
        private File archivoSudoku = new File();
        private Solver _solver;
        int hilos;
        int tamaño;
        public Form1()
        {

            InitializeComponent();

           
        }
        private void ShowGame() {
            this._generador = new Generador(tamaño);
            int resultado;
            string simbolo;
            string concatenado;
            var rnd1 = new Random(Guid.NewGuid().GetHashCode());
            for (int row=0; row< PanelGenerador.RowCount; row++)
            {
                for(int clm=0; clm<PanelGenerador.ColumnCount; clm++)
                {
                    var box = GetTextBoxAt(row, clm);
                    if (box != null)
                    {
                     //   int x = rnd1.Next(1, 3);
                      //  if (x == 1)
                       // {
                        //    if (this._generador.Numbers[row, clm] >= 10)
                        //    {
                        //        int n = this._generador.Numbers[row, clm];
                        //        string hex = n.ToString("X");
                        //        box.Text = hex;
                        //    }
                        //    else
                        //    {
                        //        box.Text = this._generador.Numbers[row, clm].ToString();

                       //     }
                            this._generador.sudoku[row, clm] = 0;
                        //}
                        foreach (Piece pieza in _generador.pieces)
                        {
                            
                            if (row == pieza.cell1[0] && clm == pieza.cell1[1])
                            {
                                if (pieza.Figure != 1)
                                {
                                    if (pieza.symbol == 1)
                                    {
                                        resultado = _generador.Numbers[pieza.cell1[0], pieza.cell1[1]] + _generador.Numbers[pieza.cell2[0], pieza.cell2[1]]
                                        + _generador.Numbers[pieza.cell3[0], pieza.cell3[1]] + _generador.Numbers[pieza.cell4[0], pieza.cell4[1]];
                                        simbolo = "+";
                                        pieza.resultado = resultado;
                                    }
                                    else
                                    {
                                        resultado = _generador.Numbers[pieza.cell1[0], pieza.cell1[1]] * _generador.Numbers[pieza.cell2[0], pieza.cell2[1]]
                                        * _generador.Numbers[pieza.cell3[0], pieza.cell3[1]] * _generador.Numbers[pieza.cell4[0], pieza.cell4[1]];
                                        simbolo = "x";
                                        pieza.resultado = resultado;
                                    }
                                    this._generador.sudoku[row, clm] = 0;
                                    concatenado = String.Concat(simbolo, resultado);
                                    box.Text = concatenado;

                                }
                                else
                                {
                                    resultado = _generador.Numbers[pieza.cell1[0], pieza.cell1[1]];
                                    if (resultado >= 10)
                                    {
                                        string hex = resultado.ToString("X");
                                        box.Text = hex;
                                    }
                                    else
                                    {
                                        concatenado = resultado.ToString();
                                        box.Text = concatenado;
                                        
                                    }
                                    this._generador.sudoku[row, clm] = resultado;
                                }
                            }



                        }
                        
                        }

                        
                        switch (this._generador.piezas[row, clm])
                        {
                            case 1:
                                box.BackColor = Color.SlateGray;
                                break;
                            case 2:
                                box.BackColor = Color.Blue;
                                break;
                            case 3:
                                box.BackColor = Color.Green;
                                break;
                            case 4:
                                box.BackColor = Color.Yellow;
                                break;
                            case 5:
                                box.BackColor = Color.RosyBrown; 
                               break;
                            case 6:
                                box.BackColor = Color.Fuchsia;
                                break;
                            case 7:
                                box.BackColor = Color.Red;
                                break;
                            case 8:
                                box.BackColor = Color.MediumAquamarine;
                                break;
                            case 9:
                                box.BackColor = Color.Indigo;
                                break;
                            case 10:
                                box.BackColor = Color.LightSalmon;
                                break;
                            case 11:
                                box.BackColor = Color.Turquoise;
                                break;
                            case 12:
                                box.BackColor = Color.Maroon;
                                break;
                            case 13:
                                box.BackColor = Color.MidnightBlue;
                                break;
                            case 14:
                                box.BackColor = Color.SkyBlue;
                                break;
                            case 15:
                                box.BackColor = Color.Olive;
                                break;
                            case 16:
                                box.BackColor = Color.Teal;
                                break;
                            case 17:
                                box.BackColor = Color.Plum;
                                break;
                            case 18:
                                box.BackColor = Color.RosyBrown;
                                break;
                            case 19:
                                box.BackColor = Color.Purple;
                                break;
                            case 20:
                                box.BackColor = Color.SeaShell;
                                break;
                        }
                    }
                }
            
            }
        private void ShowGameOtherPanel()
        {
            _solver = new Solver(tamaño);
            var rnd1 = new Random(Guid.NewGuid().GetHashCode());
            for (int row = 0; row < PanelResuelto.RowCount; row++)
            {
                for (int clm = 0; clm < PanelResuelto.ColumnCount; clm++)
                {
                    var box = GetTextBoxAt1(row, clm);
                    if (box != null)
                    {

                        if (_solver.sudoku[row, clm] >= 10)
                        {
                            int n = this._solver.sudoku[row, clm];
                            string hex = n.ToString("X");
                            box.Text = hex;
                        }
                        else
                        {
                            box.Text = this._solver.sudoku[row, clm].ToString();

                        }
                    }
                    switch (this._solver.pieces[row, clm])
                    {
                        case 1:
                            box.BackColor = Color.SlateGray;
                            break;
                        case 2:
                            box.BackColor = Color.Blue;
                            break;
                        case 3:
                            box.BackColor = Color.Green;
                            break;
                        case 4:
                            box.BackColor = Color.Yellow;
                            break;
                        case 5:
                            box.BackColor = Color.RosyBrown;
                            break;
                        case 6:
                            box.BackColor = Color.Fuchsia;
                            break;
                        case 7:
                            box.BackColor = Color.Red;
                            break;
                        case 8:
                            box.BackColor = Color.MediumAquamarine;
                            break;
                        case 9:
                            box.BackColor = Color.Indigo;
                            break;
                        case 10:
                            box.BackColor = Color.LightSalmon;
                            break;
                        case 11:
                            box.BackColor = Color.Turquoise;
                            break;
                        case 12:
                            box.BackColor = Color.Maroon;
                            break;
                        case 13:
                            box.BackColor = Color.MidnightBlue;
                            break;
                        case 14:
                            box.BackColor = Color.SkyBlue;
                            break;
                        case 15:
                            box.BackColor = Color.Olive;
                            break;
                        case 16:
                            box.BackColor = Color.Teal;
                            break;
                        case 17:
                            box.BackColor = Color.Plum;
                            break;
                        case 18:
                            box.BackColor = Color.RosyBrown;
                            break;
                        case 19:
                            box.BackColor = Color.Purple;
                            break;
                        case 20:
                            box.BackColor = Color.SeaShell;
                            break;
                    }
                }
            }             
        }
        
        private void Clear()
        {
            int[] simbolo = new int[_generador.contadordePiezas];
            int[] resultado= new int[_generador.contadordePiezas];
            int[,] celdas;
            int cont = 0;
            celdas= new int[_generador.ColmAndRow, _generador.ColmAndRow];
            foreach(Piece pieza in _generador.pieces)
            {
                if (pieza.Figure != 1)
                {
                    resultado[cont]= _generador.Numbers[pieza.cell1[0], pieza.cell1[1]]+ _generador.Numbers[pieza.cell2[0], pieza.cell2[1]]
                        + _generador.Numbers[pieza.cell3[0], pieza.cell3[1]]+ _generador.Numbers[pieza.cell4[0], pieza.cell4[1]];
                    simbolo[cont] = pieza.symbol;
                    celdas[pieza.cell1[0], pieza.cell1[1]] = resultado[cont];
                    cont++;
                }
            }
        }
 
        private TextBox GetTextBoxAt(int row, int clm)
        {
            return (TextBox)PanelGenerador.GetControlFromPosition(row,clm);
        }
        private TextBox GetTextBoxAt1(int row, int clm)
        {
            return (TextBox)PanelResuelto.GetControlFromPosition(row, clm);
        }
        private void CreateTextBoxes() {
            for (int row=0; row<PanelGenerador.RowCount; row++)
            {
                for(int clm=0; clm<PanelGenerador.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Maiandra GD", 9f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke

                    };
                    textBox.KeyPress += textBox_KeyPress;
                   
                    PanelGenerador.Controls.Add(textBox, row, clm);
                    

                }
            }
        }
        private void CreateTextBoxes1()
        {
            for (int row = 0; row < PanelResuelto.RowCount; row++)
            {
                for (int clm = 0; clm < PanelResuelto.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Maiandra GD", 9f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke

                    };
                    textBox.KeyPress += textBox_KeyPress;
                    PanelResuelto.Controls.Add(textBox, row, clm);

                }
            }
        }
        static void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case ' ':
                        e.Handled = false;
                        break;
                    case (char)Keys.Back:
                        e.Handled = false;
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            }
            else
            {
                e.Handled = false;
            }
            if (!(e.KeyChar == ' ' | e.KeyChar == '0')) return;
            e.KeyChar = (char)Keys.Back;
        }


            private void PanelGenerador_Paint(object sender, PaintEventArgs e)
        {
            

          //  e.Graphics.FillRectangle(Brushes.Blue, 0, 0, PanelGenerador.Width, height);
          //  e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 2).Left, GetTextBoxAt(0, 2).Bottom, PanelGenerador.Width, height);
          //  e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 5).Left, GetTextBoxAt(0, 5).Bottom, PanelGenerador.Width, height);
          //  e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 8).Left, GetTextBoxAt(0, 8).Bottom, PanelGenerador.Width, height);

           // e.Graphics.FillRectangle(Brushes.Blue, 0, 0, height, PanelGenerador.Width);
           // e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(2, 0).Right, GetTextBoxAt(2, 0).Top, height, PanelGenerador.Height);
           // e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(5, 0).Right, GetTextBoxAt(5, 0).Top, height, PanelGenerador.Height);
          //  e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(8, 0).Right, GetTextBoxAt(8, 0).Top, height, PanelGenerador.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                archivoSudoku.WriteFile(_solver.sudoku, _solver.piezas, "sudokuGuardado");
                MessageBox.Show("Killer sudoku guardado con éxito","Éxito");
            }
            catch(Exception z)
            {
                MessageBox.Show("Error al guardar el killer sudoku", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
           string h = textBoxHilos.Text;          
            string n = textBoxTamaño.Text;
            if (string.IsNullOrEmpty(h) || string.IsNullOrEmpty(n))
            {
                MessageBox.Show("Debe ingresar el tamaño y el número de hilos", "Error");
            }
            else if (!Int32.TryParse(n, out tamaño) || !Int32.TryParse(h, out hilos))
            {
                MessageBox.Show("Los valores ingresados deben ser numeros", "Error");
            }
            else
            {
                
                Int32.TryParse(n, out tamaño);
                Int32.TryParse(h, out hilos);
                PanelGenerador.RowCount = tamaño;
                PanelGenerador.ColumnCount = tamaño;
                PanelResuelto.RowCount = tamaño;
                PanelResuelto.ColumnCount = tamaño;
                determinarAnchoPanelGenerador();
                determinarAnchoPanelResuelto();
                PanelGenerador.AutoScroll = true;
                PanelResuelto.AutoScroll = true;
                CreateTextBoxes();
                CreateTextBoxes1();
                ShowGame();
                archivoSudoku.WriteFile(_generador.sudoku, _generador.pieces, "killerSudoku");
                ShowGameOtherPanel();
            }
            }
        public void determinarAnchoPanelGenerador()
        {
            foreach(ColumnStyle item in PanelGenerador.ColumnStyles){
                item.Width = 52;
                item.SizeType = SizeType.Absolute;
            }
            foreach (RowStyle ite in PanelGenerador.RowStyles)
            {
                ite.Height = 46;
                ite.SizeType = SizeType.Absolute;

            }
        }
        public void determinarAnchoPanelResuelto()
        {
            foreach(ColumnStyle item in PanelResuelto.ColumnStyles)
            {
                item.Width = 50;
                item.SizeType = SizeType.Absolute;
            }
            foreach(RowStyle ite in PanelResuelto.RowStyles)
            {
                ite.Height = 47;
                ite.SizeType = SizeType.Absolute;
                
            }
        }
   

        
    }
}
