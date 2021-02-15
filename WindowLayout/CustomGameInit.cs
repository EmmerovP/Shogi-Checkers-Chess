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


//třída pro komponenty potřebné k vytvoření Custom hry
namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        const int MAX_SIZE = 10;
        const int MIN_SIZE = 3;

        public bool isCustom = false;


        private void CustomGameSizeButton_Click(object sender, EventArgs e)
        {
            string x = CustomGameSizeXTextbox.Text;
            string y = CustomGameSizeXTextbox.Text;

            int number_x;

            bool success = Int32.TryParse(x, out number_x);

            if (!success)
            {
                CustomGameSizeErrorLabel.Visible = true;
                CustomGameSizeErrorLabel.Text = "Chyba - nebylo zadáno platné číslo.";
                return;
            }

            if (number_x < MIN_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice x je moc malá, musí být alespoň 3.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            if (number_x > MAX_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice x je moc velká, musí být maximálně 15.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            int number_y;

            success = Int32.TryParse(y, out number_y);


            if (!success)
            {
                CustomGameSizeErrorLabel.Visible = true;
                CustomGameSizeErrorLabel.Text = "Chyba - nebylo zadáno platné číslo.";
                return;
            }

            if (number_y < MIN_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice y je moc malá, musí být alespoň 3.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            if (number_y > MAX_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice y je moc velká, musí být maximálně 15.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            chessboard = new int[number_x, number_y];

            for (int i = 0; i < number_x; i++)
            {
                for (int j = 0; j < number_y; j++)
                {
                    chessboard[i, j] = -1;
                }
            }

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


        private void NewGameButton_Click(object sender, EventArgs e)
        {
            AddPiece = false;
            //Koukni, zda je na šachovnici správná figurka pro danou hru
            //Pro všechny - alespoň jedna figurka příslušné barvy
            bool is_white = false;
            bool is_black = false;

            bool is_whiteking = false;
            bool is_blackking = false;

            bool uppershogiking = false;
            bool bottomshogiking = false;

            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    if (Board.board[i, j] != null)
                    {
                        if (Board.board[i, j].isWhite)
                        {
                            is_white = true;
                        }
                        if (!Board.board[i, j].isWhite)
                        {
                            is_black = true;
                        }
                        if (Board.board[i, j].GetNumber() == 0)
                        {
                            is_whiteking = true;
                        }
                        if (Board.board[i, j].GetNumber() == 21)
                        {
                            is_blackking = true;
                        }
                        if (Board.board[i, j].GetNumber() == 7)
                        {
                            bottomshogiking = true;
                        }
                        if (Board.board[i, j].GetNumber() == 28)
                        {
                            uppershogiking = true;
                        }
                    }

                }
            }

            if (!(is_white && is_black))
            {
                CustomGameChooseErrorLabel.Text = "Na šachovnici musí být figurky obou stran pro zahájení hry.";
                CustomGameChooseErrorLabel.Visible = true;
                return;

            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
            {
                if (!(is_whiteking && is_blackking))
                {
                    CustomGameChooseErrorLabel.Text = "Na šachovnici musí být králové obou stran.";
                    CustomGameChooseErrorLabel.Visible = true;
                    return;
                }
            }

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi)
            {
                if (!(bottomshogiking && uppershogiking))
                {
                    CustomGameChooseErrorLabel.Text = "Na šachovnici musí být králové obou stran.";
                    CustomGameChooseErrorLabel.Visible = true;
                    return;
                }
            }

            Gameclass.CurrentGame.GameEnded = false;

            CustomGameChooseCombobox.Visible = false;
            CustomGameChooseErrorLabel.Visible = false;
            CustomGameChooseLabel.Visible = false;
            NewGameButton.Visible = false;
        }

        private void AddPieceToBoard(int x, int y)
        {

            if (Board.board[x, y] != null)
            {
                return;
            }

            var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
            {
                Name = Convert.ToString(AddPieceNumber),
                Size = new Size(50, 50),
                Location = location[x, y],
                BackColor = Color.Transparent,
                Image = GamePieces.Images[AddPieceNumber],
                SizeMode = PictureBoxSizeMode.CenterImage,
            };

            this.Controls.Add(gamepiece);
            gamepiece.Click += MoveGamePiece;

            piecesPictures[x, y] = gamepiece;
            Board.AddPiece(AddPieceNumber, x, y);

            gamepiece.BringToFront();

            if (AddPieceNumber == 0)
            {
                CustomGameChooseCombobox.Items.Remove("Bílý král");
            }
            if (AddPieceNumber == 7)
            {
                CustomGameChooseCombobox.Items.Remove("Spodní shogi král");
            }
            if (AddPieceNumber == 21)
            {
                CustomGameChooseCombobox.Items.Remove("Černý král");
            }
            if (AddPieceNumber == 28)
            {
                CustomGameChooseCombobox.Items.Remove("Vrchní shogi král");
            }
        }

        private void WhichPiece(int x, int y)
        {
            string piece = CustomGameChooseCombobox.Text;

            switch (piece)
            {
                case "Bílý král":
                    AddPieceNumber = 0;
                    break;
                case "Bílá královna":
                    AddPieceNumber = 1;
                    break;
                case "Bílá věž":
                    AddPieceNumber = 2;
                    break;
                case "Bílý kůň":
                    AddPieceNumber = 3;
                    break;
                case "Bílý střelec":
                    AddPieceNumber = 4;
                    break;
                case "Bílý pěšec":
                    AddPieceNumber = 5;
                    break;
                case "Bílý kámen":
                    AddPieceNumber = 6;
                    break;
                case "Spodní shogi král":
                    AddPieceNumber = 7;
                    break;
                case "Spodní shogi věž":
                    AddPieceNumber = 8;
                    break;
                case "Spodní shogi střelec":
                    AddPieceNumber = 10;
                    break;
                case "Spodní zlatý generál":
                    AddPieceNumber = 12;
                    break;
                case "Spodní stříbrný generál":
                    AddPieceNumber = 13;
                    break;
                case "Spodní shogi kůň":
                    AddPieceNumber = 15;
                    break;
                case "Spodní kopiník":
                    AddPieceNumber = 17;
                    break;
                case "Spodní shogi pěšák":
                    AddPieceNumber = 19;
                    break;
                case "Černý král":
                    AddPieceNumber = 21;
                    break;
                case "Černá královna":
                    AddPieceNumber = 22;
                    break;
                case "Černá věž":
                    AddPieceNumber = 23;
                    break;
                case "Černý kůň":
                    AddPieceNumber = 24;
                    break;
                case "Černý střelec":
                    AddPieceNumber = 25;
                    break;
                case "Černý pěšec":
                    AddPieceNumber = 26;
                    break;
                case "Černý kámen":
                    AddPieceNumber = 27;
                    break;
                case "Vrchní shogi král":
                    AddPieceNumber = 28;
                    break;
                case "Vrchní shogi věž":
                    AddPieceNumber = 29;
                    break;
                case "Vrchní shogi střelec":
                    AddPieceNumber = 31;
                    break;
                case "Vrchní zlatý generál":
                    AddPieceNumber = 33;
                    break;
                case "Vrchní stříbrný generál":
                    AddPieceNumber = 34;
                    break;
                case "Vrchní shogi kůň":
                    AddPieceNumber = 36;
                    break;
                case "Vrchní kopiník":
                    AddPieceNumber = 38;
                    break;
                case "Vrchní shogi pěšák":
                    AddPieceNumber = 40;
                    break;
                default:
                    return;
            }
            AddPieceToBoard(x, y);
        }

    }
}