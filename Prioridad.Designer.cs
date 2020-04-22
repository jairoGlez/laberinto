namespace laberinto
{
    partial class Form_Prioridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Prioridad));
            this.Label_ConfiguracionTerreno = new System.Windows.Forms.Label();
            this.listBoxPrioridad = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnGuardarPrioridad = new System.Windows.Forms.Button();
            this.listBox_prueba = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Label_ConfiguracionTerreno
            // 
            this.Label_ConfiguracionTerreno.AutoSize = true;
            this.Label_ConfiguracionTerreno.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ConfiguracionTerreno.Location = new System.Drawing.Point(12, 9);
            this.Label_ConfiguracionTerreno.Name = "Label_ConfiguracionTerreno";
            this.Label_ConfiguracionTerreno.Size = new System.Drawing.Size(246, 33);
            this.Label_ConfiguracionTerreno.TabIndex = 12;
            this.Label_ConfiguracionTerreno.Text = "Configuración Prioridad";
            // 
            // listBoxPrioridad
            // 
            this.listBoxPrioridad.FormattingEnabled = true;
            this.listBoxPrioridad.Items.AddRange(new object[] {
            "1.Arriba",
            "2.Abajo",
            "3.Izquierda",
            "4.Derecha"});
            this.listBoxPrioridad.Location = new System.Drawing.Point(31, 60);
            this.listBoxPrioridad.Name = "listBoxPrioridad";
            this.listBoxPrioridad.Size = new System.Drawing.Size(120, 95);
            this.listBoxPrioridad.TabIndex = 13;
            // 
            // btnUp
            // 
            this.btnUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(166, 60);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 43);
            this.btnUp.TabIndex = 14;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(166, 109);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(37, 43);
            this.btnDown.TabIndex = 15;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnGuardarPrioridad
            // 
            this.btnGuardarPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarPrioridad.Location = new System.Drawing.Point(104, 177);
            this.btnGuardarPrioridad.Name = "btnGuardarPrioridad";
            this.btnGuardarPrioridad.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPrioridad.TabIndex = 16;
            this.btnGuardarPrioridad.Text = "Guardar";
            this.btnGuardarPrioridad.UseVisualStyleBackColor = true;
            this.btnGuardarPrioridad.Click += new System.EventHandler(this.btnGuardarPrioridad_Click);
            // 
            // listBox_prueba
            // 
            this.listBox_prueba.FormattingEnabled = true;
            this.listBox_prueba.Location = new System.Drawing.Point(235, 90);
            this.listBox_prueba.Name = "listBox_prueba";
            this.listBox_prueba.Size = new System.Drawing.Size(120, 95);
            this.listBox_prueba.TabIndex = 17;
            // 
            // Form_Prioridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 284);
            this.Controls.Add(this.listBox_prueba);
            this.Controls.Add(this.btnGuardarPrioridad);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.listBoxPrioridad);
            this.Controls.Add(this.Label_ConfiguracionTerreno);
            this.Name = "Form_Prioridad";
            this.Text = "Prioridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_ConfiguracionTerreno;
        private System.Windows.Forms.ListBox listBoxPrioridad;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnGuardarPrioridad;
        private System.Windows.Forms.ListBox listBox_prueba;
    }
}