using System;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// Maximum size of chessboard.
        /// </summary>
        const int MAX_SIZE = 15;

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
            NewGameInstanceButton.Visible = true;

            string widthText = CustomGameSizeXTextbox.Text;
            string heigthText = CustomGameSizeYTextbox.Text;

            //try to read width

            bool success = Int32.TryParse(widthText, out int width);

            //check constraints
            if (!success)
            {
                MessageBox.Show("Chyba - nebylo zadáno platné číslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (width < MIN_SIZE)
            {
                MessageBox.Show("Souřadnice x je moc malá, musí být alespoň 3.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (width > MAX_SIZE)
            {
                MessageBox.Show("Souřadnice x je moc velká, musí být maximálně 15.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //try to read height

            success = Int32.TryParse(heigthText, out int height);

            //check constraints
            if (!success)
            {
                MessageBox.Show("Chyba - nebylo zadáno platné číslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (height < MIN_SIZE)
            {
                MessageBox.Show("Souřadnice y je moc malá, musí být alespoň 3.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (height > MAX_SIZE)
            {
                MessageBox.Show("Souřadnice y je moc velká, musí být maximálně 15.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baseBoard = new int[width, height];

            //set all fields as empty
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    SetFieldEmpty(i, j, baseBoard);
                }
            }

            //show next field
            CustomGameSizeButton.Visible = false;
            CustomGameSizeLabel.Visible = false;
            CustomGameSizeXLabel.Visible = false;
            CustomGameSizeXTextbox.Visible = false;
            CustomGameSizeYLabel.Visible = false;
            CustomGameSizeYTextbox.Visible = false;

            PlayerTypePanel.Visible = true;
            OKbutton.Visible = true;
        }

        /// <summary>
        /// Draws chessboard so user can put their pieces on it as they wish.
        /// </summary>
        private void DrawCustomChessboard()
        {           
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
                        if (PiecesNumbers.IsWhiteKing(Board.board[i, j]))
                        {
                            isWhiteKing = true;
                        }
                        if (PiecesNumbers.IsBlackKing(Board.board[i, j]))
                        {
                            isBlackKing = true;
                        }
                        if (PiecesNumbers.IsBottomShogiKing(Board.board[i, j]))
                        {
                            bottomShogiKing = true;
                        }
                        if (PiecesNumbers.IsUpperShogiKing(Board.board[i, j]))
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

            /* //TODO
            //game doesn't allow to have multiple kings in it - we can have multiple shogi kings in chess game and multiple chess kings in shogi game though
            if (PiecesNumbers.getNumber["Bílý král"] == pieceNumber)
            {
                CustomGameChooseCombobox.Items.Remove("Bílý král");
            }
            if (PiecesNumbers.getNumber["Černý král"] == pieceNumber)
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
            */ //pro double chess-potřebuju ozkoušet jestli funguje, jinak to tady nechám 
        }

        /// <summary>
        /// Adds piece from CustomGameChooseCombobox to board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void GetPieceNumberFromUserAndAdd(int x, int y)
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