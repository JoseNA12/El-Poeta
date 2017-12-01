namespace Proyecto_3_AA
{
    partial class InterfaceU
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
            this.textBox_PoemaMeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPoemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_PoemasGenerados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_NumGeneraciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_tipoRecorrido = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_PoemaMeta
            // 
            this.textBox_PoemaMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PoemaMeta.Location = new System.Drawing.Point(36, 77);
            this.textBox_PoemaMeta.Multiline = true;
            this.textBox_PoemaMeta.Name = "textBox_PoemaMeta";
            this.textBox_PoemaMeta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_PoemaMeta.Size = new System.Drawing.Size(477, 193);
            this.textBox_PoemaMeta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Poema meta:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArchivoToolStripMenuItem,
            this.generarPoemasToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir archivo...";
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            // 
            // generarPoemasToolStripMenuItem
            // 
            this.generarPoemasToolStripMenuItem.Name = "generarPoemasToolStripMenuItem";
            this.generarPoemasToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.generarPoemasToolStripMenuItem.Text = "Generar Poemas";
            this.generarPoemasToolStripMenuItem.Click += new System.EventHandler(this.generarPoemasToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informaciónToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.informaciónToolStripMenuItem.Text = "Información";
            // 
            // textBox_PoemasGenerados
            // 
            this.textBox_PoemasGenerados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PoemasGenerados.Location = new System.Drawing.Point(36, 305);
            this.textBox_PoemasGenerados.Multiline = true;
            this.textBox_PoemasGenerados.Name = "textBox_PoemasGenerados";
            this.textBox_PoemasGenerados.ReadOnly = true;
            this.textBox_PoemasGenerados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_PoemasGenerados.Size = new System.Drawing.Size(647, 222);
            this.textBox_PoemasGenerados.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Poemas generados:";
            // 
            // textBox_NumGeneraciones
            // 
            this.textBox_NumGeneraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NumGeneraciones.Location = new System.Drawing.Point(549, 77);
            this.textBox_NumGeneraciones.Name = "textBox_NumGeneraciones";
            this.textBox_NumGeneraciones.Size = new System.Drawing.Size(126, 24);
            this.textBox_NumGeneraciones.TabIndex = 5;
            this.textBox_NumGeneraciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NumGeneraciones_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(546, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "No. de generaciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(549, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Recorrido";
            // 
            // comboBox_tipoRecorrido
            // 
            this.comboBox_tipoRecorrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_tipoRecorrido.FormattingEnabled = true;
            this.comboBox_tipoRecorrido.Items.AddRange(new object[] {
            "Chebyshev",
            "Manhattan",
            "Propia"});
            this.comboBox_tipoRecorrido.Location = new System.Drawing.Point(552, 159);
            this.comboBox_tipoRecorrido.Name = "comboBox_tipoRecorrido";
            this.comboBox_tipoRecorrido.Size = new System.Drawing.Size(123, 26);
            this.comboBox_tipoRecorrido.Sorted = true;
            this.comboBox_tipoRecorrido.TabIndex = 8;
            this.comboBox_tipoRecorrido.Text = "Chebyshev";
            // 
            // InterfaceU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 564);
            this.Controls.Add(this.comboBox_tipoRecorrido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_NumGeneraciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PoemasGenerados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_PoemaMeta);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InterfaceU";
            this.Text = "El Poeta";
            this.Load += new System.EventHandler(this.Interfaz_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_PoemaMeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_PoemasGenerados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem generarPoemasToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_NumGeneraciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_tipoRecorrido;
    }
}

