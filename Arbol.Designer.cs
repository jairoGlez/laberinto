namespace laberinto
{
    partial class Arbol
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
            this.label2 = new System.Windows.Forms.Label();
            this.treeArbolGen = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Árbol";
            // 
            // treeArbolGen
            // 
            this.treeArbolGen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeArbolGen.Location = new System.Drawing.Point(12, 49);
            this.treeArbolGen.MaximumSize = new System.Drawing.Size(1900, 1050);
            this.treeArbolGen.MinimumSize = new System.Drawing.Size(233, 156);
            this.treeArbolGen.Name = "treeArbolGen";
            this.treeArbolGen.ShowPlusMinus = false;
            this.treeArbolGen.ShowRootLines = false;
            this.treeArbolGen.Size = new System.Drawing.Size(233, 156);
            this.treeArbolGen.TabIndex = 15;
            // 
            // Arbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 216);
            this.Controls.Add(this.treeArbolGen);
            this.Controls.Add(this.label2);
            this.Name = "Arbol";
            this.Text = "Arbol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeArbolGen;
    }
}