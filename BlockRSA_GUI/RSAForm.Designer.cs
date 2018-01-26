namespace RSA_code
{
    partial class MainForm
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
            this.ciphertextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.plaintextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.ciphertextLabel = new System.Windows.Forms.Label();
            this.opentextLabel = new System.Windows.Forms.Label();
            this.publicKeyTextBox = new System.Windows.Forms.TextBox();
            this.privateKeyTextBox = new System.Windows.Forms.TextBox();
            this.openKeyPairLabel = new System.Windows.Forms.Label();
            this.generateKeysButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.keyBitCountComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyBitCountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ciphertextRichTextBox
            // 
            this.ciphertextRichTextBox.Location = new System.Drawing.Point(269, 40);
            this.ciphertextRichTextBox.Name = "ciphertextRichTextBox";
            this.ciphertextRichTextBox.Size = new System.Drawing.Size(241, 172);
            this.ciphertextRichTextBox.TabIndex = 1;
            this.ciphertextRichTextBox.Text = "";
            this.ciphertextRichTextBox.TextChanged += new System.EventHandler(this.ButtonCheck);
            // 
            // plaintextRichTextBox
            // 
            this.plaintextRichTextBox.Location = new System.Drawing.Point(12, 40);
            this.plaintextRichTextBox.Name = "plaintextRichTextBox";
            this.plaintextRichTextBox.Size = new System.Drawing.Size(242, 172);
            this.plaintextRichTextBox.TabIndex = 0;
            this.plaintextRichTextBox.Text = "";
            this.plaintextRichTextBox.TextChanged += new System.EventHandler(this.ButtonCheck);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ciphertextRichTextBox);
            this.groupBox1.Controls.Add(this.plaintextRichTextBox);
            this.groupBox1.Controls.Add(this.decryptButton);
            this.groupBox1.Controls.Add(this.encryptButton);
            this.groupBox1.Controls.Add(this.ciphertextLabel);
            this.groupBox1.Controls.Add(this.opentextLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 265);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // decryptButton
            // 
            this.decryptButton.Enabled = false;
            this.decryptButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decryptButton.Location = new System.Drawing.Point(269, 221);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(241, 34);
            this.decryptButton.TabIndex = 3;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.Decrypt);
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encryptButton.Location = new System.Drawing.Point(12, 221);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(242, 34);
            this.encryptButton.TabIndex = 2;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.Encrypt);
            // 
            // ciphertextLabel
            // 
            this.ciphertextLabel.AutoSize = true;
            this.ciphertextLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ciphertextLabel.Location = new System.Drawing.Point(347, 19);
            this.ciphertextLabel.Name = "ciphertextLabel";
            this.ciphertextLabel.Size = new System.Drawing.Size(86, 16);
            this.ciphertextLabel.TabIndex = 1;
            this.ciphertextLabel.Text = "Ciphertext";
            // 
            // opentextLabel
            // 
            this.opentextLabel.AutoSize = true;
            this.opentextLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opentextLabel.Location = new System.Drawing.Point(86, 19);
            this.opentextLabel.Name = "opentextLabel";
            this.opentextLabel.Size = new System.Drawing.Size(74, 16);
            this.opentextLabel.TabIndex = 0;
            this.opentextLabel.Text = "Plaintext";
            // 
            // publicKeyTextBox
            // 
            this.publicKeyTextBox.Location = new System.Drawing.Point(121, 38);
            this.publicKeyTextBox.Name = "publicKeyTextBox";
            this.publicKeyTextBox.Size = new System.Drawing.Size(268, 20);
            this.publicKeyTextBox.TabIndex = 6;
            this.publicKeyTextBox.TextChanged += new System.EventHandler(this.ButtonCheck);
            // 
            // privateKeyTextBox
            // 
            this.privateKeyTextBox.Location = new System.Drawing.Point(121, 12);
            this.privateKeyTextBox.Name = "privateKeyTextBox";
            this.privateKeyTextBox.PasswordChar = '●';
            this.privateKeyTextBox.Size = new System.Drawing.Size(268, 20);
            this.privateKeyTextBox.TabIndex = 7;
            this.privateKeyTextBox.TextChanged += new System.EventHandler(this.ButtonCheck);
            // 
            // openKeyPairLabel
            // 
            this.openKeyPairLabel.AutoSize = true;
            this.openKeyPairLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openKeyPairLabel.Location = new System.Drawing.Point(21, 38);
            this.openKeyPairLabel.Name = "openKeyPairLabel";
            this.openKeyPairLabel.Size = new System.Drawing.Size(88, 16);
            this.openKeyPairLabel.TabIndex = 8;
            this.openKeyPairLabel.Text = "Public key:";
            this.openKeyPairLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // generateKeysButton
            // 
            this.generateKeysButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.generateKeysButton.Location = new System.Drawing.Point(395, 65);
            this.generateKeysButton.Name = "generateKeysButton";
            this.generateKeysButton.Size = new System.Drawing.Size(124, 29);
            this.generateKeysButton.TabIndex = 10;
            this.generateKeysButton.Text = "Generate keys";
            this.generateKeysButton.UseVisualStyleBackColor = true;
            this.generateKeysButton.Click += new System.EventHandler(this.GenerateKeys);
            // 
            // showButton
            // 
            this.showButton.Enabled = false;
            this.showButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showButton.Location = new System.Drawing.Point(395, 11);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(59, 21);
            this.showButton.TabIndex = 12;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.ShowButtonClick);
            // 
            // copyButton
            // 
            this.copyButton.Enabled = false;
            this.copyButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyButton.Location = new System.Drawing.Point(460, 11);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(59, 21);
            this.copyButton.TabIndex = 13;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // keyBitCountComboBox
            // 
            this.keyBitCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyBitCountComboBox.FormattingEnabled = true;
            this.keyBitCountComboBox.Location = new System.Drawing.Point(442, 38);
            this.keyBitCountComboBox.Name = "keyBitCountComboBox";
            this.keyBitCountComboBox.Size = new System.Drawing.Size(49, 21);
            this.keyBitCountComboBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Private key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(497, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "bit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // keyBitCountLabel
            // 
            this.keyBitCountLabel.AutoSize = true;
            this.keyBitCountLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyBitCountLabel.Location = new System.Drawing.Point(395, 39);
            this.keyBitCountLabel.Name = "keyBitCountLabel";
            this.keyBitCountLabel.Size = new System.Drawing.Size(41, 16);
            this.keyBitCountLabel.TabIndex = 11;
            this.keyBitCountLabel.Text = "Size:";
            this.keyBitCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 403);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyBitCountComboBox);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.keyBitCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateKeysButton);
            this.Controls.Add(this.privateKeyTextBox);
            this.Controls.Add(this.publicKeyTextBox);
            this.Controls.Add(this.openKeyPairLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "RSA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ciphertextRichTextBox;
        private System.Windows.Forms.RichTextBox plaintextRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Label ciphertextLabel;
        private System.Windows.Forms.Label opentextLabel;
        private System.Windows.Forms.TextBox publicKeyTextBox;
        private System.Windows.Forms.TextBox privateKeyTextBox;
        private System.Windows.Forms.Label openKeyPairLabel;
        private System.Windows.Forms.Button generateKeysButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.ComboBox keyBitCountComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label keyBitCountLabel;
    }
}

