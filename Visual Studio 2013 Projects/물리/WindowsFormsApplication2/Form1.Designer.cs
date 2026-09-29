namespace WindowsFormsApplication2
{
    partial class PictureBoxBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureBoxBack));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.locationx = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.LocationY = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.GroupAbout = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FFf = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ControlSphere = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            this.GroupAbout.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlSphere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 182);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(262, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // locationx
            // 
            this.locationx.Location = new System.Drawing.Point(6, 20);
            this.locationx.Name = "locationx";
            this.locationx.Size = new System.Drawing.Size(262, 45);
            this.locationx.TabIndex = 1;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(6, 139);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(262, 45);
            this.trackBar3.TabIndex = 2;
            // 
            // LocationY
            // 
            this.LocationY.Location = new System.Drawing.Point(6, 63);
            this.LocationY.Name = "LocationY";
            this.LocationY.Size = new System.Drawing.Size(262, 45);
            this.LocationY.TabIndex = 3;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(6, 270);
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(262, 45);
            this.trackBar5.TabIndex = 4;
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(6, 106);
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(262, 45);
            this.trackBar6.TabIndex = 5;
            // 
            // trackBar7
            // 
            this.trackBar7.Location = new System.Drawing.Point(6, 305);
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(262, 45);
            this.trackBar7.TabIndex = 6;
            // 
            // trackBar8
            // 
            this.trackBar8.Location = new System.Drawing.Point(6, 228);
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(262, 45);
            this.trackBar8.TabIndex = 7;
            // 
            // GroupAbout
            // 
            this.GroupAbout.Controls.Add(this.locationx);
            this.GroupAbout.Controls.Add(this.trackBar7);
            this.GroupAbout.Controls.Add(this.trackBar8);
            this.GroupAbout.Controls.Add(this.trackBar5);
            this.GroupAbout.Controls.Add(this.LocationY);
            this.GroupAbout.Controls.Add(this.trackBar3);
            this.GroupAbout.Controls.Add(this.trackBar6);
            this.GroupAbout.Controls.Add(this.trackBar1);
            this.GroupAbout.Location = new System.Drawing.Point(818, 178);
            this.GroupAbout.Name = "GroupAbout";
            this.GroupAbout.Size = new System.Drawing.Size(288, 407);
            this.GroupAbout.TabIndex = 8;
            this.GroupAbout.TabStop = false;
            this.GroupAbout.Text = "About";
            this.GroupAbout.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FFf);
            this.groupBox2.Location = new System.Drawing.Point(819, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 142);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // FFf
            // 
            this.FFf.AutoSize = true;
            this.FFf.Location = new System.Drawing.Point(31, 27);
            this.FFf.Name = "FFf";
            this.FFf.Size = new System.Drawing.Size(45, 16);
            this.FFf.TabIndex = 0;
            this.FFf.Text = "ggg";
            this.FFf.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ControlSphere);
            this.groupBox3.Location = new System.Drawing.Point(15, 367);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(790, 217);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Controls";
            // 
            // ControlSphere
            // 
            this.ControlSphere.Image = global::WindowsFormsApplication2.Resource1.Circle;
            this.ControlSphere.Location = new System.Drawing.Point(22, 20);
            this.ControlSphere.Name = "ControlSphere";
            this.ControlSphere.Size = new System.Drawing.Size(74, 60);
            this.ControlSphere.TabIndex = 0;
            this.ControlSphere.TabStop = false;
            this.ControlSphere.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 355);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // PictureBoxBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 616);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupAbout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PictureBoxBack";
            this.Text = "GeekPhysics";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            this.GroupAbout.ResumeLayout(false);
            this.GroupAbout.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ControlSphere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar locationx;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar LocationY;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.GroupBox GroupAbout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox FFf;
        private System.Windows.Forms.PictureBox ControlSphere;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

