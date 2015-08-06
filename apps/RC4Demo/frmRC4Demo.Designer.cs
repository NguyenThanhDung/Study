namespace RC4Demo
{
    partial class frmRC4Demo
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCypherText = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.rdbKeyText = new System.Windows.Forms.RadioButton();
            this.rdbKeyHexa = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbPlainHexa = new System.Windows.Forms.RadioButton();
            this.rdbPlainText = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbCypherHexa = new System.Windows.Forms.RadioButton();
            this.rdbCypherText = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(168, 11);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(310, 26);
            this.txtKey.TabIndex = 0;
            this.txtKey.UseSystemPasswordChar = true;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plain Text";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlainText.Location = new System.Drawing.Point(16, 97);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(249, 315);
            this.txtPlainText.TabIndex = 1;
            this.txtPlainText.TextChanged += new System.EventHandler(this.txtPlainText_TextChanged);
            this.txtPlainText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlainText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(443, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cypher Text";
            // 
            // txtCypherText
            // 
            this.txtCypherText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCypherText.Location = new System.Drawing.Point(447, 95);
            this.txtCypherText.Multiline = true;
            this.txtCypherText.Name = "txtCypherText";
            this.txtCypherText.Size = new System.Drawing.Size(249, 317);
            this.txtCypherText.TabIndex = 4;
            this.txtCypherText.TextChanged += new System.EventHandler(this.txtCypherText_TextChanged);
            this.txtCypherText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCypherText_KeyDown);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(283, 159);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(142, 47);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = ">> &Encrypt >>";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(283, 229);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(142, 47);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "<< &Decrypt <<";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // rdbKeyText
            // 
            this.rdbKeyText.AutoSize = true;
            this.rdbKeyText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKeyText.Location = new System.Drawing.Point(15, 1);
            this.rdbKeyText.Name = "rdbKeyText";
            this.rdbKeyText.Size = new System.Drawing.Size(53, 22);
            this.rdbKeyText.TabIndex = 0;
            this.rdbKeyText.TabStop = true;
            this.rdbKeyText.Text = "Text";
            this.rdbKeyText.UseVisualStyleBackColor = true;
            this.rdbKeyText.CheckedChanged += new System.EventHandler(this.rdbKeyText_CheckedChanged);
            // 
            // rdbKeyHexa
            // 
            this.rdbKeyHexa.AutoSize = true;
            this.rdbKeyHexa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKeyHexa.Location = new System.Drawing.Point(78, 1);
            this.rdbKeyHexa.Name = "rdbKeyHexa";
            this.rdbKeyHexa.Size = new System.Drawing.Size(62, 22);
            this.rdbKeyHexa.TabIndex = 1;
            this.rdbKeyHexa.TabStop = true;
            this.rdbKeyHexa.Text = "Hexa";
            this.rdbKeyHexa.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbKeyHexa);
            this.panel1.Controls.Add(this.rdbKeyText);
            this.panel1.Location = new System.Drawing.Point(484, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 26);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbPlainHexa);
            this.panel2.Controls.Add(this.rdbPlainText);
            this.panel2.Location = new System.Drawing.Point(107, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 26);
            this.panel2.TabIndex = 6;
            // 
            // rdbPlainHexa
            // 
            this.rdbPlainHexa.AutoSize = true;
            this.rdbPlainHexa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPlainHexa.Location = new System.Drawing.Point(78, 1);
            this.rdbPlainHexa.Name = "rdbPlainHexa";
            this.rdbPlainHexa.Size = new System.Drawing.Size(62, 22);
            this.rdbPlainHexa.TabIndex = 1;
            this.rdbPlainHexa.TabStop = true;
            this.rdbPlainHexa.Text = "Hexa";
            this.rdbPlainHexa.UseVisualStyleBackColor = true;
            // 
            // rdbPlainText
            // 
            this.rdbPlainText.AutoSize = true;
            this.rdbPlainText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPlainText.Location = new System.Drawing.Point(15, 1);
            this.rdbPlainText.Name = "rdbPlainText";
            this.rdbPlainText.Size = new System.Drawing.Size(53, 22);
            this.rdbPlainText.TabIndex = 0;
            this.rdbPlainText.TabStop = true;
            this.rdbPlainText.Text = "Text";
            this.rdbPlainText.UseVisualStyleBackColor = true;
            this.rdbPlainText.CheckedChanged += new System.EventHandler(this.rdbPlainText_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbCypherHexa);
            this.panel3.Controls.Add(this.rdbCypherText);
            this.panel3.Location = new System.Drawing.Point(553, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 26);
            this.panel3.TabIndex = 7;
            // 
            // rdbCypherHexa
            // 
            this.rdbCypherHexa.AutoSize = true;
            this.rdbCypherHexa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCypherHexa.Location = new System.Drawing.Point(78, 1);
            this.rdbCypherHexa.Name = "rdbCypherHexa";
            this.rdbCypherHexa.Size = new System.Drawing.Size(62, 22);
            this.rdbCypherHexa.TabIndex = 1;
            this.rdbCypherHexa.TabStop = true;
            this.rdbCypherHexa.Text = "Hexa";
            this.rdbCypherHexa.UseVisualStyleBackColor = true;
            // 
            // rdbCypherText
            // 
            this.rdbCypherText.AutoSize = true;
            this.rdbCypherText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCypherText.Location = new System.Drawing.Point(15, 1);
            this.rdbCypherText.Name = "rdbCypherText";
            this.rdbCypherText.Size = new System.Drawing.Size(53, 22);
            this.rdbCypherText.TabIndex = 0;
            this.rdbCypherText.TabStop = true;
            this.rdbCypherText.Text = "Text";
            this.rdbCypherText.UseVisualStyleBackColor = true;
            this.rdbCypherText.CheckedChanged += new System.EventHandler(this.rdbCypherText_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(341, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "© 2009-2015  Nguyen Thanh Dung - dung.nguyenthanh@hotmail.com";
            // 
            // frmRC4Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 456);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtCypherText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.MaximizeBox = false;
            this.Name = "frmRC4Demo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Encryptor";
            this.Load += new System.EventHandler(this.frmRC4Demo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCypherText;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.RadioButton rdbKeyText;
        private System.Windows.Forms.RadioButton rdbKeyHexa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbPlainHexa;
        private System.Windows.Forms.RadioButton rdbPlainText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbCypherHexa;
        private System.Windows.Forms.RadioButton rdbCypherText;
        private System.Windows.Forms.Label label4;
    }
}

