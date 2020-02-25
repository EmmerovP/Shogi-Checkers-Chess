using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowLayout
{
    public partial class PawnChange : Form
    {
        public PawnChange()
        {
            InitializeComponent();
        }

        public enum Piece
        {
            Queen,
            Rook,
            Bishop,
            Horse,
            None
        }

        public static Piece Chosen = Piece.None;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.AliceBlue;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            Chosen = Piece.Queen;
            button1.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.AliceBlue;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            Chosen = Piece.Rook;
            button1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.AliceBlue;
            pictureBox4.BackColor = Color.Transparent;
            Chosen = Piece.Horse;
            button1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.AliceBlue;
            Chosen = Piece.Bishop;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ok, cancel, abort, retry
            switch (Chosen)
            {
                case Piece.Queen:
                    button1.DialogResult = DialogResult.OK;
                    break;
                case Piece.Rook:
                    button1.DialogResult = DialogResult.Cancel;
                    break;
                case Piece.Bishop:
                    button1.DialogResult = DialogResult.Abort;
                    break;
                case Piece.Horse:
                    button1.DialogResult = DialogResult.Retry;
                    break;
            }
        }
    }
}
