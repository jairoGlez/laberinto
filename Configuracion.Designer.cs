namespace laberinto
{
    partial class Form_Configuracion
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
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelNombre_Textura1 = new System.Windows.Forms.Label();
            this.labelID_Terreno1 = new System.Windows.Forms.Label();
            this.btn_SiguienteTerreno = new System.Windows.Forms.Button();
            this.Label_ConfiguracionTerreno = new System.Windows.Forms.Label();
            this.panel_contenedor.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.panel3);
            this.panel_contenedor.Controls.Add(this.btn_SiguienteTerreno);
            this.panel_contenedor.Controls.Add(this.Label_ConfiguracionTerreno);
            this.panel_contenedor.Location = new System.Drawing.Point(12, 12);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(1094, 501);
            this.panel_contenedor.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.labelNombre_Textura1);
            this.panel3.Controls.Add(this.labelID_Terreno1);
            this.panel3.Location = new System.Drawing.Point(179, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(744, 297);
            this.panel3.TabIndex = 13;
            // 
            // labelNombre_Textura1
            // 
            this.labelNombre_Textura1.AutoSize = true;
            this.labelNombre_Textura1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre_Textura1.Location = new System.Drawing.Point(357, 6);
            this.labelNombre_Textura1.Name = "labelNombre_Textura1";
            this.labelNombre_Textura1.Size = new System.Drawing.Size(158, 28);
            this.labelNombre_Textura1.TabIndex = 7;
            this.labelNombre_Textura1.Text = "Nombre / Textura";
            // 
            // labelID_Terreno1
            // 
            this.labelID_Terreno1.AutoSize = true;
            this.labelID_Terreno1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID_Terreno1.Location = new System.Drawing.Point(252, 6);
            this.labelID_Terreno1.Name = "labelID_Terreno1";
            this.labelID_Terreno1.Size = new System.Drawing.Size(30, 28);
            this.labelID_Terreno1.TabIndex = 6;
            this.labelID_Terreno1.Text = "ID";
            // 
            // btn_SiguienteTerreno
            // 
            this.btn_SiguienteTerreno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SiguienteTerreno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SiguienteTerreno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SiguienteTerreno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SiguienteTerreno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SiguienteTerreno.Location = new System.Drawing.Point(968, 447);
            this.btn_SiguienteTerreno.Name = "btn_SiguienteTerreno";
            this.btn_SiguienteTerreno.Size = new System.Drawing.Size(115, 42);
            this.btn_SiguienteTerreno.TabIndex = 12;
            this.btn_SiguienteTerreno.Text = "Siguiente";
            this.btn_SiguienteTerreno.UseVisualStyleBackColor = false;
            this.btn_SiguienteTerreno.Click += new System.EventHandler(this.btn_SiguienteTerreno_Click);
            // 
            // Label_ConfiguracionTerreno
            // 
            this.Label_ConfiguracionTerreno.AutoSize = true;
            this.Label_ConfiguracionTerreno.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ConfiguracionTerreno.Location = new System.Drawing.Point(384, 23);
            this.Label_ConfiguracionTerreno.Name = "Label_ConfiguracionTerreno";
            this.Label_ConfiguracionTerreno.Size = new System.Drawing.Size(324, 47);
            this.Label_ConfiguracionTerreno.TabIndex = 11;
            this.Label_ConfiguracionTerreno.Text = "Configuración Terreno";
            // 
            // Form_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 513);
            this.Controls.Add(this.panel_contenedor);
            this.Name = "Form_Configuracion";
            this.Text = "Configuración";
            this.panel_contenedor.ResumeLayout(false);
            this.panel_contenedor.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNombre_Textura1;
        private System.Windows.Forms.Label labelID_Terreno1;
        private System.Windows.Forms.Button btn_SiguienteTerreno;
        private System.Windows.Forms.Label Label_ConfiguracionTerreno;
    }
}