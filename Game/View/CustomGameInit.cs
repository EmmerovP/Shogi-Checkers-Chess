using System;
using System.Windows.Forms;

namespace GeneralBoardGames
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// Maximum size of chessboard.
        /// </summary>
        const int MAX_HEIGHT = 15;

        /// <summary>
        /// Maximum size of chessboard.
        /// </summary>
        const int MAX_WIDTH = 30;

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
            string heightText = HeightTextBox.Text;
            string widthText = WidthTextBox.Text;

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
                MessageBox.Show("Šířka je moc malá, musí být alespoň 3.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (width > MAX_WIDTH)
            {
                MessageBox.Show("Šířka je moc velká, musí být maximálně 25.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //try to read height

            success = Int32.TryParse(heightText, out int height);

            //check constraints
            if (!success)
            {
                MessageBox.Show("Chyba - nebylo zadáno platné číslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (height < MIN_SIZE)
            {
                MessageBox.Show("Výška je moc malá, musí být alespoň 3.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (height > MAX_HEIGHT)
            {
                MessageBox.Show("Výška je moc velká, musí být maximálně 15.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baseBoard = new int[height, width];

            //set all fields as empty
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    SetFieldEmpty(j, i, baseBoard);
                }
            }

            //show next field
            CustomGameSizeButton.Visible = false;
            CustomGameSizeLabel.Visible = false;
            CustomGameSizeXLabel.Visible = false;
            HeightTextBox.Visible = false;
            CustomGameSizeYLabel.Visible = false;
            WidthTextBox.Visible = false;           

            SetGamePropertiesPanel.Visible = true;
        }

        /// <summary>
        /// Method is called after GameParametersButton is clicked, sets type of game and handles possible errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameParametersButton_Click(object sender, EventArgs e)
        {
            switch (UpperEndgameComboBox.Text)
            {
                case "Šach mat krále (šachy)":
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.chess;
                    break;
                case "Sebrání krále (shogi)": 
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.shogi;
                    break;
                case "Nemožnost tahu":
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.checkers;
                    break;
                default:
                    MessageBox.Show("Nebyl zvolen konec hry pro černou/vrchní stranu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            switch (UpperSpecialActionsComboBox.Text)
            {
                case "Žádná":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.chess;
                    break;
                case "Přidávání vyhozených figur zpět do hry":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.shogi;
                    break;
                case "Nutnost sebrat figurku, je-li to možné":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.checkers;
                    break;
                default:
                    MessageBox.Show("Nebyla zvolena žádná speciální akce pro černou/vrchní stranu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            switch (BottomEndgameComboBox.Text)
            {
                case "Šach mat krále (šachy)":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.chess;
                    break;
                case "Sebrání krále (shogi)":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.shogi;
                    break;
                case "Nemožnost tahu":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.checkers;
                    break;
                default:
                    MessageBox.Show("Nebyl zvolen konec hry pro bílou/spodní stranu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            switch (BottomSpecialActionsComboBox.Text)
            {
                case "Žádná":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.chess;
                    break;
                case "Přidávání vyhozených figur zpět do hry":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.shogi;
                    break;
                case "Nutnost sebrat figurku, je-li to možné":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.checkers;
                    break;
                default:
                    MessageBox.Show("Nebyla zvolena žádná speciální akce pro bílou/spodní stranu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            Gameclass.CurrentGame.playType = Gameclass.CurrentGame.whitePlayType;
            Gameclass.CurrentGame.gameType = Gameclass.CurrentGame.whiteGameType;


            SetGamePropertiesPanel.Visible = false;

            ChooseTypeOfGame();
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
            try
            {
                LoadGame loadGame = new LoadGame();
                loadGame.CheckGameRules();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Hra není validní: " + exception.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            if (PiecesNumbers.getNumber["Bílý král"] == pieceNumber)
            {
                CustomGameChooseCombobox.Items.Remove("Bílý král");
            }
            if (PiecesNumbers.getNumber["Spodní shogi král"] == pieceNumber)
            {
                CustomGameChooseCombobox.Items.Remove("Spodní shogi král");
            }
            if (PiecesNumbers.getNumber["Černý král"] == pieceNumber)
            {
                CustomGameChooseCombobox.Items.Remove("Černý král");
            }
            if (PiecesNumbers.getNumber["Vrchní shogi král"] == pieceNumber)
            {
                CustomGameChooseCombobox.Items.Remove("Vrchní shogi král");
            }

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
                baseBoard[x, y] = pieceNumber;
            }
            catch
            {
                return;
            } 

        }

    }
}