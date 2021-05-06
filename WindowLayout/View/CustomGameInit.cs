using System;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// Maximum size of chessboard.
        /// </summary>
        const int MAX_SIZE = 10;

        /// <summary>
        /// Minimum size of chessboard.
        /// </summary>
        const int MIN_SIZE = 3;

        /// <summary>
        /// If true, then the game that is played is custom game created by user.
        /// </summary>
        public bool isCustom = false;

        /// <summary>
        /// Method is called after CustomGameSizeButton is clicked, reads text from CustomGameSizeXTextbox and CustomGameSizeXTextbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomGameSizeButton_Click(object sender, EventArgs e)
        {
            string widthText = CustomGameSizeXTextbox.Text;
            string heigthText = CustomGameSizeYTextbox.Text;

            //try to read width
            int width;

            bool success = Int32.TryParse(widthText, out width);

            //check constraints
            if (!success)
            {
                CustomGameSizeErrorLabel.Visible = true;
                CustomGameSizeErrorLabel.Text = "Chyba - nebylo zadáno platné číslo.";
                return;
            }

            if (width < MIN_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice x je moc malá, musí být alespoň 3.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            if (width > MAX_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice x je moc velká, musí být maximálně 15.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            //try to read height
            int height;

            success = Int32.TryParse(heigthText, out height);

            //check constraints
            if (!success)
            {
                CustomGameSizeErrorLabel.Visible = true;
                CustomGameSizeErrorLabel.Text = "Chyba - nebylo zadáno platné číslo.";
                return;
            }

            if (height < MIN_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice y je moc malá, musí být alespoň 3.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            if (height > MAX_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice y je moc velká, musí být maximálně 15.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            chessboard = new int[width, height];

            //set all fields as empty
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    SetFieldEmpty(i, j, chessboard);
                }
            }

            //show next field
            CustomGameSizeButton.Visible = false;
            CustomGameSizeLabel.Visible = false;
            CustomGameSizeXLabel.Visible = false;
            CustomGameSizeXTextbox.Visible = false;
            CustomGameSizeYLabel.Visible = false;
            CustomGameSizeYTextbox.Visible = false;
            CustomGameSizeErrorLabel.Visible = false;
            CustomGameTypeLabel.Visible = true;

            SelectCheckersButton.Visible = true;
            SelectChessButton.Visible = true;
            SelectShogiButton.Visible = true;
        }

        /// <summary>
        /// Draws chessboard so user can put their pieces on it as they wish.
        /// </summary>
        private void DrawCustomChessboard()
        {           
            CustomGameTypeLabel.Visible = false;
            SelectCustomGameButton.Visible = false;

            DrawChessboard();
            Gameclass.CurrentGame.GameEnded = true;

            CustomGameChooseCombobox.Visible = true;
            CustomGameChooseLabel.Visible = true;
            NewGameButton.Visible = true;

            AddPiece = true;
        }


        /// <summary>
        /// Sets field on given integer board as empty
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="chessboard"></param>
        private void SetFieldEmpty(int x, int y, int[,] board)
        {
            board[x, y] = -1;
        }

        /// <summary>
        /// Checks if all needed pieces are put on board, and starts new game created by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            

            bool isWhite = false;
            bool isBlack = false;

            bool isWhiteKing = false;
            bool isBlackKing = false;

            bool upperShogiKing = false;
            bool bottomShogiKing = false;

            //checks what pieces are on board
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {                    
                    if (Board.board[i, j] != null)
                    {
                        if (Board.board[i, j].isWhite)
                        {
                            isWhite = true;
                        }
                        if (!Board.board[i, j].isWhite)
                        {
                            isBlack = true;
                        }
                        if (Board.board[i, j].GetNumber() == 0)
                        {
                            isWhiteKing = true;
                        }
                        if (Board.board[i, j].GetNumber() == 21)
                        {
                            isBlackKing = true;
                        }
                        if (Board.board[i, j].GetNumber() == 7)
                        {
                            bottomShogiKing = true;
                        }
                        if (Board.board[i, j].GetNumber() == 28)
                        {
                            upperShogiKing = true;
                        }
                    }

                }
            }

            if (!(isWhite && isBlack))
            {
                CustomGameChooseErrorLabel.Text = "Na šachovnici musí být figurky obou stran pro zahájení hry.";
                CustomGameChooseErrorLabel.Visible = true;
                return;

            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
            {
                if (!(isWhiteKing && isBlackKing))
                {
                    CustomGameChooseErrorLabel.Text = "Na šachovnici musí být králové obou stran.";
                    CustomGameChooseErrorLabel.Visible = true;
                    return;
                }
            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
            {
                if (!(bottomShogiKing && upperShogiKing))
                {
                    CustomGameChooseErrorLabel.Text = "Na šachovnici musí být králové obou stran.";
                    CustomGameChooseErrorLabel.Visible = true;
                    return;
                }
            }

            AddPiece = false;

            //start the game
            Gameclass.CurrentGame.GameEnded = false;

            CustomGameChooseCombobox.Visible = false;
            CustomGameChooseErrorLabel.Visible = false;
            CustomGameChooseLabel.Visible = false;
            NewGameButton.Visible = false;
        }

        /// <summary>
        /// Adds piece to a game that user creates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pieceNumber"></param>
        private void AddPieceToGame(int x, int y, int pieceNumber)
        {
            if (Board.board[x, y] != null)
            {
                return;
            }

            AddPieceToBoard(x, y, pieceNumber);

            //game doesn't allow to have multiple kings in it - we can have multiple shogi kings in chess game and multiple chess kings in shogi game though
            if (pieceNumber == 0)
            {
                CustomGameChooseCombobox.Items.Remove("Bílý král");
            }
            if (pieceNumber == 7)
            {
                CustomGameChooseCombobox.Items.Remove("Spodní shogi král");
            }
            if (pieceNumber == 21)
            {
                CustomGameChooseCombobox.Items.Remove("Černý král");
            }
            if (pieceNumber == 28)
            {
                CustomGameChooseCombobox.Items.Remove("Vrchní shogi král");
            }
        }

        /// <summary>
        /// Adds piece from CustomGameChooseCombobox to board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void WhichPiece(int x, int y)
        {
            string piece = CustomGameChooseCombobox.Text;
            
            //check if text in comboBox is valid
            try
            {
                int pieceNumber = PiecesNumbers.getNumber[piece];
                AddPieceToGame(x, y, pieceNumber);
            }
            catch
            {
                return;
            } 

        }

    }
}