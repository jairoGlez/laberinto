namespace laberinto
{
    partial class Form_Inicio
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
            this.btn_SeleccionarArchivo = new System.Windows.Forms.Button();
            this.Label_VamosaJugar = new System.Windows.Forms.Label();
            this.label_HazSeleccionado = new System.Windows.Forms.Label();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.label_NombreArchivo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_SeleccionarArchivo
            // 
            this.btn_SeleccionarArchivo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_SeleccionarArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_SeleccionarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SeleccionarArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SeleccionarArchivo.Location = new System.Drawing.Point(288, 157);
            this.btn_SeleccionarArchivo.Name = "btn_SeleccionarArchivo";
            this.btn_SeleccionarArchivo.Size = new System.Drawing.Size(200, 42);
            this.btn_SeleccionarArchivo.TabIndex = 0;
            this.btn_SeleccionarArchivo.Text = "Seleccionar Archivo";
            this.btn_SeleccionarArchivo.UseVisualStyleBackColor = false;
            this.btn_SeleccionarArchivo.Click += new System.EventHandler(this.btn_SeleccionarArchivo_Click);
            // 
            // Label_VamosaJugar
            // 
            this.Label_VamosaJugar.AutoSize = true;
            this.Label_VamosaJugar.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_VamosaJugar.Location = new System.Drawing.Point(242, 19);
            this.Label_VamosaJugar.Name = "Label_VamosaJugar";
            this.Label_VamosaJugar.Size = new System.Drawing.Size(312, 62);
            this.Label_VamosaJugar.TabIndex = 1;
            this.Label_VamosaJugar.Text = "Vamos a Jugar!!";
            // 
            // label_HazSeleccionado
            // 
            this.label_HazSeleccionado.AutoSize = true;
            this.label_HazSeleccionado.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HazSeleccionado.Location = new System.Drawing.Point(64, 338);
            this.label_HazSeleccionado.Name = "label_HazSeleccionado";
            this.label_HazSeleccionado.Size = new System.Drawing.Size(210, 36);
            this.label_HazSeleccionado.TabIndex = 2;
            this.label_HazSeleccionado.Text = "Haz Seleccionado: ";
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Cargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Cargar.Enabled = false;
            this.btn_Cargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cargar.Location = new System.Drawing.Point(571, 332);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(95, 42);
            this.btn_Cargar.TabIndex = 3;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = false;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // label_NombreArchivo
            // 
            this.label_NombreArchivo.AutoSize = true;
            this.label_NombreArchivo.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NombreArchivo.Location = new System.Drawing.Point(280, 344);
            this.label_NombreArchivo.Name = "label_NombreArchivo";
            this.label_NombreArchivo.Size = new System.Drawing.Size(180, 28);
            this.label_NombreArchivo.TabIndex = 4;
            this.label_NombreArchivo.Text = "Nombre Archivo ........";
            // 
            // Form_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_NombreArchivo);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.label_HazSeleccionado);
            this.Controls.Add(this.Label_VamosaJugar);
            this.Controls.Add(this.btn_SeleccionarArchivo);
            this.Name = "Form_Inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SeleccionarArchivo;
        private System.Windows.Forms.Label Label_VamosaJugar;
        private System.Windows.Forms.Label label_HazSeleccionado;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.Label label_NombreArchivo;
    }
}

