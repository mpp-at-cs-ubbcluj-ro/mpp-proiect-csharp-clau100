using System.ComponentModel;

namespace MPP_CSharp
{
    partial class UserView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.concursuriGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // concursuriGrid
            // 
            this.concursuriGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.concursuriGrid.Location = new System.Drawing.Point(12, 12);
            this.concursuriGrid.Name = "concursuriGrid";
            this.concursuriGrid.Size = new System.Drawing.Size(386, 426);
            this.concursuriGrid.TabIndex = 0;
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.concursuriGrid);
            this.Name = "UserView";
            this.Text = "UserView";
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView concursuriGrid;

        #endregion
    }
}