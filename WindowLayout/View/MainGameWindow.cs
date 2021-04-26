﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        public static int[,] chessboard;

        public static bool isPlayer;
        public static bool AddBottomShogiPiece = false;
        public static bool AddUpperShogiPiece = false;

        public static bool AddPiece = false;
        public static int AddPieceNumber;

        public static int ShogiPiece;

        public static List<Pieces> shogiPlayerPieces = new List<Pieces>();
        public static List<Pieces> shogiAIPieces = new List<Pieces>();

        public MainGameWindow()
        {
            InitializeComponent();
        }


        private void SelectChessButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
            if (!isCustom)
            {
                chessboard = GameStarts.chess;
            }
            ChooseTypeOfGame();
        }

        private void SelectCheckersButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
            if (!isCustom)
            {
                chessboard = GameStarts.checkers;
            }
            ChooseTypeOfGame();
        }

        private void SelectShogiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
            if (!isCustom)
            {
                chessboard = GameStarts.shogi;
            }
            ChooseTypeOfGame();
        }

        private void SelectCustomGameButton_Click(object sender, EventArgs e)
        {
            isCustom = true;

            CustomGameSizeButton.Visible = true;
            CustomGameSizeLabel.Visible = true;
            CustomGameSizeXLabel.Visible = true;
            CustomGameSizeXTextbox.Visible = true;
            CustomGameSizeYLabel.Visible = true;
            CustomGameSizeYTextbox.Visible = true;

            SelectChessButton.Visible = false;
            SelectCheckersButton.Visible = false;
            SelectShogiButton.Visible = false;
            SelectCustomGameButton.Visible = false;
            LoadGameButton.Visible = false;
            AboutGameButton.Visible = false;
            AboutAuthorButton.Visible = false;
            CreditsButton.Visible = false;
            label1.Visible = false;
        }

        public void ChooseTypeOfGame()
        {
            SelectChessButton.Visible = false;
            SelectCheckersButton.Visible = false;
            SelectShogiButton.Visible = false;
            SelectCustomGameButton.Visible = false;
            LoadGameButton.Visible = false;
            AboutGameButton.Visible = false;
            AboutAuthorButton.Visible = false;
            CreditsButton.Visible = false;
            label1.Visible = false;

            SelectSingleplayerButton.Visible = true;
            SelectLocMultiButton.Visible = true;
        }

        private void AboutGameButton_Click(object sender, EventArgs e)
        {
            AboutGame popup = new AboutGame();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();

        }

        private void AboutAuthorButton_Click(object sender, EventArgs e)
        {
            AboutAuthor popup = new AboutAuthor();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            Credits popup = new Credits();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        public void HidePlayerTypeButtons()
        {
            SelectSingleplayerButton.Visible = false;
            SelectLocMultiButton.Visible = false;
        }

        public void ShowChooseAlgorithmButtons()
        {
            ChooseAlgorithmLabel.Visible = true;
            MinimaxButton.Visible = true;
            MonteCarloButton.Visible = true;
        }

        public void HideChooseAlgorithmButtons()
        {
            ChooseAlgorithmLabel.Visible = false;
            MinimaxButton.Visible = false;
            MonteCarloButton.Visible = false;
        }

        public void CreateChessboard()
        {
            if (isCustom)
            {
                DrawCustomChessboard();
            }
            else
            {
                DrawChessboard();
            }
        }

        private void SelectSingleplayerButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;
            HidePlayerTypeButtons();
            ShowChooseAlgorithmButtons(); 
        }

        private void MinimaxButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.minimax;
            HideChooseAlgorithmButtons();
            CreateChessboard();
        }

        private void MonteCarloButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.montecarlo;
            HideChooseAlgorithmButtons();
            CreateChessboard();
        }

        private void SelectLocMultiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.localmulti;
            HidePlayerTypeButtons();
            if (isCustom)
            {
                DrawCustomChessboard();
            }
            else
            {
                DrawChessboard();
            }
        }

        private void ShowBottomShogiAddon()
        {
            ChooseShogiBoxBottom.Visible = true;
            ChooseShogiButtonBottom.Visible = true;
            ChooseShogiLabelBottom.Visible = true;
        }

        private void ShowUpperShogiAddon()
        {
            ChooseShogiBoxUpper.Visible = true;
            ChooseShogiButtonUpper.Visible = true;
            ChooseShogiLabelUpper.Visible = true;
        }


        //reprezentace figurek bude intem
        //public static List<PictureBox> piecesPictures = new List<PictureBox>();
        public static PictureBox[,] piecesPictures;
        public static Point[,] location;
        public static PictureBox[,] pictureBoxes;

        public static PictureBox CurrentMoving;
        public static bool selected = false;

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

        public void Highlight()
        {
            for (int i = 0; i < Moves.final_x.Count; i++)
            {
                pictureBoxes[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
                if (piecesPictures[Moves.final_x[i], Moves.final_y[i]] != null)
                    piecesPictures[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
            }
        }

        public void DeleteHighlight()
        {
            for (int i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < pictureBoxes.GetLength(1); j++)
                {
                    pictureBoxes[i, j].BackColor = Color.Transparent;
                    if (piecesPictures[i, j] != null)
                        piecesPictures[i, j].BackColor = Color.Transparent;
                }
            }
        }

       
       


        //mysli na to, že (velikost rozměrová) velikost šachovnice podle počtu políček se bude měnit
        //rozměr šachovnice - neměla by asi být fixní, každý má jinak velký monitor
        public void DrawChessboard()             //vykreslí na pozadí formuláře šachovnici
        {
            Gameclass.CurrentGame.GameEnded = false;

            int boxsize = 50;
            int dimension_x = MainGameWindow.chessboard.GetLength(0);
            int dimension_y = MainGameWindow.chessboard.GetLength(1);
            int border = 1;
            location = new Point[dimension_x, dimension_y];
            piecesPictures = new PictureBox[dimension_x, dimension_y];
            pictureBoxes = new PictureBox[dimension_x, dimension_y];
            Board.board = new Pieces[dimension_x, dimension_y];
            Bitmap chessboard = new Bitmap(boxsize * dimension_y + border * boxsize, boxsize * dimension_x + border * boxsize);
            Graphics graphics = Graphics.FromImage(chessboard);
            using (SolidBrush blackBrush = new SolidBrush(Color.DarkGray))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))  //na vykreslení bílých i černých polí

                for (int j = border; j < dimension_y + border; j++)
                {
                    for (int i = border; i < dimension_x + border; i++)
                    {
                        int a = i - border;
                        int b = j - border;

                        location[a, b] = new Point(j * boxsize, i * boxsize);

                        int piece = MainGameWindow.chessboard[a, b];
                        if (piece != -1)
                        {
                            var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
                            {
                                Name = Convert.ToString(piece),
                                Size = new Size(boxsize, boxsize),
                                Location = location[a, b],
                                BackColor = Color.Transparent,
                                Image = GamePieces.Images[piece],
                                SizeMode = PictureBoxSizeMode.CenterImage,
                            };
                            gamepiece.BringToFront();
                            this.Controls.Add(gamepiece);
                            gamepiece.Click += MoveGamePiece;

                            piecesPictures[a, b] = gamepiece;
                            Board.AddPiece(piece, a, b);
                        }



                        var backpicture = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
                        {
                            Name = "Blank" + a + b,
                            Size = new Size(boxsize, boxsize),
                            Location = location[a, b],
                            BackColor = Color.Transparent,
                            SizeMode = PictureBoxSizeMode.CenterImage
                        };
                        pictureBoxes[a, b] = backpicture;
                        this.Controls.Add(backpicture);
                        backpicture.Click += MoveGamePiece;



                        if (((a % 2 == 1) & (b % 2 == 1)) || ((a % 2 == 0) & (b % 2 == 0)))  //vykreslí se bílý čtvereček
                        {
                            graphics.FillRectangle(whiteBrush, j * boxsize, i * boxsize, boxsize, boxsize);
                        }
                        else  //vykreslí se černý čtvereček
                        {
                            graphics.FillRectangle(blackBrush, j * boxsize, i * boxsize, boxsize, boxsize);
                        }
                    }
                }
            BackgroundImage = chessboard;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


    }
}