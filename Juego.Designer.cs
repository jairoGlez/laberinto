﻿namespace laberinto
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
            this.prioridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNombre_Textura1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton_Euclidiana = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Algoritmo_Busqueda = new System.Windows.Forms.ComboBox();
            this.radioButton_Manhattan = new System.Windows.Forms.RadioButton();
            this.contenedor_laberinto = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.boton_reiniciar = new System.Windows.Forms.Button();
            this.tabla_costos = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboColumnaD = new System.Windows.Forms.ComboBox();
            this.comboFilaD = new System.Windows.Forms.ComboBox();
            this.comboFilaO = new System.Windows.Forms.ComboBox();
            this.comboColumnaO = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabla_costos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(660, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapaToolStripMenuItem,
            this.prioridadToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // mapaToolStripMenuItem
            // 
            this.mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            this.mapaToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.mapaToolStripMenuItem.Text = "Mapa";
            this.mapaToolStripMenuItem.Click += new System.EventHandler(this.mapaToolStripMenuItem_Click);
            // 
            // prioridadToolStripMenuItem
            // 
            this.prioridadToolStripMenuItem.Name = "prioridadToolStripMenuItem";
            this.prioridadToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.prioridadToolStripMenuItem.Text = "Prioridad";
            this.prioridadToolStripMenuItem.Click += new System.EventHandler(this.prioridadToolStripMenuItem_Click);
            // 
            // labelNombre_Textura1
            // 
            this.labelNombre_Textura1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNombre_Textura1.AutoSize = true;
            this.labelNombre_Textura1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre_Textura1.Location = new System.Drawing.Point(12, 0);
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
            this.comboBox1.Location = new System.Drawing.Point(17, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // radioButton_Euclidiana
            // 
            this.radioButton_Euclidiana.AutoSize = true;
            this.radioButton_Euclidiana.Checked = true;
            this.radioButton_Euclidiana.Location = new System.Drawing.Point(8, 88);
            this.radioButton_Euclidiana.Name = "radioButton_Euclidiana";
            this.radioButton_Euclidiana.Size = new System.Drawing.Size(74, 17);
            this.radioButton_Euclidiana.TabIndex = 11;
            this.radioButton_Euclidiana.TabStop = true;
            this.radioButton_Euclidiana.Tag = "Euclidiana";
            this.radioButton_Euclidiana.Text = "Euclidiana";
            this.radioButton_Euclidiana.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Origen:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Destino:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(40, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 71);
            this.button1.TabIndex = 15;
            this.button1.Text = "JUGAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button_Jugar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_Algoritmo_Busqueda);
            this.groupBox1.Controls.Add(this.radioButton_Manhattan);
            this.groupBox1.Controls.Add(this.radioButton_Euclidiana);
            this.groupBox1.Location = new System.Drawing.Point(17, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 142);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritmo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Busquedas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Medida:";
            // 
            // comboBox_Algoritmo_Busqueda
            // 
            this.comboBox_Algoritmo_Busqueda.FormattingEnabled = true;
            this.comboBox_Algoritmo_Busqueda.Items.AddRange(new object[] {
            "Manual",
            "Profundidad",
            "Coste uniforme",
            "Voraz primero el mejor",
            "A*"});
            this.comboBox_Algoritmo_Busqueda.Location = new System.Drawing.Point(6, 40);
            this.comboBox_Algoritmo_Busqueda.Name = "comboBox_Algoritmo_Busqueda";
            this.comboBox_Algoritmo_Busqueda.Size = new System.Drawing.Size(203, 21);
            this.comboBox_Algoritmo_Busqueda.TabIndex = 13;
            // 
            // radioButton_Manhattan
            // 
            this.radioButton_Manhattan.AutoSize = true;
            this.radioButton_Manhattan.Location = new System.Drawing.Point(8, 111);
            this.radioButton_Manhattan.Name = "radioButton_Manhattan";
            this.radioButton_Manhattan.Size = new System.Drawing.Size(76, 17);
            this.radioButton_Manhattan.TabIndex = 12;
            this.radioButton_Manhattan.Tag = "Manhattan";
            this.radioButton_Manhattan.Text = "Manhattan";
            this.radioButton_Manhattan.UseVisualStyleBackColor = true;
            // 
            // contenedor_laberinto
            // 
            this.contenedor_laberinto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedor_laberinto.AutoSize = true;
            this.contenedor_laberinto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contenedor_laberinto.Location = new System.Drawing.Point(12, 27);
            this.contenedor_laberinto.MinimumSize = new System.Drawing.Size(398, 398);
            this.contenedor_laberinto.Name = "contenedor_laberinto";
            this.contenedor_laberinto.Size = new System.Drawing.Size(398, 398);
            this.contenedor_laberinto.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.boton_reiniciar);
            this.panel1.Controls.Add(this.tabla_costos);
            this.panel1.Controls.Add(this.comboColumnaD);
            this.panel1.Controls.Add(this.comboFilaD);
            this.panel1.Controls.Add(this.comboFilaO);
            this.panel1.Controls.Add(this.comboColumnaO);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labelNombre_Textura1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(417, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 499);
            this.panel1.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(17, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Guardar costos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.boton_guardar_costos_click);
            // 
            // boton_reiniciar
            // 
            this.boton_reiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boton_reiniciar.Enabled = false;
            this.boton_reiniciar.Location = new System.Drawing.Point(40, 390);
            this.boton_reiniciar.Name = "boton_reiniciar";
            this.boton_reiniciar.Size = new System.Drawing.Size(155, 29);
            this.boton_reiniciar.TabIndex = 22;
            this.boton_reiniciar.Text = "Reiniciar";
            this.boton_reiniciar.UseVisualStyleBackColor = true;
            this.boton_reiniciar.Click += new System.EventHandler(this.button_reiniciar_Click);
            // 
            // tabla_costos
            // 
            this.tabla_costos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabla_costos.AutoSize = true;
            this.tabla_costos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabla_costos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tabla_costos.ColumnCount = 2;
            this.tabla_costos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabla_costos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabla_costos.Controls.Add(this.label1, 0, 0);
            this.tabla_costos.Controls.Add(this.label4, 1, 0);
            this.tabla_costos.Location = new System.Drawing.Point(17, 85);
            this.tabla_costos.Name = "tabla_costos";
            this.tabla_costos.RowCount = 1;
            this.tabla_costos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tabla_costos.Size = new System.Drawing.Size(143, 39);
            this.tabla_costos.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terreno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "Costo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // comboColumnaD
            // 
            this.comboColumnaD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboColumnaD.Enabled = false;
            this.comboColumnaD.FormattingEnabled = true;
            this.comboColumnaD.Location = new System.Drawing.Point(89, 361);
            this.comboColumnaD.Name = "comboColumnaD";
            this.comboColumnaD.Size = new System.Drawing.Size(67, 21);
            this.comboColumnaD.TabIndex = 20;
            this.comboColumnaD.SelectedIndexChanged += new System.EventHandler(this.comboColumnaD_SelectedIndexChanged);
            // 
            // comboFilaD
            // 
            this.comboFilaD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboFilaD.Enabled = false;
            this.comboFilaD.FormattingEnabled = true;
            this.comboFilaD.Location = new System.Drawing.Point(162, 361);
            this.comboFilaD.Name = "comboFilaD";
            this.comboFilaD.Size = new System.Drawing.Size(67, 21);
            this.comboFilaD.TabIndex = 19;
            this.comboFilaD.SelectedIndexChanged += new System.EventHandler(this.comboFilaD_SelectedIndexChanged);
            // 
            // comboFilaO
            // 
            this.comboFilaO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboFilaO.Enabled = false;
            this.comboFilaO.FormattingEnabled = true;
            this.comboFilaO.Location = new System.Drawing.Point(162, 329);
            this.comboFilaO.Name = "comboFilaO";
            this.comboFilaO.Size = new System.Drawing.Size(67, 21);
            this.comboFilaO.TabIndex = 17;
            this.comboFilaO.SelectedIndexChanged += new System.EventHandler(this.comboFilaO_SelectedIndexChanged);
            // 
            // comboColumnaO
            // 
            this.comboColumnaO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboColumnaO.Enabled = false;
            this.comboColumnaO.FormattingEnabled = true;
            this.comboColumnaO.Location = new System.Drawing.Point(89, 329);
            this.comboColumnaO.Name = "comboColumnaO";
            this.comboColumnaO.Size = new System.Drawing.Size(67, 21);
            this.comboColumnaO.TabIndex = 18;
            this.comboColumnaO.SelectedIndexChanged += new System.EventHandler(this.comboColumnaO_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "Prioridad:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(178, 33);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(122, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(66, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(12, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 91);
            this.panel2.TabIndex = 24;
            // 
            // Formulario_Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(660, 546);
            this.Controls.Add(this.panel2);
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
            this.tabla_costos.ResumeLayout(false);
            this.tabla_costos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Label labelNombre_Textura1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton_Euclidiana;
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
        private System.Windows.Forms.TableLayoutPanel tabla_costos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button boton_reiniciar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem prioridadToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_Manhattan;
        private System.Windows.Forms.ComboBox comboBox_Algoritmo_Busqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}