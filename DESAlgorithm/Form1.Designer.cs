namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlainText = new System.Windows.Forms.Label();
            this.lblKeyCode = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.txtKeyCode = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblCiperText = new System.Windows.Forms.Label();
            this.txtCiperText = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtDecPlain = new System.Windows.Forms.TextBox();
            this.lblDecrypt = new System.Windows.Forms.Label();
            this.txtDecryptResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPlainText
            // 
            this.lblPlainText.AutoSize = true;
            this.lblPlainText.Location = new System.Drawing.Point(12, 27);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(87, 12);
            this.lblPlainText.TabIndex = 3;
            this.lblPlainText.Text = "Input plain text";
            // 
            // lblKeyCode
            // 
            this.lblKeyCode.AutoSize = true;
            this.lblKeyCode.Location = new System.Drawing.Point(12, 56);
            this.lblKeyCode.Name = "lblKeyCode";
            this.lblKeyCode.Size = new System.Drawing.Size(56, 12);
            this.lblKeyCode.TabIndex = 4;
            this.lblKeyCode.Text = "Input key";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 132);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(40, 12);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Result";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(117, 18);
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(270, 21);
            this.txtPlainText.TabIndex = 7;
            // 
            // txtKeyCode
            // 
            this.txtKeyCode.Location = new System.Drawing.Point(117, 47);
            this.txtKeyCode.MaxLength = 7;
            this.txtKeyCode.Multiline = true;
            this.txtKeyCode.Name = "txtKeyCode";
            this.txtKeyCode.Size = new System.Drawing.Size(270, 21);
            this.txtKeyCode.TabIndex = 8;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(117, 119);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtResult.Size = new System.Drawing.Size(361, 117);
            this.txtResult.TabIndex = 9;
            // 
            // lblCiperText
            // 
            this.lblCiperText.AutoSize = true;
            this.lblCiperText.Location = new System.Drawing.Point(12, 256);
            this.lblCiperText.Name = "lblCiperText";
            this.lblCiperText.Size = new System.Drawing.Size(59, 12);
            this.lblCiperText.TabIndex = 10;
            this.lblCiperText.Text = "Ciper text";
            // 
            // txtCiperText
            // 
            this.txtCiperText.Location = new System.Drawing.Point(117, 247);
            this.txtCiperText.Name = "txtCiperText";
            this.txtCiperText.Size = new System.Drawing.Size(270, 21);
            this.txtCiperText.TabIndex = 11;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(197, 76);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(96, 28);
            this.btnEncrypt.TabIndex = 12;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(647, 76);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(96, 28);
            this.btnDecrypt.TabIndex = 13;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtDecPlain
            // 
            this.txtDecPlain.Location = new System.Drawing.Point(562, 47);
            this.txtDecPlain.Name = "txtDecPlain";
            this.txtDecPlain.Size = new System.Drawing.Size(270, 21);
            this.txtDecPlain.TabIndex = 15;
            // 
            // lblDecrypt
            // 
            this.lblDecrypt.AutoSize = true;
            this.lblDecrypt.Location = new System.Drawing.Point(477, 56);
            this.lblDecrypt.Name = "lblDecrypt";
            this.lblDecrypt.Size = new System.Drawing.Size(48, 12);
            this.lblDecrypt.TabIndex = 14;
            this.lblDecrypt.Text = "Decrypt";
            // 
            // txtDecryptResult
            // 
            this.txtDecryptResult.Location = new System.Drawing.Point(562, 119);
            this.txtDecryptResult.Multiline = true;
            this.txtDecryptResult.Name = "txtDecryptResult";
            this.txtDecryptResult.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDecryptResult.Size = new System.Drawing.Size(396, 117);
            this.txtDecryptResult.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 451);
            this.Controls.Add(this.txtDecryptResult);
            this.Controls.Add(this.txtDecPlain);
            this.Controls.Add(this.lblDecrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtCiperText);
            this.Controls.Add(this.lblCiperText);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtKeyCode);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblKeyCode);
            this.Controls.Add(this.lblPlainText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlainText;
        private System.Windows.Forms.Label lblKeyCode;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.TextBox txtKeyCode;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblCiperText;
        private System.Windows.Forms.TextBox txtCiperText;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtDecPlain;
        private System.Windows.Forms.Label lblDecrypt;
        private System.Windows.Forms.TextBox txtDecryptResult;
    }
}

