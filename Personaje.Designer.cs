namespace laberinto
{
    partial class Formulario_Personaje
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
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // comboBox7
            // 
            this.comboBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.ItemHeight = 20;
            this.comboBox7.Location = new System.Drawing.Point(111, 38);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(239, 28);
            this.comboBox7.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 28);
            this.label3.TabIndex = 97;
            this.label3.Text = "Avatar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(349, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 26);
            this.label8.TabIndex = 94;
            this.label8.Text = "Personaje";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 287);
            this.panel1.TabIndex = 136;
            // 
            // Formulario_Personaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Formulario_Personaje";
            this.Text = "Personaje1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
    }
}