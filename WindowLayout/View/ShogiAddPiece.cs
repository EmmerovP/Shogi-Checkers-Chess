using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {

        /// <summary>
        /// When we click a button to add a piece for bottom player, this handles logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseShogiButtonBottom_Click(object sender, EventArgs e)
        {
            //when we are already adding a piece, we return
            if (AddBottomShogiPiece)
            {
                return;
            }

            //when an opponent plays, we also return
            if (!Generating.WhitePlays)
            {
                return;
            }

            //gets piece we are getting from ComboBox
            string Piece = ChooseShogiBoxBottom.Text;
            PutShogiPieceLabelBottom.Visible = true;
            ShogiPiece = PiecesNumbers.getBottomNumber[Piece];
            AddBottomShogiPiece = true;

            ChooseShogiBoxBottom.Items.Remove(Piece);
        }

        /// <summary>
        /// When we click a button to add a piece for upper player, this handles logic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseShogiButtonUpper_Click(object sender, EventArgs e)
        {
            //when we are already adding a piece, we return
            if (AddUpperShogiPiece)
            {
                return;
            }

            //when an opponent plays, we also return
            if (Generating.WhitePlays)
            {
                return;
            }

            //gets piece we are getting from ComboBox
            string Piece = ChooseShogiBoxUpper.Text;
            PutShogiPieceLabelUpper.Visible = true;
            ShogiPiece = PiecesNumbers.getUpperNumber[Piece];
            AddUpperShogiPiece = true;

            ChooseShogiBoxUpper.Items.Remove(Piece);

        }

        /// <summary>
        /// After clicking on a board, adds specified piece we already have in our program in variable ShogiPiece.
        /// </summary>
        /// <param name="selected_x"></param>
        /// <param name="selected_y"></param>
        private void AddBottomShogi(int selected_x, int selected_y)
        {
            //we cannot add piece to a field that already has a piece
            if (Board.board[selected_x, selected_y] != null)
            {
                return;
            }

            //we cannot add shogi pawn to a column that already has a shogi pawn in it
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

            ChooseShogiBoxBottom.Items.Remove(ChooseShogiBoxBottom.SelectedItem);

            Generating.WhitePlays = !Generating.WhitePlays;


            if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
            {

                SinglerplayerPlay();

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
            Generating.WhitePlays = !Generating.WhitePlays;

            if (!isPlayer)
            {
                return;
            }

            ChooseShogiBoxUpper.Items.Remove(ChooseShogiBoxUpper.SelectedItem);



        }

    }
}