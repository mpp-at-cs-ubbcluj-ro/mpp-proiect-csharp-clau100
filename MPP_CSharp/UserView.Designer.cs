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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.participantGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.participantGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // concursuriGrid
            // 
            this.concursuriGrid.AllowUserToAddRows = false;
            this.concursuriGrid.AllowUserToDeleteRows = false;
            this.concursuriGrid.AllowUserToOrderColumns = true;
            this.concursuriGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.concursuriGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.concursuriGrid.Location = new System.Drawing.Point(4, 19);
            this.concursuriGrid.Margin = new System.Windows.Forms.Padding(4);
            this.concursuriGrid.MultiSelect = false;
            this.concursuriGrid.Name = "concursuriGrid";
            this.concursuriGrid.ReadOnly = true;
            this.concursuriGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.concursuriGrid.Size = new System.Drawing.Size(379, 535);
            this.concursuriGrid.TabIndex = 0;
            this.concursuriGrid.SelectionChanged += new System.EventHandler(this.concursuriGrid_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.concursuriGrid);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(387, 558);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.participantGrid);
            this.groupBox2.Location = new System.Drawing.Point(411, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(387, 558);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // participantGrid
            // 
            this.participantGrid.AllowUserToAddRows = false;
            this.participantGrid.AllowUserToDeleteRows = false;
            this.participantGrid.AllowUserToOrderColumns = true;
            this.participantGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.participantGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.participantGrid.Location = new System.Drawing.Point(4, 19);
            this.participantGrid.Margin = new System.Windows.Forms.Padding(4);
            this.participantGrid.MultiSelect = false;
            this.participantGrid.Name = "participantGrid";
            this.participantGrid.ReadOnly = true;
            this.participantGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.participantGrid.Size = new System.Drawing.Size(379, 535);
            this.participantGrid.TabIndex = 0;
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1349, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserView";
            this.Text = "UserView";
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.participantGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView participantGrid;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.DataGridView concursuriGrid;

        #endregion
    }
}