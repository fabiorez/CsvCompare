namespace CsvCompare
{
    partial class Form1
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
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(25, 179);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(543, 266);
            this.dgvFiles.TabIndex = 0;
            // 
            // btnFile1
            // 
            this.btnFile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile1.Location = new System.Drawing.Point(445, 82);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(114, 30);
            this.btnFile1.TabIndex = 1;
            this.btnFile1.Text = "Arquivo 1";
            this.btnFile1.UseVisualStyleBackColor = true;
            this.btnFile1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.Location = new System.Drawing.Point(445, 128);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(114, 30);
            this.btnFile2.TabIndex = 2;
            this.btnFile2.Text = "Arquivo 2";
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.BtnFile2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // txtFile1
            // 
            this.txtFile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile1.Location = new System.Drawing.Point(25, 82);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(403, 30);
            this.txtFile1.TabIndex = 3;
            // 
            // txtFile2
            // 
            this.txtFile2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile2.Location = new System.Drawing.Point(25, 128);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(403, 30);
            this.txtFile2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Techvirtus - ComparNFE";
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Location = new System.Drawing.Point(445, 451);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(114, 30);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 488);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.txtFile1);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.dgvFiles);
            this.Name = "Form1";
            this.Text = "Techvirtus";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompare;
    }
}

