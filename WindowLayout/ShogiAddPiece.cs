using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        private void ChooseShogiButtonBottom_Click(object sender, EventArgs e)
        {
            if (AddBottomShogiPiece)
            {
                return;
            }

            if (!Generating.WhitePlays)
            {
                return;
            }

            string Piece = ChooseShogiBoxBottom.Text;
            PutShogiPieceLabelBottom.Visible = true;
            ChooseShogiBoxBottom.Text = "";
            switch (Piece)
            {
                case "":
                    return;
                case "King":
                    ShogiPiece = 7;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("King");
                    break;
                case "Rook":
                    ShogiPiece = 8;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Rook");
                    break;
                case "Bishop":
                    ShogiPiece = 10;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Bishop");
                    break;
                case "Gold general":
                    ShogiPiece = 12;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Gold general");
                    break;
                case "Silver General":
                    ShogiPiece = 13;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Silver General");
                    break;
                case "Horse":
                    ShogiPiece = 15;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Horse");
                    break;
                case "Lance":
                    ShogiPiece = 17;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Lance");
                    break;
                case "Pawn":
                    ShogiPiece = 19;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Pawn");
                    break;
                default:
                    break;
            }
        }

        private void ChooseShogiButtonUpper_Click(object sender, EventArgs e)
        {
            if (AddUpperShogiPiece)
            {
                return;
            }

            if (Generating.WhitePlays)
            {
                return;
            }

            string Piece = ChooseShogiBoxUpper.Text;
            PutShogiPieceLabelUpper.Visible = true;
            ChooseShogiBoxUpper.Text = "";
            switch (Piece)
            {
                case "":
                    return;
                case "King":
                    ShogiPiece = 28;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("King");
                    break;
                case "Rook":
                    ShogiPiece = 29;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Rook");
                    break;
                case "Bishop":
                    ShogiPiece = 31;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Bishop");
                    break;
                case "Gold general":
                    ShogiPiece = 33;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Gold general");
                    break;
                case "Silver General":
                    ShogiPiece = 34;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Silver General");
                    break;
                case "Horse":
                    ShogiPiece = 36;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Horse");
                    break;
                case "Lance":
                    ShogiPiece = 38;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Lance");
                    break;
                case "Pawn":
                    ShogiPiece = 40;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Pawn");
                    break;
                default:
                    break;
            }
        }
    }
}