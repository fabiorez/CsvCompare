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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.txtSe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSefaz = new System.Windows.Forms.TextBox();
            this.lblInexistentes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDivergentes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(25, 139);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(711, 266);
            this.dgvFiles.TabIndex = 0;
            // 
            // btnFile1
            // 
            this.btnFile1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFile1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile1.ForeColor = System.Drawing.Color.Black;
            this.btnFile1.Location = new System.Drawing.Point(613, 67);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(123, 27);
            this.btnFile1.TabIndex = 1;
            this.btnFile1.Text = "XLS SEFAZ";
            this.btnFile1.UseVisualStyleBackColor = false;
            this.btnFile1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFile2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile2.ForeColor = System.Drawing.Color.Black;
            this.btnFile2.Location = new System.Drawing.Point(613, 103);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(123, 27);
            this.btnFile2.TabIndex = 2;
            this.btnFile2.Text = "CSV SE";
            this.btnFile2.UseVisualStyleBackColor = false;
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
            // txtSe
            // 
            this.txtSe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSe.Location = new System.Drawing.Point(25, 103);
            this.txtSe.Name = "txtSe";
            this.txtSe.Size = new System.Drawing.Size(582, 27);
            this.txtSe.TabIndex = 4;
            this.txtSe.TextChanged += new System.EventHandler(this.txtSe_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "COMPARAR - NFE";
            // 
            // btnCompare
            // 
            this.btnCompare.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCompare.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.ForeColor = System.Drawing.Color.White;
            this.btnCompare.Location = new System.Drawing.Point(613, 412);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(123, 30);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "COMPARAR";
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(37, 36);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 7;
            this.pictureBoxLogo.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(470, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "CSV SE";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(341, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "CSV SE";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // txtSefaz
            // 
            this.txtSefaz.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSefaz.Location = new System.Drawing.Point(25, 67);
            this.txtSefaz.Name = "txtSefaz";
            this.txtSefaz.Size = new System.Drawing.Size(582, 27);
            this.txtSefaz.TabIndex = 10;
            // 
            // lblInexistentes
            // 
            this.lblInexistentes.AutoSize = true;
            this.lblInexistentes.BackColor = System.Drawing.Color.Transparent;
            this.lblInexistentes.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInexistentes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblInexistentes.Location = new System.Drawing.Point(22, 411);
            this.lblInexistentes.Name = "lblInexistentes";
            this.lblInexistentes.Size = new System.Drawing.Size(29, 33);
            this.lblInexistentes.TabIndex = 11;
            this.lblInexistentes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "notas inexistentes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDivergentes
            // 
            this.lblDivergentes.AutoSize = true;
            this.lblDivergentes.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivergentes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDivergentes.Location = new System.Drawing.Point(196, 412);
            this.lblDivergentes.Name = "lblDivergentes";
            this.lblDivergentes.Size = new System.Drawing.Size(29, 33);
            this.lblDivergentes.TabIndex = 13;
            this.lblDivergentes.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "valores divergentes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(758, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDivergentes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInexistentes);
            this.Controls.Add(this.txtSefaz);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSe);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.dgvFiles);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "TECHVIRTUS";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox txtSe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSefaz;
        private System.Windows.Forms.Label lblInexistentes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDivergentes;
        private System.Windows.Forms.Label label3;
    }
}

