using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralBoardGames
{
    public partial class PawnChange : Form
    {
        public PawnChange()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.AliceBlue;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            button1.Visible = true;
            button1.DialogResult = DialogResult.OK;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.AliceBlue;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            button1.Visible = true;
            button1.DialogResult = DialogResult.Cancel;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.AliceBlue;
            pictureBox4.BackColor = Color.Transparent;
            button1.Visible = true;
            button1.DialogResult = DialogResult.Retry;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.AliceBlue;
            button1.Visible = true;
            button1.DialogResult = DialogResult.Abort;
        }



        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}
