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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.concursuriGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.participantGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.totiParticipanti = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textNume = new System.Windows.Forms.TextBox();
            this.textboxVarsta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.register = new System.Windows.Forms.Button();
            this.enroll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.participantGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totiParticipanti)).BeginInit();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.participantGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.participantGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.participantGrid.Size = new System.Drawing.Size(379, 535);
            this.participantGrid.TabIndex = 0;
            this.participantGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.participantGrid_RowPostPaint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.totiParticipanti);
            this.groupBox3.Location = new System.Drawing.Point(805, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 558);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // totiParticipanti
            // 
            this.totiParticipanti.AllowUserToAddRows = false;
            this.totiParticipanti.AllowUserToDeleteRows = false;
            this.totiParticipanti.AllowUserToOrderColumns = true;
            this.totiParticipanti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totiParticipanti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totiParticipanti.Location = new System.Drawing.Point(3, 18);
            this.totiParticipanti.Name = "totiParticipanti";
            this.totiParticipanti.RowTemplate.Height = 24;
            this.totiParticipanti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.totiParticipanti.Size = new System.Drawing.Size(382, 537);
            this.totiParticipanti.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inregistreaza Participant";
            // 
            // textNume
            // 
            this.textNume.Location = new System.Drawing.Point(20, 680);
            this.textNume.Name = "textNume";
            this.textNume.Size = new System.Drawing.Size(158, 22);
            this.textNume.TabIndex = 5;
            // 
            // textboxVarsta
            // 
            this.textboxVarsta.Location = new System.Drawing.Point(20, 747);
            this.textboxVarsta.Name = "textboxVarsta";
            this.textboxVarsta.Size = new System.Drawing.Size(158, 22);
            this.textboxVarsta.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 654);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nume";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 721);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Varsta";
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(197, 718);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(101, 23);
            this.register.TabIndex = 9;
            this.register.Text = "Inregistreaza";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // enroll
            // 
            this.enroll.Location = new System.Drawing.Point(542, 654);
            this.enroll.Name = "enroll";
            this.enroll.Size = new System.Drawing.Size(137, 23);
            this.enroll.TabIndex = 10;
            this.enroll.Text = "inscrie la concurs";
            this.enroll.UseVisualStyleBackColor = true;
            this.enroll.Click += new System.EventHandler(this.enroll_Click);
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1205, 798);
            this.Controls.Add(this.enroll);
            this.Controls.Add(this.register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxVarsta);
            this.Controls.Add(this.textNume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserView";
            this.Text = "Manager";
            ((System.ComponentModel.ISupportInitialize)(this.concursuriGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.participantGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.totiParticipanti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button enroll;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button register;

        private System.Windows.Forms.TextBox textNume;
        private System.Windows.Forms.TextBox textboxVarsta;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.DataGridView totiParticipanti;

        private System.Windows.Forms.DataGridView participantGrid;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.DataGridView concursuriGrid;

        #endregion
    }
}