using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2___Killer_Sudoku
{
    public partial class Form1 : Form
    {
        private Generador _generador;
        public Form1()
        {

            InitializeComponent();
            CreateTextBoxes();
            ShowGame();
        }
        private void ShowGame() {
            this._generador = new Generador();
            Console.WriteLine(_generador.Numbers[0,0].ToString()+ _generador.Numbers[0, 1].ToString() + _generador.Numbers[0, 2].ToString() + _generador.Numbers[0, 3].ToString()
                + _generador.Numbers[0, 4].ToString() + _generador.Numbers[0, 5].ToString() + _generador.Numbers[0, 6].ToString() + _generador.Numbers[0, 7].ToString() + _generador.Numbers[0, 8].ToString());
            Console.WriteLine(_generador.Numbers[1, 0].ToString() + _generador.Numbers[1, 1].ToString() + _generador.Numbers[1, 2].ToString() + _generador.Numbers[1, 3].ToString()
              + _generador.Numbers[1, 4].ToString() + _generador.Numbers[1, 5].ToString() + _generador.Numbers[1, 6].ToString() + _generador.Numbers[1, 7].ToString() + _generador.Numbers[1, 8].ToString());
            Console.WriteLine(_generador.Numbers[2, 0].ToString() + _generador.Numbers[2, 1].ToString() + _generador.Numbers[2, 2].ToString() + _generador.Numbers[2, 3].ToString()
                          + _generador.Numbers[2, 4].ToString() + _generador.Numbers[2, 5].ToString() + _generador.Numbers[2, 6].ToString() + _generador.Numbers[2, 7].ToString() + _generador.Numbers[2, 8].ToString());
            Console.WriteLine(_generador.Numbers[3, 0].ToString() + _generador.Numbers[3, 1].ToString() + _generador.Numbers[3, 2].ToString() + _generador.Numbers[3, 3].ToString()
              + _generador.Numbers[3, 4].ToString() + _generador.Numbers[3, 5].ToString() + _generador.Numbers[3, 6].ToString() + _generador.Numbers[3, 7].ToString() + _generador.Numbers[3, 8].ToString());
            Console.WriteLine(_generador.Numbers[4, 0].ToString() + _generador.Numbers[4, 1].ToString() + _generador.Numbers[4, 2].ToString() + _generador.Numbers[4, 3].ToString()
                          + _generador.Numbers[4, 4].ToString() + _generador.Numbers[4, 5].ToString() + _generador.Numbers[4, 6].ToString() + _generador.Numbers[4, 7].ToString() + _generador.Numbers[4, 8].ToString());
            Console.WriteLine(_generador.Numbers[5, 0].ToString() + _generador.Numbers[5, 1].ToString() + _generador.Numbers[5, 2].ToString() + _generador.Numbers[5, 3].ToString()
                          + _generador.Numbers[5, 4].ToString() + _generador.Numbers[5, 5].ToString() + _generador.Numbers[5, 6].ToString() + _generador.Numbers[5, 7].ToString() + _generador.Numbers[5, 8].ToString());
            Console.WriteLine(_generador.Numbers[6, 0].ToString() + _generador.Numbers[6, 1].ToString() + _generador.Numbers[6, 2].ToString() + _generador.Numbers[6, 3].ToString()
                          + _generador.Numbers[6, 4].ToString() + _generador.Numbers[6, 5].ToString() + _generador.Numbers[6, 6].ToString() + _generador.Numbers[6, 7].ToString() + _generador.Numbers[6, 8].ToString());
            Console.WriteLine(_generador.Numbers[7, 0].ToString() + _generador.Numbers[7, 1].ToString() + _generador.Numbers[7, 2].ToString() + _generador.Numbers[7, 3].ToString()
                          + _generador.Numbers[7, 4].ToString() + _generador.Numbers[7, 5].ToString() + _generador.Numbers[7, 6].ToString() + _generador.Numbers[7, 7].ToString() + _generador.Numbers[7, 8].ToString());
            Console.WriteLine(_generador.Numbers[8, 0].ToString() + _generador.Numbers[8, 1].ToString() + _generador.Numbers[8, 2].ToString() + _generador.Numbers[8, 3].ToString()
              + _generador.Numbers[8, 4].ToString() + _generador.Numbers[8, 5].ToString() + _generador.Numbers[8, 6].ToString() + _generador.Numbers[8, 7].ToString() + _generador.Numbers[8, 8].ToString());

            for (int row=0; row< PanelGenerador.RowCount; row++)
            {
                for(int clm=0; clm<PanelGenerador.ColumnCount; clm++)
                {
                    var box = GetTextBoxAt(row, clm);
                    if (box != null)
                    {
                        box.Text = this._generador.Numbers[clm, row].ToString();
                    }
                }
            }
        }
        private TextBox GetTextBoxAt(int row, int clm)
        {
            return (TextBox)PanelGenerador.GetControlFromPosition(row,clm);
        }
        private void CreateTextBoxes() {
            for (int row=0; row<PanelGenerador.RowCount; row++)
            {
                for(int clm=0; clm<PanelGenerador.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Maiandra GD", 20f, FontStyle.Bold),
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
            var height = GetTextBoxAt(0, 3).Top - GetTextBoxAt(0, 2).Bottom;

            e.Graphics.FillRectangle(Brushes.Blue, 0, 0, PanelGenerador.Width, height);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 2).Left, GetTextBoxAt(0, 2).Bottom, PanelGenerador.Width, height);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 5).Left, GetTextBoxAt(0, 5).Bottom, PanelGenerador.Width, height);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(0, 8).Left, GetTextBoxAt(0, 8).Bottom, PanelGenerador.Width, height);

            e.Graphics.FillRectangle(Brushes.Blue, 0, 0, height, PanelGenerador.Width);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(2, 0).Right, GetTextBoxAt(2, 0).Top, height, PanelGenerador.Height);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(5, 0).Right, GetTextBoxAt(5, 0).Top, height, PanelGenerador.Height);
            e.Graphics.FillRectangle(Brushes.Blue, GetTextBoxAt(8, 0).Right, GetTextBoxAt(8, 0).Top, height, PanelGenerador.Height);

        }
    }
}
