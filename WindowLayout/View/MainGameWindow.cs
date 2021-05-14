﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// Current gameboard represented by integer numbers. Used only for loading game, actual game is played on board.
        /// </summary>
        public static int[,] baseBoard;


        /// <summary>
        /// True when human player plays, false when algorithm plays.
        /// </summary>
        public static bool isPlayer;

        /// <summary>
        /// Array of pictures of pieces.
        /// </summary>
        public static PictureBox[,] piecesPictures;

        /// <summary>
        /// Locations of pictureboxes.
        /// </summary>
        public static Point[,] location;

        /// <summary>
        /// Board represented by pictureBoxes.
        /// </summary>
        public static PictureBox[,] pictureBoxes;


        /// <summary>
        /// Holds piece which we want to add to board
        /// </summary>
        public static int pieceBeingAddedToBoard;

        /// <summary>
        /// List of all pieces player or upper player has taken.
        /// </summary>
        public static List<Pieces> shogiAIPieces = new List<Pieces>();

        /// <summary>
        /// In case of two computer algorithms playing against each other, we use second array of pieces
        /// </summary>
        public static List<Pieces> whiteShogiAIPieces = new List<Pieces>();

        public MainGameWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method for selecting chess as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectChessButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
            if (!isCustom)
            {
                baseBoard = GameStarts.chess;
            }
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting checkers as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCheckersButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
            if (!isCustom)
            {
                baseBoard = GameStarts.checkers;
            }
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting shogi as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectShogiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
            if (!isCustom)
            {
                baseBoard = GameStarts.shogi;
            }
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting custom game, in which user selects parameters themselves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            WelcomeTextLabel.Visible = false;
        }

        /// <summary>
        /// Method for hiding buttons which select types of games and showing buttons for selection of singleplayer/multiplayer mode
        /// </summary>
        public void ChooseTypeOfGame()
        {
            SelectChessButton.Visible = false;
            SelectCheckersButton.Visible = false;
            SelectShogiButton.Visible = false;
            SelectCustomGameButton.Visible = false;
            LoadGameButton.Visible = false;
            AboutGameButton.Visible = false;
            WelcomeTextLabel.Visible = false;

            SelectSingleplayerButton.Visible = true;
            SelectLocMultiButton.Visible = true;
        }

        /// <summary>
        /// Shows a popup window with informations about a game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Hides buttons for choosing singleplayer or multiplayer mode.
        /// </summary>
        public void HidePlayerTypeButtons()
        {
            SelectSingleplayerButton.Visible = false;
            SelectLocMultiButton.Visible = false;
        }

        /// <summary>
        /// Show buttons for choosing algorithm.
        /// </summary>
        public void ShowChooseAlgorithmButtons()
        {
            ChooseAlgorithmLabel.Visible = true;
            MinimaxButton.Visible = true;
            MonteCarloButton.Visible = true;
        }

        /// <summary>
        /// Hides labels for choosing algorithms.   
        /// </summary>
        public void HideChooseAlgorithmButtons()
        {
            ChooseAlgorithmLabel.Visible = false;
            MinimaxButton.Visible = false;
            MonteCarloButton.Visible = false;
        }

        /// <summary>
        /// Chooses which chessboard we want to draw, and calls according function.
        /// </summary>
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

        /// <summary>
        /// Selects singleplayer mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSingleplayerButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;
            HidePlayerTypeButtons();
            ShowChooseAlgorithmButtons();
        }

        /// <summary>
        /// Selects minimax algorithm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimaxButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.minimax;
            HideChooseAlgorithmButtons();
            CreateChessboard();
        }

        /// <summary>
        /// Selects montecarlo algorithm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonteCarloButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.montecarlo;
            HideChooseAlgorithmButtons();
            CreateChessboard();
        }

        /// <summary>
        /// Selects multiplayer mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows bottom interface for adding a piece during shogi game.
        /// </summary>
        private void ShowBottomShogiAddon()
        {
            ChooseShogiBoxBottom.Visible = true;
            ChooseShogiButtonBottom.Visible = true;
            ChooseShogiLabelBottom.Visible = true;
        }

        /// <summary>
        /// Shows upper interface for adding a piece during shogi game.
        /// </summary>
        private void ShowUpperShogiAddon()
        {
            ChooseShogiBoxUpper.Visible = true;
            ChooseShogiButtonUpper.Visible = true;
            ChooseShogiLabelUpper.Visible = true;
        }

        




        /// <summary>
        /// Draws a chessboard on a screen
        /// </summary>
        public void DrawChessboard()
        {
            //make the game playable
            Gameclass.CurrentGame.GameEnded = false;

            //size of one field - can be changed
            int boxsize = 50;

            //how big the board is
            int dimension_x = baseBoard.GetLength(0);
            int dimension_y = baseBoard.GetLength(1);

            //how far should the board be from the edges
            int border = 1;

            //ćreate new array for locations of the pictureboxes
            location = new Point[dimension_x, dimension_y];

            //create new array for pictures of pieces
            pictureBoxes = new PictureBox[dimension_x, dimension_y];

            //create new array of pictureboxes of blank fields
            pictureBoxes = new PictureBox[dimension_x, dimension_y];

            //creates a board for model representation of pieces
            Board.board = new Pieces[dimension_x, dimension_y];

            //create bitmap in the size of the chessboard
            Bitmap chessboard = new Bitmap(boxsize * dimension_y + border * boxsize, boxsize * dimension_x + border * boxsize);
            Graphics graphics = Graphics.FromImage(chessboard);
            using (SolidBrush blackBrush = new SolidBrush(Color.DarkGray))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))

                for (int j = border; j < dimension_y + border; j++)
                {
                    for (int i = border; i < dimension_x + border; i++)
                    {
                        int a = i - border;
                        int b = j - border;

                        location[a, b] = new Point(j * boxsize, i * boxsize);

                        int piece = baseBoard[a, b];

                        //create pieces
                        if (piece != -1)
                        {
                            AddPieceToBoard(a, b, piece);
                        }

                        //create blank fields
                        var backpicture = new PictureBox                
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

        /// <summary>
        /// Adds piece on board to selected location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void AddPieceToBoard(int x, int y, int pieceNumber)
        {
            var gamepiece = new PictureBox
            {
                Name = Convert.ToString(pieceNumber),
                Size = new Size(50, 50),
                Location = location[x, y],
                BackColor = Color.Transparent,
                Image = GamePieces.Images[pieceNumber],
                SizeMode = PictureBoxSizeMode.CenterImage,
            };

            this.Controls.Add(gamepiece);
            gamepiece.Click += MoveGamePiece;
            piecesPictures[x, y] = gamepiece;

            Board.AddPiece(pieceNumber, x, y, Board.board);

            gamepiece.BringToFront();

            //show the piece instantly on board
            gamepiece.Refresh();
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameInstanceButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
