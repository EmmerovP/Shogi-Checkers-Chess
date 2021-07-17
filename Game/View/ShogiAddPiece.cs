using System;
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
            if (!Generating.WhitePlays || ChooseShogiBottomBox.Text == "")
            {
                return;
            }

            //gets piece we are getting from ComboBox
            string Piece = ChooseShogiBottomBox.Text;
            PutShogiPieceBottomLabel.Visible = true;
            pieceBeingAddedToBoard = PiecesNumbers.getBottomNumber[Piece];
            AddBottomShogiPiece = true;

            ChooseShogiBottomBox.Items.Remove(Piece);
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
            if (Generating.WhitePlays || ChooseShogiBoxUpper.Text == "")
            {
                return;
            }

            //gets piece we are getting from ComboBox
            string Piece = ChooseShogiBoxUpper.Text;
            PutShogiPieceUpperLabel.Visible = true;
            pieceBeingAddedToBoard = PiecesNumbers.getUpperNumber[Piece];
            AddUpperShogiPiece = true;

            ChooseShogiBoxUpper.Items.Remove(Piece);

        }

        /// <summary>
        /// After clicking on a board, adds specified piece as bottom piece we already have in our program in variable ShogiPiece.
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
            if (PiecesNumbers.getNumber["Spodní shogi pěšák"] == pieceBeingAddedToBoard)
            {
                for (int i = 0; i < Board.board.GetLength(1); i++)
                {
                    if ((Board.board[i, selected_y] != null) && (Board.board[i, selected_y].GetNumber() == PiecesNumbers.getNumber["Spodní shogi pěšák"]))
                    {
                        MessageBox.Show("Shogi pěšec nesmí být vložen do sloupce, v němž již shogi pěšec je.", "Figurka nelze vložit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        PutShogiPieceBottomLabel.Visible = false;
                        AddBottomShogiPiece = false;
                        ChooseShogiBottomBox.Items.Add("Shogi pěšák");

                        return;
                    }
                }
            }

            //hide label telling user to put piece on board
            PutShogiPieceBottomLabel.Visible = false;

            //signal that we have added a piece to board
            AddBottomShogiPiece = false;

            AddPieceToBoard(selected_x, selected_y, pieceBeingAddedToBoard);

            Generating.WhitePlays = !Generating.WhitePlays;

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess && Gameclass.CurrentGame.KingCheck(Board.board))
            {
                MessageBox.Show("Figurka nelze přidat kvůli šachu na krále!", "Figurka nelze vložit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChooseShogiBottomBox.Items.Add(Board.board[selected_x, selected_y].Name);
                Board.board[selected_x, selected_y] = null;
                piecesPictures[selected_x, selected_y].Dispose();
                piecesPictures[selected_x, selected_y].Refresh();
                Generating.WhitePlays = !Generating.WhitePlays;
                
                return;
            }
            else
            {
                //removes piece from list of available pieces
                ChooseShogiBottomBox.Items.Remove(ChooseShogiBottomBox.SelectedItem);
            }

            //in case there are different types of play on the board, switch them 
            if (Gameclass.CurrentGame.whiteGameType != Gameclass.CurrentGame.blackGameType)
            {
                if (Gameclass.CurrentGame.gameType == Gameclass.CurrentGame.blackGameType)
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.whiteGameType;
                }
                else
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.blackGameType;
                }
            }

            if (Gameclass.CurrentGame.whitePlayType != Gameclass.CurrentGame.blackPlayType)
            {
                if (Gameclass.CurrentGame.playType == Gameclass.CurrentGame.blackPlayType)
                {
                    Gameclass.CurrentGame.playType = Gameclass.CurrentGame.whitePlayType;
                }
                else
                {
                    Gameclass.CurrentGame.playType = Gameclass.CurrentGame.blackPlayType;
                }
            }

            //if the game is singleplayer, enemy should play
            if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
            {
                SinglerplayerPlay();
            }

        }


        /// <summary>
        /// After clicking on a board, adds specified piece as upper piece we already have in our program in variable ShogiPiece.
        /// </summary>
        /// <param name="selected_x"></param>
        /// <param name="selected_y"></param>
        private void AddUpperShogi(int selected_x, int selected_y)
        {
            //we cannot add piece to a field that already has a piece
            if (Board.board[selected_x, selected_y] != null)
            {
                return;
            }

            //we cannot add shogi pawn to a column that already has a shogi pawn in it
            if (PiecesNumbers.getNumber["Vrchní shogi pěšák"] == pieceBeingAddedToBoard)
            {
                for (int i = 0; i < Board.board.GetLength(1); i++)
                {
                    if ((Board.board[i, selected_y] != null) && (Board.board[i, selected_y].GetNumber() == PiecesNumbers.getNumber["Vrchní shogi pěšák"]))
                    {
                        MessageBox.Show("Shogi pěšec nesmí být vložen do sloupce, v němž již shogi pěšec je.", "Figurka nelze vložit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        PutShogiPieceUpperLabel.Visible = false;
                        AddUpperShogiPiece = false;
                        ChooseShogiBoxUpper.Items.Add("Shogi pěšák");


                        return;
                    }

                }
            }

            //hide label telling user to put piece on board
            PutShogiPieceUpperLabel.Visible = false;

            //signal that we have added a piece to board
            AddUpperShogiPiece = false;

            AddPieceToBoard(selected_x, selected_y, pieceBeingAddedToBoard);

            Generating.WhitePlays = !Generating.WhitePlays;


            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess && Gameclass.CurrentGame.KingCheck(Board.board))
            {
                MessageBox.Show("Figurka nelze přidat kvůli šachu na krále!", "Figurka nelze vložit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChooseShogiBoxUpper.Items.Add(Board.board[selected_x, selected_y].Name);
                Board.board[selected_x, selected_y] = null;
                piecesPictures[selected_x, selected_y].Dispose();
                piecesPictures[selected_x, selected_y].Refresh();
                Generating.WhitePlays = !Generating.WhitePlays;
                return;

            }
            else
            {
                //removes piece from list of available pieces
                ChooseShogiBoxUpper.Items.Remove(ChooseShogiBoxUpper.SelectedItem);
            }

            //in case there are different types of play on the board, switch them 
            if (Gameclass.CurrentGame.whiteGameType != Gameclass.CurrentGame.blackGameType)
            {
                if (Gameclass.CurrentGame.gameType == Gameclass.CurrentGame.blackGameType)
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.whiteGameType;
                }
                else
                {
                    Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.blackGameType;
                }
            }

            if (Gameclass.CurrentGame.whitePlayType != Gameclass.CurrentGame.blackPlayType)
            {
                if (Gameclass.CurrentGame.playType == Gameclass.CurrentGame.blackPlayType)
                {
                    Gameclass.CurrentGame.playType = Gameclass.CurrentGame.whitePlayType;
                }
                else
                {
                    Gameclass.CurrentGame.playType = Gameclass.CurrentGame.blackPlayType;
                }
            }

            if (!isPlayer)
            {
                return;
            }





        }

    }
}