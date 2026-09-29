namespace WindowsFormsApplication1
{
    partial class NewAccountForm
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
            this.NewID = new System.Windows.Forms.TextBox();
            this.PasswordHint = new System.Windows.Forms.TextBox();
            this.PasswordConfirm = new System.Windows.Forms.TextBox();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CreateNewBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewID
            // 
            this.NewID.Location = new System.Drawing.Point(46, 127);
            this.NewID.Name = "NewID";
            this.NewID.Size = new System.Drawing.Size(163, 21);
            this.NewID.TabIndex = 0;
            // 
            // PasswordHint
            // 
            this.PasswordHint.Location = new System.Drawing.Point(46, 246);
            this.PasswordHint.Name = "PasswordHint";
            this.PasswordHint.Size = new System.Drawing.Size(163, 21);
            this.PasswordHint.TabIndex = 1;
            // 
            // PasswordConfirm
            // 
            this.PasswordConfirm.Location = new System.Drawing.Point(46, 203);
            this.PasswordConfirm.Name = "PasswordConfirm";
            this.PasswordConfirm.Size = new System.Drawing.Size(163, 21);
            this.PasswordConfirm.TabIndex = 2;
            // 
            // NewPassword
            // 
            this.NewPassword.Location = new System.Drawing.Point(46, 164);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Size = new System.Drawing.Size(163, 21);
            this.NewPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "아이디:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "새 계정을 만듭니다.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "비밀번호 힌트:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "비밀번호 확인:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "비밀번호:";
            // 
            // CreateNewBtn
            // 
            this.CreateNewBtn.Location = new System.Drawing.Point(191, 298);
            this.CreateNewBtn.Name = "CreateNewBtn";
            this.CreateNewBtn.Size = new System.Drawing.Size(126, 47);
            this.CreateNewBtn.TabIndex = 9;
            this.CreateNewBtn.Text = "새 계정 만들기...";
            this.CreateNewBtn.UseVisualStyleBackColor = true;
            this.CreateNewBtn.Click += new System.EventHandler(this.CreateNewBtn_Click);
            // 
            // NewAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 392);
            this.Controls.Add(this.CreateNewBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.PasswordConfirm);
            this.Controls.Add(this.PasswordHint);
            this.Controls.Add(this.NewID);
            this.Name = "NewAccountForm";
            this.Text = "새 계정 만들기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewID;
        private System.Windows.Forms.TextBox PasswordHint;
        private System.Windows.Forms.TextBox PasswordConfirm;
        private System.Windows.Forms.TextBox NewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CreateNewBtn;
    }
}