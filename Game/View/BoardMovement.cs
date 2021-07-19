using System;
using System.Drawing;
using System.Windows.Forms;


namespace GeneralBoardGames
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// True when we are supposed to take another piece in the same move after we have already taken one.
        /// </summary>
        public static bool CheckersTake;

        /// <summary>
        /// True when we are trying to add piece on board in next move.
        /// </summary>
        public static bool AddPiece = false;

        /// <summary>
        /// Signalizes that next click on the board adds shogi piece for bottom player.
        /// </summary>
        public static bool AddBottomShogiPiece = false; 

        /// <summary>
        /// Signalizes that next click on the board adds shogi piece for upper player.
        /// </summary>
        public static bool AddUpperShogiPiece = false;

        /// <summary>
        /// True when the user alredy clicked on a piece on board and tht piece is selected.
        /// </summary>
        public static bool IsPieceSelected = false;

        /// <summary>
        /// Variable with picture of piece we are moving with.
        /// </summary>
        public static PictureBox selectedPictureOfPiece;


        /// <summary>
        /// Called after a field on the board is clicked. Takes care of all the visualisation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveGamePiece(object sender, EventArgs e)
        {
            //picture user has clicked on
            PictureBox picture = (PictureBox)sender;


            //get coordinates of picture
            int selected_x = GetX(picture);
            int selected_y = GetY(picture);

            //when we are adding piece to board
            if (AddPiece)
            {
                GetPieceNumberFromUserAndAdd(selected_x, selected_y);
                return;
            }

            //if game ended, we aren't playing anymore
            if (Gameclass.CurrentGame.GameEnded)
                return;


            //when we are adding bottom shogi piece
            if (AddBottomShogiPiece)
            {
                AddBottomShogi(selected_x, selected_y);

                return;
            }

            //when we are adding upper shogi piece
            if (AddUpperShogiPiece)
            {
                AddUpperShogi(selected_x, selected_y);

                return;
            }

            //indicate the meaning of a field with color
            Color backgroundColor;


            if (Board.board[selected_x, selected_y] == null)
            {
                backgroundColor = Color.Crimson;
            }
            else
            {
                backgroundColor = Color.DarkBlue;
            }

            //we click on empty field or an enemy
            if (IsFieldNotUsable(selected_x, selected_y))
            {
                return;
            }

            //we do an actual move
            if (IsMove(selected_x, selected_y))
            {
                isPlayer = true;

                int piecePosition_x = GetX(selectedPictureOfPiece);
                int piecePosition_y = GetY(selectedPictureOfPiece);

                //move a piece
                PieceMovement(piecePosition_x, piecePosition_y, selected_x, selected_y, selectedPictureOfPiece);

                
                //check the end of the game
                if (EndGame(Generating.WhitePlays))
                {
                    return;
                }
                


                //for chaining taking of pieces in shogi
                if (CheckersTake)
                {
                    Generating.WhitePlays = !Generating.WhitePlays;
                    return;
                }

                //when opponent is playing, we make the move
                if ((Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single) && (!isCheckersPieceSupposedToTake))
                {
                    SinglerplayerPlay();
                }
            }

            //else if we have selected piece, but we can't move the piece to the current selected
            else if (IsPieceSelected)
            {
                DeleteHighlight();
                selectedPictureOfPiece.BackColor = Color.Transparent;
                IsPieceSelected = false;
            }

            //is clicked on piece, we remember it
            else if (!IsPieceSelected)
            {
                DeleteHighlight();
                picture.BackColor = backgroundColor;
                selectedPictureOfPiece = picture;
                IsPieceSelected = true;

                if (backgroundColor == Color.DarkBlue)
                {
                    Generating.Generate(GetPiece(picture), true, GetX(picture), GetY(picture), true, Board.board);
                    HighlightMoves();
                }
            }
        }

        /// <summary>
        /// Gets picturebox of a piece, returns its piece representation in Board.board
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public Pieces GetPiece(PictureBox piece)
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (location[i, j] == piece.Location)
                        return Board.board[i, j];
                }
            }
            return null;
        }

        /// <summary>
        /// Get x coordinate of piece represented by a picturebox
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public int GetX(PictureBox piece)
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (location[i, j] == piece.Location)
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get x coordinate of piece represented by a picturebox
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public int GetY(PictureBox piece)
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (location[i, j] == piece.Location)
                        return j;
                }
            }
            return -1;
        }

        /// <summary>
        /// Highlitghts all fields where we can move with a piece with yellow color.
        /// </summary>
        public void HighlightMoves()
        {
            for (int i = 0; i < Moves.final_x.Count; i++)
            {
                pictureBoxes[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
                if (piecesPictures[Moves.final_x[i], Moves.final_y[i]] != null)
                    piecesPictures[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
            }
        }

        /// <summary>
        /// Deletes all highlight from the board.
        /// </summary>
        public void DeleteHighlight()
        {
            for (int i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < pictureBoxes.GetLength(1); j++)
                {
                    pictureBoxes[i, j].BackColor = Color.Transparent;
                    pictureBoxes[i, j].Refresh();
                    if (piecesPictures[i, j] != null)
                    {
                        piecesPictures[i, j].BackColor = Color.Transparent;
                        piecesPictures[i, j].Refresh();
                    }

                }
            }
        }


        /// <summary>
        /// Returns true when given field is not the one to be interacted with.
        /// </summary>
        public bool IsFieldNotUsable(int selected_x, int selected_y)
        {
            if ((Board.board[selected_x, selected_y] != null) && Board.board[selected_x, selected_y].isWhite != Generating.WhitePlays && (!IsPieceSelected))
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Returns true when the current click makes a move.
        /// </summary>
        /// <param name="selected_x"></param>
        /// <param name="selected_y"></param>
        /// <returns></returns>
        public bool IsMove(int selected_x, int selected_y)
        {
            if ((IsPieceSelected) && (selectedPictureOfPiece.BackColor != Color.Crimson) && (pictureBoxes[selected_x, selected_y].BackColor != Color.Transparent))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Depending on selected algorithm, makes a move with it.
        /// </summary>
        public void SinglerplayerPlay()
        {
            isPlayer = false;

            int move;

            //remember who plays in case the algorithm changes it in its proccess
            bool whoPlays = Generating.WhitePlays;

            Gameclass.GameType currentType = Gameclass.CurrentGame.gameType;

            if (Gameclass.CurrentGame.algorithmType == Gameclass.AlgorithmType.minimax)
            {
                move = Minimax.GetNextMove();
            }
            else
            {
                move = MonteCarlo.GetNextMove(false);
            }

            Gameclass.CurrentGame.gameType = currentType;

            Generating.WhitePlays = whoPlays;

            //instead of move, we are adding a piece on the board
            if ((Minimax.isAddingPiece)||(MonteCarlo.isAddingPiece))
            {
                AddPieceToBoard(Moves.final_x[move], Moves.final_y[move], Moves.start_x[move]);
                Board.board[Moves.final_x[move], Moves.final_y[move]].isWhite = false;

                Generating.WhitePlays = !Generating.WhitePlays;

                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
                {
                    if (Gameclass.CurrentGame.KingCheck(Board.board))
                    {
                        GameStateLabel.Visible = true;
                        GameStateLabel.Text = "Šach!";
                        if (Gameclass.CurrentGame.CheckMate(Board.board))
                        {
                            GameStateLabel.Text = "Šach mat! Konec!";
                            Gameclass.CurrentGame.GameEnded = true;
                        }
                    }
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

                return;

            }


            //there are no more moves for the opponent's side, user won
            if (move == -1)
            {
                GameStateLabel.Text = "Vyhráli jste!";
                return;
            }

            //move piece
            PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

            //check whether the game has ended
            EndGame(Generating.WhitePlays);

            isPlayer = true;

        }

        /// <summary>
        /// Returns true when checker piece is supposed to take.
        /// </summary>
        public static bool isCheckersPieceSupposedToTake;

        /// <summary>
        /// Moves piece visually on main board.
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="movingPicture"></param>
        /// <returns></returns>
        public void PieceMovement(int start_x, int start_y, int final_x, int final_y, PictureBox movingPicture)
        {
            isCheckersPieceSupposedToTake = false;

            Pieces piece = Board.board[start_x, start_y];

            //when we take a piece in shogi, we remember it so we can put it back on board again later
            if (((Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi && Generating.WhitePlays) ||
                (Gameclass.CurrentGame.blackPlayType == Gameclass.GameType.shogi && !Generating.WhitePlays)) &&
                Board.board[final_x, final_y] != null)
            {
                if (!isPlayer)
                {
                    shogiAIPieces.Add(Board.board[final_x, final_y]);
                }
                else if (isPlayer && Generating.WhitePlays)
                {
                    ShowBottomShogiAddon();
                    ChooseShogiBottomBox.Items.Add(Board.board[final_x, final_y].Name);
                }
                else if (isPlayer && !Generating.WhitePlays)
                {
                    ShowUpperShogiAddon();
                    ChooseShogiBoxUpper.Items.Add(Board.board[final_x, final_y].Name);
                }
            }

            //apply move to model
            MoveController.ApplyMove(start_x, start_y, final_x, final_y, Board.board);

            //we deselect a piece when we move a piece
            IsPieceSelected = false;

            //Move piece visually
            MovePicture(movingPicture, final_x, final_y, start_x, start_y);


            //when move is castling, we need to move the rook too
            if (MoveController.isCastling)
            {
                PictureBox rook = piecesPictures[MoveController.castling_x, MoveController.castling_y];
                piecesPictures[MoveController.castling_x, MoveController.castling_y] = null;
                piecesPictures[MoveController.castling_x, MoveController.castling_z] = rook;
                rook.Location = location[MoveController.castling_x, MoveController.castling_z];
                rook.BringToFront();
            }

            //change of piece
            if (MoveController.pieceChanged || IsPawnAtTheEndOfBoard(final_x, final_y, piece) || Propagate(piece, final_x, final_y))
            {
                movingPicture.Image = GamePieces.Images[Board.board[final_x, final_y].GetNumber()];
                movingPicture.Refresh();
            }

            //switch sides
            Generating.WhitePlays = !Generating.WhitePlays;

            //when there is a chain taking of pieces in checkers, we need to make another move
            if (isCheckersPieceSupposedToTake)
            {
                Generating.WhitePlays = !Generating.WhitePlays;

                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single && (!isPlayer))
                {
                    SinglerplayerPlay();
                }
            }

        }

        /// <summary>
        /// Changes locations of pictures during a move on board.
        /// </summary>
        /// <param name="movingPicture"></param>
        /// <param name="final_x"></param>
        /// <param name="final_y"></param>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="piece"></param>
        public void MovePicture(PictureBox movingPicture, int final_x, int final_y, int start_x, int start_y)
        {
            piecesPictures[start_x, start_y] = null;

            //in case we take a piece, we need to dispose according pictureBox
            if (piecesPictures[final_x, final_y] != null)
            {
                piecesPictures[final_x, final_y].Dispose();
            }

            //moving piece
            piecesPictures[final_x, final_y] = movingPicture;

            //we need to delete some other piece, for example in checkers
            if (MoveController.delete_x != -1)
            {
                piecesPictures[MoveController.delete_x, MoveController.delete_y].Dispose();
                piecesPictures[MoveController.delete_x, MoveController.delete_y].Refresh();
            }

            //when we move piece, we delete its highlight
            if (isPlayer)
            {
                movingPicture.BackColor = Color.Transparent;
            }

            movingPicture.Location = location[final_x, final_y]; ;
            movingPicture.BringToFront();
            DeleteHighlight();

            //refresh board so the changes are instant
            movingPicture.Refresh();
        }

        /// <summary>
        /// Shows a label signalizing the end of a game.
        /// </summary>
        public void SignalEndGame()
        {
            GameStateLabel.Text = "Konec hry.";
            GameStateLabel.Visible = true;
            Gameclass.CurrentGame.GameEnded = true;
        }

        /// <summary>
        /// Check whether the game has ended. Returns true if it did.
        /// </summary>
        /// <returns></returns>
        public bool EndGame(bool WhitePlays)
        {
            //the game has ended
            if (Gameclass.CurrentGame.GameEnded)
            {
                return true;
            }

            Gameclass.GameType gameType;

            if (WhitePlays)
            {
                gameType = Gameclass.CurrentGame.whiteGameType;
            }
            else
            {
                gameType = Gameclass.CurrentGame.blackGameType;
            }

            //set isPlayer as true, remember current state
            bool player = isPlayer;
            isPlayer = true;

            //hide label showing game state. When there is needed to show some game state, it will reappear again
            GameStateLabel.Visible = false;

            //checkers end when we can't make any move
            if (gameType == Gameclass.GameType.checkers)
            {
                if (Gameclass.CurrentGame.CheckersEnd(Board.board))
                {
                    SignalEndGame();
                    return true;
                }
            }

            //shogi ends when the opponent takes king's piece
            if (gameType == Gameclass.GameType.shogi)
            {
                if (Gameclass.CurrentGame.KingOut(Board.board))
                {
                    SignalEndGame();
                    return true;
                }
            }

            //in chess, first, we look if we have check, then look if it isn't checkmate
            //for this, we need to switch sides
            Generating.WhitePlays = !Generating.WhitePlays;

            if ((gameType == Gameclass.GameType.chess) && (Gameclass.CurrentGame.KingCheck(Board.board)))
            {
                GameStateLabel.Text = "Šach!";
                GameStateLabel.Visible = true;
                if (Gameclass.CurrentGame.CheckMate(Board.board))
                {
                    GameStateLabel.Text = "Šach mat! Konec!";
                    Gameclass.CurrentGame.GameEnded = true;
                    return true;
                }
            }

            Generating.WhitePlays = !Generating.WhitePlays;

            Moves.EmptyCoordinates();

            //when player can't make any move, the game also ends
            Generating.GenerateAllMoves(Board.board, true);

            if (Moves.final_x.Count == 0)
            {
                GameStateLabel.Text = "Nelze udělat tah, konec.";
                GameStateLabel.Visible = true;
                Moves.EmptyCoordinates();
                return true;
            }

            //revert changes
            isPlayer = player;
            Moves.EmptyCoordinates();

            return false;
        }

        /// <summary>
        /// When the pawn in chess comes to an end of a board, we ask player what piece they want to switch it to.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="piece"></param>
        /// <returns></returns>
        public bool IsPawnAtTheEndOfBoard(int x, int y, Pieces piece)
        {
            if (!isPlayer)
            {
                return false;
            }

            if (PiecesNumbers.IsUpperPawn(piece) && (x == Board.board.GetLength(0) - 1))
            {

                PawnChange popup = new PawnChange();
                DialogResult dialogresult = popup.ShowDialog();
                switch (dialogresult)
                {
                    case DialogResult.OK:
                        Board.AddPiece(PiecesNumbers.getNumber["Černá královna"], x, y, Board.board);
                        break;
                    case DialogResult.Cancel:
                        Board.AddPiece(PiecesNumbers.getNumber["Černá věž"], x, y, Board.board);
                        break;
                    case DialogResult.Abort:
                        Board.AddPiece(PiecesNumbers.getNumber["Černý střelec"], x, y, Board.board);
                        break;
                    case DialogResult.Retry:
                        Board.AddPiece(PiecesNumbers.getNumber["Černý kůň"], x, y, Board.board);
                        break;

                }
                popup.Dispose();
                return true;

            }


            if (PiecesNumbers.IsBottomPawn(piece) && (x == 0))
            {
                PawnChange popup = new PawnChange();
                DialogResult dialogresult = popup.ShowDialog();
                switch (dialogresult)
                {
                    case DialogResult.OK:
                        Board.AddPiece(PiecesNumbers.getNumber["Bílá královna"], x, y, Board.board);
                        break;
                    case DialogResult.Cancel:
                        Board.AddPiece(PiecesNumbers.getNumber["Bílá věž"], x, y, Board.board);
                        break;
                    case DialogResult.Abort:
                        Board.AddPiece(PiecesNumbers.getNumber["Bílý střelec"], x, y, Board.board);
                        break;
                    case DialogResult.Retry:
                        Board.AddPiece(PiecesNumbers.getNumber["Bílý kůň"], x, y, Board.board);
                        break;

                }
                popup.Dispose();
                return true;
            }

            return false;
        }


        /// <summary>
        /// Asks player if they want to propagate shogi piece. Propagates it.
        /// </summary>
        /// <param name="PieceNumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Propagate(Pieces piece, int x, int y)
        {
            if (!isPlayer)
            {
                return false;
            }

            if ((Generating.UpperShogiPromotion(x, Board.board) && (!piece.isWhite)) || (Generating.BottomShogiPromotion(x) && piece.isWhite))
            {
                foreach (var pieceNumber in PiecesNumbers.canPropagate)
                {
                    if (pieceNumber == piece.GetNumber())
                    {
                        Propagation popup = new Propagation();
                        DialogResult result = popup.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            Board.AddPiece(piece.GetNumber() + 1, x, y, Board.board);
                            popup.Dispose();
                            return true;
                        }
                        popup.Dispose();
                        return false;
                    }

                }

                
            }
            return false;
        }

    }

}