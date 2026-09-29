using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag= 0;
            if (IDText.Text != "")
            {
                if (Directory.Exists(@"C:\Pomingfu" + IDText.Text))
                {
                    if (File.Exists(@"C:\Pomingfu" + IDText.Text + @"\pw.txt"))
                    {
                        using (StreamReader t = new StreamReader(@"C:\Pomingfu" + IDText.Text + @"\pw.txt"))
                        {
                            char[] pw = new char[PWText.Text.Length];
                            t.Read(pw, 0, PWText.Text.Length);
                            if (PWText.Text.Equals(pw.ToString()))
                            {
                                flag = 1;
                            }
                            else
                            {
                                MessageBox.Show("패스워드가 틀렸습니다.","로그인 오류");
                            }
                        }
                    } else
                    {
                        MessageBox.Show("패스워드가 손실되어 존재하지 않습니다.");
                    }

                }
                else
                {
                    MessageBox.Show("당신의 아이디는 존재하지 않습니다.", "로그인 오류");
                    return;
                }
            }
            else
            {
                MessageBox.Show("입력하세요!","로그인 오류");
               return;
            }
            if (flag != 1) { MessageBox.Show("로그인 오류","로그인 오류"); } 
            MessageBox.Show("로그인 중..", "로그인", MessageBoxButtons.OK);
            LogInLabel.Visible = false;
            LogInButton.Visible = false;
            PWText.Visible = false;
            IDText.Visible = false;
            this.BackgroundImage = Properties.Resources.ggg;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private Game game;

        private void button1_Click_1(object sender, EventArgs e)
        {
            NewAccountForm naf = new NewAccountForm();
        }

    }
}
