using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class PictureBoxBack : Form
    {
        public PictureBoxBack()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)  // Sphere Control 클릭시
        {
            PictureBox tmp= new PictureBox();
            tmp.BackgroundImage=Properties.Resources.Circle;
            tmp.Location = new Point (10,200);
            this.Controls.Add(tmp);

        }


        private void tmpSphere_Click(object sender, EventArgs e)
        {
        
        }
}
