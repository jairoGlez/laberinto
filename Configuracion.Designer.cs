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
            this.btn_SiguienteTerreno = new System.Windows.Forms.Button();
            this.Label_ConfiguracionTerreno = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel_contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_contenedor.Controls.Add(this.btn_SiguienteTerreno);
            this.panel_contenedor.Controls.Add(this.Label_ConfiguracionTerreno);
            this.panel_contenedor.Location = new System.Drawing.Point(12, 12);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(496, 364);
            this.panel_contenedor.TabIndex = 0;
            // 
            // btn_SiguienteTerreno
            // 
            this.btn_SiguienteTerreno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SiguienteTerreno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SiguienteTerreno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SiguienteTerreno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SiguienteTerreno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SiguienteTerreno.Location = new System.Drawing.Point(378, 319);
            this.btn_SiguienteTerreno.Name = "btn_SiguienteTerreno";
            this.btn_SiguienteTerreno.Size = new System.Drawing.Size(115, 42);
            this.btn_SiguienteTerreno.TabIndex = 12;
            this.btn_SiguienteTerreno.Text = "Aceptar";
            this.btn_SiguienteTerreno.UseVisualStyleBackColor = false;
            this.btn_SiguienteTerreno.Click += new System.EventHandler(this.btn_SiguienteTerreno_Click);
            // 
            // Label_ConfiguracionTerreno
            // 
            this.Label_ConfiguracionTerreno.AutoSize = true;
            this.Label_ConfiguracionTerreno.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ConfiguracionTerreno.Location = new System.Drawing.Point(79, 0);
            this.Label_ConfiguracionTerreno.Name = "Label_ConfiguracionTerreno";
            this.Label_ConfiguracionTerreno.Size = new System.Drawing.Size(324, 47);
            this.Label_ConfiguracionTerreno.TabIndex = 11;
            this.Label_ConfiguracionTerreno.Text = "Configuración Terreno";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(12, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(496, 267);
            this.panel3.TabIndex = 13;
            // 
            // Form_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 377);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_contenedor);
            this.Name = "Form_Configuracion";
            this.Text = "Configuración";
            this.panel_contenedor.ResumeLayout(false);
            this.panel_contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_contenedor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_SiguienteTerreno;
        private System.Windows.Forms.Label Label_ConfiguracionTerreno;
    }
}