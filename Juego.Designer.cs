namespace laberinto
{
    partial class Formulario_Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNombre_Textura1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contenedor_laberinto = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboColumnaD = new System.Windows.Forms.ComboBox();
            this.comboFilaD = new System.Windows.Forms.ComboBox();
            this.comboColumnaO = new System.Windows.Forms.ComboBox();
            this.comboFilaO = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapaToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // mapaToolStripMenuItem
            // 
            this.mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            this.mapaToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.mapaToolStripMenuItem.Text = "Mapa";
            this.mapaToolStripMenuItem.Click += new System.EventHandler(this.mapaToolStripMenuItem_Click);
            // 
            // labelNombre_Textura1
            // 
            this.labelNombre_Textura1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre_Textura1.AutoSize = true;
            this.labelNombre_Textura1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre_Textura1.Location = new System.Drawing.Point(7, 0);
            this.labelNombre_Textura1.Name = "labelNombre_Textura1";
            this.labelNombre_Textura1.Size = new System.Drawing.Size(198, 28);
            this.labelNombre_Textura1.TabIndex = 8;
            this.labelNombre_Textura1.Text = "Selecciona 1 Personaje:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 13;
            this.comboBox1.Location = new System.Drawing.Point(7, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Manhattan";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "Euclidiana";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Origen:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Destino:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(26, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 71);
            this.button1.TabIndex = 15;
            this.button1.Text = "JUGAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 76);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "función";
            // 
            // contenedor_laberinto
            // 
            this.contenedor_laberinto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedor_laberinto.AutoScroll = true;
            this.contenedor_laberinto.AutoSize = true;
            this.contenedor_laberinto.Location = new System.Drawing.Point(12, 27);
            this.contenedor_laberinto.MaximumSize = new System.Drawing.Size(1000, 650);
            this.contenedor_laberinto.Name = "contenedor_laberinto";
            this.contenedor_laberinto.Size = new System.Drawing.Size(371, 332);
            this.contenedor_laberinto.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.comboColumnaD);
            this.panel1.Controls.Add(this.comboFilaD);
            this.panel1.Controls.Add(this.comboColumnaO);
            this.panel1.Controls.Add(this.comboFilaO);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labelNombre_Textura1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(389, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 332);
            this.panel1.TabIndex = 20;
            // 
            // comboColumnaD
            // 
            this.comboColumnaD.Enabled = false;
            this.comboColumnaD.FormattingEnabled = true;
            this.comboColumnaD.Location = new System.Drawing.Point(145, 190);
            this.comboColumnaD.Name = "comboColumnaD";
            this.comboColumnaD.Size = new System.Drawing.Size(50, 21);
            this.comboColumnaD.TabIndex = 20;
            this.comboColumnaD.SelectedIndexChanged += new System.EventHandler(this.comboColumnaD_SelectedIndexChanged);
            // 
            // comboFilaD
            // 
            this.comboFilaD.Enabled = false;
            this.comboFilaD.FormattingEnabled = true;
            this.comboFilaD.Location = new System.Drawing.Point(89, 190);
            this.comboFilaD.Name = "comboFilaD";
            this.comboFilaD.Size = new System.Drawing.Size(50, 21);
            this.comboFilaD.TabIndex = 19;
            this.comboFilaD.SelectedIndexChanged += new System.EventHandler(this.comboFilaD_SelectedIndexChanged);
            // 
            // comboColumnaO
            // 
            this.comboColumnaO.Enabled = false;
            this.comboColumnaO.FormattingEnabled = true;
            this.comboColumnaO.Location = new System.Drawing.Point(145, 163);
            this.comboColumnaO.Name = "comboColumnaO";
            this.comboColumnaO.Size = new System.Drawing.Size(50, 21);
            this.comboColumnaO.TabIndex = 18;
            this.comboColumnaO.SelectedIndexChanged += new System.EventHandler(this.comboColumnaO_SelectedIndexChanged);
            // 
            // comboFilaO
            // 
            this.comboFilaO.Enabled = false;
            this.comboFilaO.FormattingEnabled = true;
            this.comboFilaO.Location = new System.Drawing.Point(89, 163);
            this.comboFilaO.Name = "comboFilaO";
            this.comboFilaO.Size = new System.Drawing.Size(50, 21);
            this.comboFilaO.TabIndex = 17;
            this.comboFilaO.SelectedIndexChanged += new System.EventHandler(this.comboFilaO_SelectedIndexChanged);
            // 
            // Formulario_Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(594, 371);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contenedor_laberinto);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(610, 410);
            this.Name = "Formulario_Juego";
            this.Text = "Juego";
            this.Shown += new System.EventHandler(this.Formulario_Juego_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_Juego_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Label labelNombre_Textura1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel contenedor_laberinto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboColumnaD;
        private System.Windows.Forms.ComboBox comboFilaD;
        private System.Windows.Forms.ComboBox comboColumnaO;
        private System.Windows.Forms.ComboBox comboFilaO;
        private System.Windows.Forms.ToolStripMenuItem mapaToolStripMenuItem;
    }
}