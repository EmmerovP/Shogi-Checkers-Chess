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

        public static string ShogiPieceName;

        private void AddBottomShogi(int selected_x, int selected_y)
        {
            if (Board.board[selected_x, selected_y] != null)
            {
                return;
            }

            if (ShogiPiece == 19)
            {
                for (int i = 0; i < Board.board.GetLength(1); i++)
                {
                    if ((Board.board[i, selected_y] != null) && (Board.board[i, selected_y].GetNumber() == 19))
                    {
                        ShogiPawnProblem popup = new ShogiPawnProblem();
                        DialogResult dialogresult = popup.ShowDialog();
                        popup.Dispose();

                        PutShogiPieceLabelBottom.Visible = false;
                        AddBottomShogiPiece = false;
                        ChooseShogiBoxBottom.Items.Add("Shogi pěšák");

                        return;
                    }
                }
            }

            PutShogiPieceLabelBottom.Visible = false;
            AddBottomShogiPiece = false;


            var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
            {
                Name = Convert.ToString(ShogiPiece),
                Size = new Size(50, 50),
                Location = location[selected_x, selected_y],
                BackColor = Color.Transparent,
                Image = GamePieces.Images[ShogiPiece],
                SizeMode = PictureBoxSizeMode.CenterImage,
            };

            this.Controls.Add(gamepiece);
            gamepiece.Click += MoveGamePiece;

            piecesPictures[selected_x, selected_y] = gamepiece;
            Board.AddPiece(ShogiPiece, selected_x, selected_y);

            gamepiece.BringToFront();

            ChooseShogiBoxBottom.Items.Remove(ShogiPieceName);

            Generating.WhitePlays = !Generating.WhitePlays;


            if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
            {

                isPlayer = false;
                int move = RandomMoveGen.FindPiece();

                if (move == -1)
                {
                    label2.Text = "Vyhráli jste!";
                    return;
                }

                PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                    piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                isPlayer = true;

            }


        }

        private void AddUpperShogi(int selected_x, int selected_y)
        {
            if (Board.board[selected_x, selected_y] != null)
            {
                return;
            }

            if (ShogiPiece == 40)
            {
                for (int i = 0; i < Board.board.GetLength(1); i++)
                {
                    if ((Board.board[i, selected_y] != null) && (Board.board[i, selected_y].GetNumber() == 40))
                    {
                        ShogiPawnProblem popup = new ShogiPawnProblem();
                        DialogResult dialogresult = popup.ShowDialog();
                        popup.Dispose();

                        PutShogiPieceLabelUpper.Visible = false;
                        AddUpperShogiPiece = false;
                        ChooseShogiBoxUpper.Items.Add("Shogi pěšák");


                        return;
                    }

                }
            }

            PutShogiPieceLabelUpper.Visible = false;
            AddUpperShogiPiece = false;

            var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
            {
                Name = Convert.ToString(ShogiPiece),
                Size = new Size(50, 50),
                Location = location[selected_x, selected_y],
                BackColor = Color.Transparent,
                Image = GamePieces.Images[ShogiPiece],
                SizeMode = PictureBoxSizeMode.CenterImage,
            };

            this.Controls.Add(gamepiece);
            gamepiece.Click += MoveGamePiece;

            piecesPictures[selected_x, selected_y] = gamepiece;
            Board.AddPiece(ShogiPiece, selected_x, selected_y);

            gamepiece.BringToFront();

            ChooseShogiBoxBottom.Items.Remove(ShogiPieceName);

            Generating.WhitePlays = !Generating.WhitePlays;


            if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
            {

                isPlayer = false;
                int move = RandomMoveGen.FindPiece();

                if (move == -1)
                {
                    label2.Text = "Vyhráli jste!";
                    return;
                }

                PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                    piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                isPlayer = true;

            }


        }

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
            
            ShogiPiece = PiecesNumbers.getBottomNumber[Piece];
            AddBottomShogiPiece = true;

            ChooseShogiBoxBottom.Items.Remove(Piece);
            ChooseShogiBoxBottom.Text = "";

            ShogiPieceName = Piece;
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
            
            ShogiPiece = PiecesNumbers.getUpperNumber[Piece];
            AddUpperShogiPiece = true;

            ChooseShogiBoxUpper.Items.Remove(Piece);
            ChooseShogiBoxUpper.Text = "";

            ShogiPieceName = Piece;
        }
    }
}