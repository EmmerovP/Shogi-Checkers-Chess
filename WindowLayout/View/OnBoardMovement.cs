using System;
using System.Drawing;
using System.Windows.Forms;


namespace ShogiCheckersChess
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
                if (EndGame())
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
                    Highlight();
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

            if (Gameclass.CurrentGame.algorithmType == Gameclass.AlgorithmType.minimax)
            {
                move = Minimax.GetNextMove();
            }
            else
            {
                move = MonteCarlo.MonteCarloMove();
            }

            Generating.WhitePlays = whoPlays;
         
            //instead of move, we are adding a piece on the board
            if (Minimax.isAddingPiece)
            {
                AddPieceToBoard(Moves.final_x[move], Moves.final_y[move], Moves.start_x[move]);             
                Board.board[Moves.final_x[move], Moves.final_y[move]].isWhite = false;
                Generating.WhitePlays = !Generating.WhitePlays;
                return;

            }


            //there are no more moves for the opponent's side, user won
            if (move == -1)
            {
                label2.Text = "Vyhráli jste!";
                return;
            }

            //move piece
            PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move], piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

            isPlayer = true;

        }


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
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && Board.board[final_x, final_y] != null)
            {
                if (!isPlayer)
                {
                    shogiAIPieces.Add(Board.board[final_x, final_y]);
                }
                else if (isPlayer && Generating.WhitePlays)
                {
                    ShowBottomShogiAddon();
                    ChooseShogiBoxBottom.Items.Add(Board.board[final_x, final_y].Name);
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
            MovePicture(movingPicture, final_x, final_y, start_x, start_y, piece);


            //when move is castling, we need to move the rook too
            if (MoveController.isCastling)
            {
                PictureBox rook = piecesPictures[MoveController.castling_x, MoveController.castling_y];
                piecesPictures[MoveController.castling_x, MoveController.castling_y] = null;
                piecesPictures[MoveController.castling_x, MoveController.castling_z] = rook;
                rook.Location = location[MoveController.castling_x, MoveController.castling_z];
                rook.BringToFront();
            }


            //change of piece - either promotion in shogi, or pawn coming to the end of the board
            if (ChangePiece(final_x, final_y, Board.board[final_x, final_y]))
            {
                movingPicture.Image = GamePieces.Images[Board.board[final_x, final_y].GetNumber()];
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
        public void MovePicture(PictureBox movingPicture, int final_x, int final_y, int start_x, int start_y, Pieces piece)
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

                //should we chain moves in checkers?
                if (piece.isWhite && Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers && piece.Name == "Kámen")
                {
                    if (Moves.WhiteCheckersTake(final_x, final_y, Board.board))
                    {

                        isCheckersPieceSupposedToTake = true;

                    }
                }
                else
                {
                    if (Moves.BlackCheckersTake(final_x, final_y, Board.board))
                    {

                        isCheckersPieceSupposedToTake = true;

                    }
                }


            }

            if (isPlayer)
            {
                movingPicture.BackColor = Color.Transparent;
            }

            movingPicture.Location = location[final_x, final_y]; ;
            movingPicture.BringToFront();
            DeleteHighlight();

            movingPicture.Refresh();
        }

        public bool EndGame()
        {
            bool player = isPlayer;
            isPlayer = true;

            label2.Visible = false;
            //konec hry dáma
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
            {
                if (Gameclass.CurrentGame.CheckersEnd(Board.board))
                {
                    label2.Text = "Konec hry.";
                    label2.Visible = true;
                    Gameclass.CurrentGame.GameEnded = true;
                    return true;
                }
            }

            //konec hry shogi
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
            {
                if (Gameclass.CurrentGame.KingOut(Board.board))
                {
                    label2.Text = "Konec hry.";
                    label2.Visible = true;
                    Gameclass.CurrentGame.GameEnded = true;
                    return true;
                }
            }

            //tady by se mělo zkontrolovat, zda se neudělá šach TÍMTO tahem?
            Generating.WhitePlays = !Generating.WhitePlays;
            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.chess) && (Gameclass.CurrentGame.KingCheck(Board.board)))
            {
                label2.Text = "Šach!";
                label2.Visible = true;
                if (Gameclass.CurrentGame.CheckMate(Board.board))
                {
                    label2.Text = "Šach mat! Konec!";
                    Gameclass.CurrentGame.GameEnded = true;
                    return true;
                }
            }
            Generating.WhitePlays = !Generating.WhitePlays;

            //může protějšek udělat tah?
            Moves.EmptyCoordinates();
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if ((Board.board[i, j] != null) && (Board.board[i, j].isWhite == Generating.WhitePlays))
                    {
                        Generating.Generate(Board.board[i, j], false, i, j, true, Board.board);
                    }
                }
            }

            if (Moves.final_x.Count == 0)
            {
                label2.Text = "Nelze udělat tah, konec.";
                label2.Visible = true;
                Moves.EmptyCoordinates();
                return true;
            }

            isPlayer = player;
            Moves.EmptyCoordinates();
            return false;
        }




        //měnění figurek - logika
        public bool ChangePiece(int x, int y, Pieces piece)
        {

            //upperpawn
            if ((piece.GetNumber() == 26) && (x == Board.board.GetLength(0) - 1))
            {
                if (isPlayer)
                {
                    PawnChange popup = new PawnChange();
                    DialogResult dialogresult = popup.ShowDialog();
                    switch (dialogresult)
                    {
                        case DialogResult.OK:
                            Board.AddPiece(22, x, y);
                            break;
                        case DialogResult.Cancel:
                            Board.AddPiece(23, x, y);
                            break;
                        case DialogResult.Abort:
                            Board.AddPiece(25, x, y);
                            break;
                        case DialogResult.Retry:
                            Board.AddPiece(24, x, y);
                            break;

                    }
                    popup.Dispose();
                    return true;
                }
                else
                {
                    Board.AddPiece(22, x, y);
                    return true;
                }

            }

            //bottompawn
            if ((piece.GetNumber() == 5) && (x == 0))
            {
                PawnChange popup = new PawnChange();
                DialogResult dialogresult = popup.ShowDialog();
                switch (dialogresult)
                {
                    case DialogResult.OK:
                        Board.AddPiece(1, x, y);
                        break;
                    case DialogResult.Cancel:
                        Board.AddPiece(2, x, y);
                        break;
                    case DialogResult.Abort:
                        Board.AddPiece(4, x, y);
                        break;
                    case DialogResult.Retry:
                        Board.AddPiece(3, x, y);
                        break;

                }
                popup.Dispose();
                return true;
            }

            //shogi - only one side works, second TODO

            //checkers - upper piece
            if ((piece.GetNumber() == 27) && (x == Board.board.GetLength(1) - 1))
            {
                Board.AddPiece(22, x, y);
                return true;
            }

            //checkers - bottom piece
            if ((piece.GetNumber() == 6) && (x == 0))
            {
                Board.AddPiece(1, x, y);
                return true;
            }

            //upper shogi rooks
            if ((piece.GetNumber() == 29) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(30, x, y);
            }

            //bottom shogi rook promotion
            if ((piece.GetNumber() == 8) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(9, x, y);
            }


            //bishop promotion
            //upper bishop 
            if ((piece.GetNumber() == 31) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(32, x, y);
            }

            //bottom bishop
            if ((piece.GetNumber() == 10) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(11, x, y);
            }

            //silver general promotion
            //upper 
            if ((piece.GetNumber() == 34) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(35, x, y);
            }

            //bottom
            if ((piece.GetNumber() == 13) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(14, x, y);
            }

            //horse promotion
            //upper
            if ((piece.GetNumber() == 36) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(37, x, y);
            }

            //bottom
            if ((piece.GetNumber() == 15) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(16, x, y);
            }

            //lance promotion
            //upper
            if ((piece.GetNumber() == 38) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(39, x, y);
            }

            //bottom
            if ((piece.GetNumber() == 17) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(18, x, y);
            }

            //pawn promotion
            //upper
            if ((piece.GetNumber() == 40) && (Generating.UpperShogiPromotion(x)))
            {
                Propagate(41, x, y);
            }

            //bottom
            if ((piece.GetNumber() == 19) && (Generating.BottomShogiPromotion(x)))
            {
                Propagate(20, x, y);
            }

            return false;

        }


        public bool Propagate(int PieceNumber, int x, int y)
        {
            if (isPlayer)
            {
                Propagation popup = new Propagation();
                DialogResult result = popup.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Board.AddPiece(PieceNumber, x, y);
                    popup.Dispose();
                    return true;
                }
                popup.Dispose();
                return false;
            }
            else
            {
                Board.AddPiece(PieceNumber, x, y);
                return true;
            }

        }

    }

}