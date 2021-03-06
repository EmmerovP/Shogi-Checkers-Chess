﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GeneralBoardGames
{
    public partial class MainGameWindow : Form
    {
        /// <summary>
        /// Path to file describing starting file for playing chess.
        /// </summary>
        const string CHESS = "Boards\\chess.json";

        /// <summary>
        /// Path to file describing starting file for playing shogi.
        /// </summary>
        const string SHOGI = "Boards\\shogi.json";

        /// <summary>
        /// Path to file describing starting file for playing checkers.
        /// </summary>
        const string CHECKERS = "Boards\\checkers.json";

        /// <summary>
        /// Path to file describing starting file for playing horde chess - horde on white side.
        /// </summary>
        const string WHITEHORDE = "Boards\\whitehorde.json";

        /// <summary>
        /// Path to file describing starting file for playing horde chess - horde on black side.
        /// </summary>
        const string BLACKHORDE = "Boards\\blackhorde.json";

        /// <summary>
        /// Path to file describing starting file for playing crazyhouse.
        /// </summary>
        const string CRAZYHOUSE = "Boards\\crazyhouse.json";

        /// <summary>
        /// Path to file describing starting file for playing almost chess.
        /// </summary>
        const string ALMOSTCHESS = "Boards\\almostchess.json";

        /// <summary>
        /// Path to file describing starting file for playing minishogi.
        /// </summary>
        const string MINISHOGI = "Boards\\minishogi.json";

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
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, CHESS));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting horde chess with white horde as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectWhiteHordeChessButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, WHITEHORDE));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting horde chess with black horde as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectBlackHordeChessButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, BLACKHORDE));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting crazyhouse as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCrazyhouseButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, CRAZYHOUSE));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting 960chess as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectChess960Button_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, CHESS));
            Randomize960Chess();
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting really bad chess as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectReallyBadChessButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, CHESS));
            RandomizeChess();
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Randomizes board for 960chess.
        /// </summary>
        private void Randomize960Chess()
        {
            //copy pieces into a new array
            int[] pieces = new int[baseBoard.GetLength(0)];

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = baseBoard[0, i];
            }

            //while we haven't found a correct set of 960 chess
            bool isCorrect = false;

            while (!isCorrect)
            {
                int n = pieces.Length;
                Random rng = new Random();

                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    int value = pieces[k];
                    pieces[k] = pieces[n];
                    pieces[n] = value;
                }

                //check if bishops, king and rooks are in good positions
                bool whiteBishop = false;
                bool blackBishop = false;

                bool firstRook = false;
                bool isKing = false;
                bool secondRook = false;

                for (int i = 0; i < pieces.Length; i++)
                {
                    if (pieces[i] == PiecesNumbers.getNumber["Černý střelec"])
                    {
                        if (i % 2 == 0)
                        {
                            blackBishop = true;
                        }
                        else
                        {
                            whiteBishop = true;
                        }
                    }

                    if (pieces[i] == PiecesNumbers.getNumber["Černá věž"])
                    {
                        if ((!firstRook) && (!isKing) && (!secondRook))
                        {
                            firstRook = true;
                        }

                        if ((firstRook) && (isKing) && (!secondRook))
                        {
                            secondRook = true;
                        }

                    }

                    if (pieces[i] == PiecesNumbers.getNumber["Černý král"])
                    {
                        if ((firstRook) && (!isKing) && (!secondRook))
                        {
                            isKing = true;
                        }
                    }
                }

                if (whiteBishop && blackBishop && firstRook && secondRook && isKing)
                {
                    isCorrect = true;
                }
            }


            //copy pieces to other side
            for (int i = 0; i < pieces.Length; i++)
            {
                baseBoard[0, i] = pieces[i];

                baseBoard[baseBoard.GetLength(0) - 1, i] = pieces[i] - PiecesNumbers.getUpperNumber.Count;
            }

        }

        /// <summary>
        /// Randomize board for really bad chess.
        /// </summary>
        private void RandomizeChess()
        {
            Random rnd = new Random();

            //put random pieces on first two rows on both sides
            for (int i = 0; i < baseBoard.GetLength(1); i++)
            {
                baseBoard[baseBoard.GetLength(0) - 2, i] = rnd.Next(PiecesNumbers.getNumber["Bílá královna"], PiecesNumbers.getNumber["Bílý kámen"]);
                baseBoard[baseBoard.GetLength(0) - 1, i] = rnd.Next(PiecesNumbers.getNumber["Bílá královna"], PiecesNumbers.getNumber["Bílý kámen"]);

                baseBoard[0, i] = rnd.Next(PiecesNumbers.getNumber["Černá královna"], PiecesNumbers.getNumber["Černý kámen"]);
                baseBoard[1, i] = rnd.Next(PiecesNumbers.getNumber["Černá královna"], PiecesNumbers.getNumber["Černý kámen"]);
            }

            //set fixed places for king
            baseBoard[7, 4] = PiecesNumbers.getNumber["Bílý král"];
            baseBoard[0, 4] = PiecesNumbers.getNumber["Černý král"];
        }

        /// <summary>
        /// Method for selecting almost chess as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAlmostChessButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, ALMOSTCHESS));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting checkers as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCheckersButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, CHECKERS));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting shogi as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectShogiButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, SHOGI));
            ChooseTypeOfGame();
        }

        /// <summary>
        /// Method for selecting minishogi as a type of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectMinishogiButton_Click(object sender, EventArgs e)
        {
            LoadGame(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, MINISHOGI));
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
            HeightTextBox.Visible = true;
            CustomGameSizeYLabel.Visible = true;
            WidthTextBox.Visible = true;

            NewGameInstanceButton.Visible = true;

            HideGameButtons();
        }

        /// <summary>
        /// Hides buttons for choosing games.
        /// </summary>
        public void HideGameButtons()
        {
            SelectChessButton.Visible = false;
            SelectCheckersButton.Visible = false;
            SelectShogiButton.Visible = false;
            SelectAlmostChessButton.Visible = false;
            SelectChess960Button.Visible = false;
            SelectCrazyhouseButton.Visible = false;
            SelectWhiteHordeChessButton.Visible = false;
            SelectBlackHordeChessButton.Visible = false;
            SelectReallyBadChessButton.Visible = false;
            SelectMinishogiButton.Visible = false;

            SelectCustomGameButton.Visible = false;
            LoadGameButton.Visible = false;
            AboutGameButton.Visible = false;
            AboutGamesButton.Visible = false;
        }

        /// <summary>
        /// Method for hiding buttons which select types of games and showing buttons for selection of singleplayer/multiplayer mode
        /// </summary>
        public void ChooseTypeOfGame()
        {
            HideGameButtons();

            NewGameInstanceButton.Visible = true;
            PlayerTypePanel.Visible = true;
            OKbutton.Visible = true;
        }

        /// <summary>
        /// Shows a popup window with informations about a game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutGameButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tento program vznikl v rámci bakalářské práce. Cílem bylo vytvořit software, díky kterému by bylo možné hrát různé hry na šachovnici proti umělé inteligenci be nutnosti kompilace programu.", "O programu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a popup window with informations about games.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutGamesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("V programu jsou již připravené následující hry:\r\n" +
                "\r\n" +
                "Šachy: Desková hra známá po celém světě.\r\n" +
                "\r\n" +
                "Horde šachy: Varianta šachů, kdy na jedné straně stojí šachové figurky v běžném rozestavení a proti nim stojí zástup pěšců. Hra končí buď matem krále, či nemožnosti tahu na straně pěšců.\r\n" +
                "\r\n" +
                "Chess960: Také známé jako Fisherovy šachy. Varianta, kdy jsou figurky na prvním řádku šachovnice náhodně rozestaveny, a oponent toto rozložení zrcadlově kopíruje.\r\n" +
                "\r\n" +
                "Crazyhouse: Varianta šachů, kde se vyhozené figury můžou vrátit zpět do hry.\r\n" +
                "\r\n" +
                "Skorošachy: V angličtině známé jako Almost chess. Šachy, kde je místo královen nová figurka kancléře. Tato figurka se může pohybovat jako kůň a věž.\r\n" +
                "\r\n" +
                "Fakt špatné šachy: Tato hra, v angličtině pod názvem Really bad chess, se hraje stejně jako šachy, ale první řada šachovnice obsahuje až na krále náhodné figurky. Druhá řada pak toto rozestavení zrcadlově kopíruje.\r\n" +
                "\r\n" +
                "Česká dáma: Známá desková hra. V české variantě smí pěšci sebrat pouze figurku před sebou.\r\n" +
                "\r\n" +
                "Šogi: Japonská varianta šachů s několika změnami. Mimo jiných figurek se v této hře vrací vyhozené figurky zpátky na šachovnici a mění se jejich pohyb, pokud vstoupí do zóny povýšení. Dále se také nemusí oznamovat napadení krále. Jeho figurka se může sebrat.\r\n" +
                "\r\n" +
                "Minišogi: Šogi na menší šachovnici s méně figurkami.\r\n" +
                "\r\n" +
                "V případě zvolení tlačítka \"Vlastní hra\" si můžete pomocí GUI vytvořit vlastní hru, popřípadě ji po stisku tlačítka \"Načíst hru\" nahrát ze souboru. Požadovaný formát souboru je popsán v dokumentaci.", "O hrách", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Hides buttons for choosing singleplayer or multiplayer mode.
        /// </summary>
        public void HidePlayerTypeButtons()
        {
            AlgorithmTypePanel.Visible = false;
            PlayerTypePanel.Visible = false;
        }

        /// <summary>
        /// Sets type of game (singleplayer/multiplayer), in case of single player algorithms and its parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKbutton_Click(object sender, EventArgs e)
        {
            //hide panels with multiplayer/singleplayer choice
            HidePlayerTypeButtons();

            //multiplayer was selected
            if (MultiplayerRadioButton.Checked)
            {
                Gameclass.CurrentGame.playerType = Gameclass.PlayerType.localmulti;
            }
            else
            {
                //singleplayer was selected
                Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;

                if (MinimaxRadioButton.Checked)
                {
                    Minimax.treeSearchDepth = Convert.ToInt32(DepthUpDown.Value);

                    //check constraints
                    if (Minimax.treeSearchDepth > 5)
                    {
                        MessageBox.Show("Hloubka prohledávacího stromu minimaxu je příliš velká, hodnoty větší než 5 nejsou vhodné pro hraní.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (AlphabetaCheckBox.Checked)
                    {
                        Minimax.useAlphaBetaPruning = true;
                    }

                    Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.minimax;
                }
                else
                {
                    MonteCarlo.maxTime = (float)MCTSTimeUpDown.Value * 1000;


                    if (MonteCarlo.maxTime > 60000)
                    {
                        MessageBox.Show("Čas u MCTS nesmí být více než 60 sekund.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Gameclass.CurrentGame.algorithmType = Gameclass.AlgorithmType.montecarlo;
                }

            }

            //draw board
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
            ChooseShogiBottomBox.Visible = true;
            ChooseShogiBottomButton.Visible = true;
            ChooseShogiBottomLabel.Visible = true;
        }

        /// <summary>
        /// Shows upper interface for adding a piece during shogi game.
        /// </summary>
        private void ShowUpperShogiAddon()
        {
            ChooseShogiBoxUpper.Visible = true;
            ChooseShogiUpperButton.Visible = true;
            ChooseShogiUpperLabel.Visible = true;
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
            piecesPictures = new PictureBox[dimension_x, dimension_y];

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

            LoadGame ld = new LoadGame();
            try
            {
                if (!isCustom)
                {
                    ld.CheckGameRules();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hra není validní: " + exception.Message + " Zřejmě nepůjde hrát korektně, zvažte nahrání nové hry!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            BackgroundImage = chessboard;
            BackgroundImageLayout = ImageLayout.None;

            if (isCustom)
            {
                this.Width = (dimension_y * boxsize) + 2 * boxsize + boxsize / 2 + 120;
                this.Height = (dimension_x * boxsize) + 2 * boxsize;

                CustomGameChooseLabel.Location = new Point(this.Width - 160, CustomGameChooseLabel.Location.Y);
                CustomGameChooseCombobox.Location = new Point(this.Width - 160, CustomGameChooseCombobox.Location.Y);
                CustomGameChooseErrorLabel.Location = new Point(this.Width - 160, CustomGameChooseErrorLabel.Location.Y);

                NewGameButton.Location = new Point(this.Width - 160, NewGameButton.Location.Y);

                if (Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi)
                {
                    if (this.Height < 370)
                    {
                        this.Height = 370;
                    }
                }

                if (Gameclass.CurrentGame.blackPlayType == Gameclass.GameType.shogi || Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi)
                {
                    ChooseShogiUpperLabel.Location = new Point(this.Width - 160, ChooseShogiUpperLabel.Location.Y);
                    ChooseShogiBoxUpper.Location = new Point(this.Width - 160, ChooseShogiBoxUpper.Location.Y);
                    ChooseShogiUpperButton.Location = new Point(this.Width - 160, ChooseShogiUpperButton.Location.Y);
                    PutShogiPieceUpperLabel.Location = new Point(this.Width - 160, PutShogiPieceUpperLabel.Location.Y);

                    ChooseShogiBottomLabel.Location = new Point(this.Width - 160, ChooseShogiBottomLabel.Location.Y);
                    ChooseShogiBottomBox.Location = new Point(this.Width - 160, ChooseShogiBottomBox.Location.Y);
                    ChooseShogiBottomButton.Location = new Point(this.Width - 160, ChooseShogiBottomButton.Location.Y);
                    PutShogiPieceBottomLabel.Location = new Point(this.Width - 160, PutShogiPieceBottomLabel.Location.Y);

                }
            }

            else if (Gameclass.CurrentGame.blackPlayType == Gameclass.GameType.shogi || Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi)
            {
                this.Width = (dimension_y * boxsize) + 2 * boxsize + boxsize / 2 + 120;
                this.Height = (dimension_x * boxsize) + 2 * boxsize;

                if (this.Height < 370 && Gameclass.CurrentGame.whitePlayType == Gameclass.GameType.shogi)
                {
                    this.Height = 370;
                }

                ChooseShogiUpperLabel.Location = new Point(this.Width - 160, ChooseShogiUpperLabel.Location.Y);
                ChooseShogiBoxUpper.Location = new Point(this.Width - 160, ChooseShogiBoxUpper.Location.Y);
                ChooseShogiUpperButton.Location = new Point(this.Width - 160, ChooseShogiUpperButton.Location.Y);
                PutShogiPieceUpperLabel.Location = new Point(this.Width - 160, PutShogiPieceUpperLabel.Location.Y);

                ChooseShogiBottomLabel.Location = new Point(this.Width - 160, ChooseShogiBottomLabel.Location.Y);
                ChooseShogiBottomBox.Location = new Point(this.Width - 160, ChooseShogiBottomBox.Location.Y);
                ChooseShogiBottomButton.Location = new Point(this.Width - 160, ChooseShogiBottomButton.Location.Y);
                PutShogiPieceBottomLabel.Location = new Point(this.Width - 160, PutShogiPieceBottomLabel.Location.Y);

            }
            else
            {
                this.Width = (dimension_y * boxsize) + 2 * boxsize + boxsize / 2;
                this.Height = (dimension_x * boxsize) + 2 * boxsize + boxsize;
            }

            NewGameInstanceButton.Location = new Point(10, 10);
            GameStateLabel.Location = new Point(NewGameInstanceButton.Location.X + NewGameButton.Size.Width + 20, 20);


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

        /// <summary>
        /// In case minimax is checked, hide MCTS parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimaxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MinimaxRadioButton.Checked)
            {
                DepthLabel.Visible = true;
                DepthUpDown.Visible = true;
                AlphabetaCheckBox.Visible = true;

                MCTSTimeLabel.Visible = false;
                MCTSTimeUpDown.Visible = false;
            }
        }

        /// <summary>
        /// In case MCTS is checked, hide minimax parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCTSRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MCTSRadioButton.Checked)
            {
                DepthLabel.Visible = false;
                DepthUpDown.Visible = false;
                AlphabetaCheckBox.Visible = false;

                MCTSTimeLabel.Visible = true;
                MCTSTimeUpDown.Visible = true;
            }
        }

        /// <summary>
        /// In case singleplayer is checked, hide multiplayer parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SingleplayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SingleplayerRadioButton.Checked)
            {
                AlgorithmTypePanel.Visible = true;
            }
        }

        /// <summary>
        /// In case multiplayer is checked, hide singleplayer parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiplayerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MultiplayerRadioButton.Checked)
            {
                AlgorithmTypePanel.Visible = false;
            }
        }

    }
}
