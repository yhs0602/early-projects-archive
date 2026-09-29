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
    public partial class NewAccountForm : Form
    {
        public NewAccountForm()
        {
            InitializeComponent();
        }

        private void CreateNewBtn_Click(object sender, EventArgs e)
        {
            if (NewID.Text != "")
            {
                if (NewPassword.Text == PasswordConfirm.Text)
                {
                    if ((PasswordHint.Text != ""))
                    {
                        if (Directory.Exists(@"C:\Pomingfu")==false)
                        {
                            DirectoryInfo a = Directory.CreateDirectory(@"C:\Pomingfu");
                        }
                        if (Directory.Exists(@"C:\" + NewID.Text) == false)
                        {
                            DirectoryInfo d = Directory.CreateDirectory(@"C:\Pomingfu" + NewID.Text);
                            FileStream fs = File.Create(@"C:\Pomingfu" + NewID.Text+ @"\pw.txt");
                            StreamWriter s=new StreamWriter(fs);
                            s.Write(NewPassword.Text);
                            s.Close();
                            fs.Close();
                            FileStream  f= File.Create(@"C:\Pomingfu" + NewID.Text + @"\pwfind.txt");
                            StreamWriter sf = new StreamWriter(f);
                            sf.Write(PasswordHint.Text);
                            sf.Close();
                            f.Close();
                            MessageBox.Show("성공적으로 만들어짐");
                        }
                        else
                        {
                            MessageBox.Show("이미 존재하는 아이디입니다.", "이미 존재하는 아이디");
                        }
                    }
                    else
                    {
                        MessageBox.Show("비밀번호 힌트를 입력하세요.");
                    }
                }
                else
                {
                    MessageBox.Show("비밀번호가 서로 다릅니다.","비밀번호 재입력 오류");
                }
            }else{
                MessageBox.Show("아이디를 입력하세요","아이디를 입력하세요");
            }
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
