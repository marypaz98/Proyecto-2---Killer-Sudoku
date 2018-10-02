namespace Proyecto_2___Killer_Sudoku
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonResolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHilos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTamaño = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PanelGenerador = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelResuelto = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonResolver
            // 
            this.buttonResolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonResolver.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResolver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonResolver.Location = new System.Drawing.Point(822, 178);
            this.buttonResolver.Name = "buttonResolver";
            this.buttonResolver.Size = new System.Drawing.Size(98, 44);
            this.buttonResolver.TabIndex = 2;
            this.buttonResolver.Text = "Resolver";
            this.buttonResolver.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(814, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hilos:";
            // 
            // textBoxHilos
            // 
            this.textBoxHilos.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHilos.Location = new System.Drawing.Point(871, 12);
            this.textBoxHilos.Name = "textBoxHilos";
            this.textBoxHilos.Size = new System.Drawing.Size(155, 21);
            this.textBoxHilos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(818, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tamaño:";
            // 
            // textBoxTamaño
            // 
            this.textBoxTamaño.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTamaño.Location = new System.Drawing.Point(898, 92);
            this.textBoxTamaño.Name = "textBoxTamaño";
            this.textBoxTamaño.Size = new System.Drawing.Size(128, 21);
            this.textBoxTamaño.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(822, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // PanelGenerador
            // 
            this.PanelGenerador.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PanelGenerador.ColumnCount = 9;
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PanelGenerador.Location = new System.Drawing.Point(1, 2);
            this.PanelGenerador.Name = "PanelGenerador";
            this.PanelGenerador.RowCount = 9;
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.PanelGenerador.Size = new System.Drawing.Size(384, 431);
            this.PanelGenerador.TabIndex = 9;
            this.PanelGenerador.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGenerador_Paint);
            // 
            // tableLayoutPanelResuelto
            // 
            this.tableLayoutPanelResuelto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanelResuelto.ColumnCount = 9;
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanelResuelto.Location = new System.Drawing.Point(412, 2);
            this.tableLayoutPanelResuelto.Name = "tableLayoutPanelResuelto";
            this.tableLayoutPanelResuelto.RowCount = 9;
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanelResuelto.Size = new System.Drawing.Size(383, 431);
            this.tableLayoutPanelResuelto.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1038, 459);
            this.Controls.Add(this.tableLayoutPanelResuelto);
            this.Controls.Add(this.PanelGenerador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTamaño);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHilos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonResolver);
            this.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonResolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHilos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTamaño;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel PanelGenerador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelResuelto;
    }
}

