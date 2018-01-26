namespace DigitalSignature
{
    partial class DigitalSignForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalSignForm));
            this.signButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.dataFilePathTextBox = new System.Windows.Forms.TextBox();
            this.dataFileButton = new System.Windows.Forms.Button();
            this.keyLabel = new System.Windows.Forms.Label();
            this.generateKeysButton = new System.Windows.Forms.Button();
            this.signPathTextBox = new System.Windows.Forms.TextBox();
            this.signaturePathLabel = new System.Windows.Forms.Label();
            this.keyPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openKeyButton = new System.Windows.Forms.Button();
            this.openSignatureButton = new System.Windows.Forms.Button();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signButton
            // 
            this.signButton.Enabled = false;
            this.signButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.signButton.Location = new System.Drawing.Point(148, 115);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(67, 27);
            this.signButton.TabIndex = 8;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.Sign);
            // 
            // verifyButton
            // 
            this.verifyButton.Enabled = false;
            this.verifyButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.verifyButton.Location = new System.Drawing.Point(221, 115);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(77, 27);
            this.verifyButton.TabIndex = 9;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.Verify);
            // 
            // dataFilePathTextBox
            // 
            this.dataFilePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataFilePathTextBox.Location = new System.Drawing.Point(100, 26);
            this.dataFilePathTextBox.Name = "dataFilePathTextBox";
            this.dataFilePathTextBox.Size = new System.Drawing.Size(314, 20);
            this.dataFilePathTextBox.TabIndex = 1;
            this.dataFilePathTextBox.TextChanged += new System.EventHandler(this.CheckButtons);
            // 
            // dataFileButton
            // 
            this.dataFileButton.BackgroundImage = global::DigitalSignature.Properties.Resources.OpenFile_16x;
            this.dataFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dataFileButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.dataFileButton.Location = new System.Drawing.Point(420, 23);
            this.dataFileButton.Name = "dataFileButton";
            this.dataFileButton.Size = new System.Drawing.Size(23, 24);
            this.dataFileButton.TabIndex = 2;
            this.dataFileButton.UseVisualStyleBackColor = true;
            this.dataFileButton.Click += new System.EventHandler(this.OpenDataFile);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyLabel.Location = new System.Drawing.Point(16, 57);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(40, 16);
            this.keyLabel.TabIndex = 21;
            this.keyLabel.Text = "Key:";
            this.keyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // generateKeysButton
            // 
            this.generateKeysButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.generateKeysButton.Location = new System.Drawing.Point(19, 115);
            this.generateKeysButton.Name = "generateKeysButton";
            this.generateKeysButton.Size = new System.Drawing.Size(123, 27);
            this.generateKeysButton.TabIndex = 7;
            this.generateKeysButton.Text = "Generate keys";
            this.generateKeysButton.UseVisualStyleBackColor = true;
            this.generateKeysButton.Click += new System.EventHandler(this.GenerateKeys);
            // 
            // signPathTextBox
            // 
            this.signPathTextBox.Location = new System.Drawing.Point(100, 82);
            this.signPathTextBox.Name = "signPathTextBox";
            this.signPathTextBox.Size = new System.Drawing.Size(314, 20);
            this.signPathTextBox.TabIndex = 5;
            this.signPathTextBox.TextChanged += new System.EventHandler(this.CheckButtons);
            // 
            // signaturePathLabel
            // 
            this.signaturePathLabel.AutoSize = true;
            this.signaturePathLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signaturePathLabel.Location = new System.Drawing.Point(16, 83);
            this.signaturePathLabel.Name = "signaturePathLabel";
            this.signaturePathLabel.Size = new System.Drawing.Size(83, 16);
            this.signaturePathLabel.TabIndex = 19;
            this.signaturePathLabel.Text = "Signature:";
            this.signaturePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // keyPathTextBox
            // 
            this.keyPathTextBox.Location = new System.Drawing.Point(100, 56);
            this.keyPathTextBox.Name = "keyPathTextBox";
            this.keyPathTextBox.Size = new System.Drawing.Size(314, 20);
            this.keyPathTextBox.TabIndex = 3;
            this.keyPathTextBox.TextChanged += new System.EventHandler(this.CheckButtons);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Data file:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openKeyButton
            // 
            this.openKeyButton.BackgroundImage = global::DigitalSignature.Properties.Resources.OpenFile_16x;
            this.openKeyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openKeyButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.openKeyButton.Location = new System.Drawing.Point(420, 53);
            this.openKeyButton.Name = "openKeyButton";
            this.openKeyButton.Size = new System.Drawing.Size(23, 24);
            this.openKeyButton.TabIndex = 4;
            this.openKeyButton.UseVisualStyleBackColor = true;
            this.openKeyButton.Click += new System.EventHandler(this.OpenKeyFile);
            // 
            // openSignatureButton
            // 
            this.openSignatureButton.BackgroundImage = global::DigitalSignature.Properties.Resources.OpenFile_16x;
            this.openSignatureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openSignatureButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold);
            this.openSignatureButton.Location = new System.Drawing.Point(420, 79);
            this.openSignatureButton.Name = "openSignatureButton";
            this.openSignatureButton.Size = new System.Drawing.Size(23, 24);
            this.openSignatureButton.TabIndex = 6;
            this.openSignatureButton.UseVisualStyleBackColor = true;
            this.openSignatureButton.Click += new System.EventHandler(this.OpenSignatureFile);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(311, 116);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(132, 26);
            this.copyrightLabel.TabIndex = 24;
            this.copyrightLabel.Text = "made by SamMetalWorker\n(dragongling@gmail.com)";
            // 
            // DigitalSignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 154);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyPathTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.generateKeysButton);
            this.Controls.Add(this.signPathTextBox);
            this.Controls.Add(this.signaturePathLabel);
            this.Controls.Add(this.openSignatureButton);
            this.Controls.Add(this.openKeyButton);
            this.Controls.Add(this.dataFileButton);
            this.Controls.Add(this.dataFilePathTextBox);
            this.Controls.Add(this.verifyButton);
            this.Controls.Add(this.signButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DigitalSignForm";
            this.Text = "Digital Signature";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.TextBox dataFilePathTextBox;
        private System.Windows.Forms.Button dataFileButton;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Button generateKeysButton;
        private System.Windows.Forms.TextBox signPathTextBox;
        private System.Windows.Forms.Label signaturePathLabel;
        private System.Windows.Forms.TextBox keyPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openKeyButton;
        private System.Windows.Forms.Button openSignatureButton;
        private System.Windows.Forms.Label copyrightLabel;
    }
}

