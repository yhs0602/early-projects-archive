namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.LogInButton = new System.Windows.Forms.Button();
            this.IDText = new System.Windows.Forms.TextBox();
            this.PWText = new System.Windows.Forms.TextBox();
            this.LogInLabel = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(194, 103);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(75, 47);
            this.LogInButton.TabIndex = 0;
            this.LogInButton.Text = "로그인";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // IDText
            // 
            this.IDText.Location = new System.Drawing.Point(93, 103);
            this.IDText.Name = "IDText";
            this.IDText.Size = new System.Drawing.Size(95, 21);
            this.IDText.TabIndex = 1;
            this.IDText.Text = "ID";
            // 
            // PWText
            // 
            this.PWText.Location = new System.Drawing.Point(93, 130);
            this.PWText.Name = "PWText";
            this.PWText.PasswordChar = '*';
            this.PWText.Size = new System.Drawing.Size(95, 21);
            this.PWText.TabIndex = 2;
            this.PWText.Text = "password";
            // 
            // LogInLabel
            // 
            this.LogInLabel.AutoSize = true;
            this.LogInLabel.Font = new System.Drawing.Font("굴림", 12F);
            this.LogInLabel.Location = new System.Drawing.Point(70, 70);
            this.LogInLabel.Name = "LogInLabel";
            this.LogInLabel.Size = new System.Drawing.Size(263, 16);
            this.LogInLabel.TabIndex = 3;
            this.LogInLabel.Text = "아이디와 비밀번호를 입력하십시오.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "새 계정 만들기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 962);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LogInLabel);
            this.Controls.Add(this.PWText);
            this.Controls.Add(this.IDText);
            this.Controls.Add(this.LogInButton);
            this.Name = "MainForm";
            this.Text = "포밍뿌";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.TextBox IDText;
        private System.Windows.Forms.TextBox PWText;
        private System.Windows.Forms.Label LogInLabel;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button button1;

    }
}

