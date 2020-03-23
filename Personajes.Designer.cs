namespace laberinto
{
    partial class Configurador_personajes
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
            this.Label_ConfiguracionTerreno = new System.Windows.Forms.Label();
            this.btn_SiguientePersonaje = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Num_Personajes = new System.Windows.Forms.ComboBox();
            this.panel_contenedor_personajes = new System.Windows.Forms.Panel();
            this.boton_guardar_personaje = new System.Windows.Forms.Button();
            this.contenedor_botones = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Label_ConfiguracionTerreno
            // 
            this.Label_ConfiguracionTerreno.AutoSize = true;
            this.Label_ConfiguracionTerreno.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ConfiguracionTerreno.Location = new System.Drawing.Point(448, 9);
            this.Label_ConfiguracionTerreno.Name = "Label_ConfiguracionTerreno";
            this.Label_ConfiguracionTerreno.Size = new System.Drawing.Size(347, 47);
            this.Label_ConfiguracionTerreno.TabIndex = 3;
            this.Label_ConfiguracionTerreno.Text = "Configuración Personaje\r\n";
            // 
            // btn_SiguientePersonaje
            // 
            this.btn_SiguientePersonaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SiguientePersonaje.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SiguientePersonaje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SiguientePersonaje.Enabled = false;
            this.btn_SiguientePersonaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SiguientePersonaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SiguientePersonaje.Location = new System.Drawing.Point(1006, 465);
            this.btn_SiguientePersonaje.Name = "btn_SiguientePersonaje";
            this.btn_SiguientePersonaje.Size = new System.Drawing.Size(103, 37);
            this.btn_SiguientePersonaje.TabIndex = 5;
            this.btn_SiguientePersonaje.Text = "Siguiente";
            this.btn_SiguientePersonaje.UseVisualStyleBackColor = false;
            this.btn_SiguientePersonaje.Click += new System.EventHandler(this.btn_SiguientePersonaje_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "¿Cuántos personajes deseas crear?";
            // 
            // CB_Num_Personajes
            // 
            this.CB_Num_Personajes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_Num_Personajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Num_Personajes.FormattingEnabled = true;
            this.CB_Num_Personajes.Location = new System.Drawing.Point(277, 67);
            this.CB_Num_Personajes.Name = "CB_Num_Personajes";
            this.CB_Num_Personajes.Size = new System.Drawing.Size(80, 26);
            this.CB_Num_Personajes.TabIndex = 7;
            this.CB_Num_Personajes.SelectionChangeCommitted += new System.EventHandler(this.CB_Num_Personajes_SelectionChangeCommitted_1);
            // 
            // panel_contenedor_personajes
            // 
            this.panel_contenedor_personajes.AutoSize = true;
            this.panel_contenedor_personajes.Location = new System.Drawing.Point(140, 99);
            this.panel_contenedor_personajes.Name = "panel_contenedor_personajes";
            this.panel_contenedor_personajes.Size = new System.Drawing.Size(969, 335);
            this.panel_contenedor_personajes.TabIndex = 13;
            // 
            // boton_guardar_personaje
            // 
            this.boton_guardar_personaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boton_guardar_personaje.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.boton_guardar_personaje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.boton_guardar_personaje.Enabled = false;
            this.boton_guardar_personaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boton_guardar_personaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_guardar_personaje.Location = new System.Drawing.Point(494, 465);
            this.boton_guardar_personaje.Name = "boton_guardar_personaje";
            this.boton_guardar_personaje.Size = new System.Drawing.Size(109, 37);
            this.boton_guardar_personaje.TabIndex = 14;
            this.boton_guardar_personaje.Text = "Guardar";
            this.boton_guardar_personaje.UseVisualStyleBackColor = false;
            this.boton_guardar_personaje.Click += new System.EventHandler(this.boton_guardar_personaje_Click);
            // 
            // contenedor_botones
            // 
            this.contenedor_botones.Location = new System.Drawing.Point(7, 99);
            this.contenedor_botones.Name = "contenedor_botones";
            this.contenedor_botones.Size = new System.Drawing.Size(133, 334);
            this.contenedor_botones.TabIndex = 15;
            // 
            // Configurador_personajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 514);
            this.Controls.Add(this.contenedor_botones);
            this.Controls.Add(this.boton_guardar_personaje);
            this.Controls.Add(this.panel_contenedor_personajes);
            this.Controls.Add(this.CB_Num_Personajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SiguientePersonaje);
            this.Controls.Add(this.Label_ConfiguracionTerreno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Configurador_personajes";
            this.Text = "Personaje";
            this.Load += new System.EventHandler(this.Form_Personaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_ConfiguracionTerreno;
        private System.Windows.Forms.Button btn_SiguientePersonaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Num_Personajes;
        private System.Windows.Forms.Panel panel_contenedor_personajes;
        private System.Windows.Forms.Button boton_guardar_personaje;
        private System.Windows.Forms.Panel contenedor_botones;
    }
}