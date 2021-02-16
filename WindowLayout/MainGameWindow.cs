using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void SelectSingleplayerButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;
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

        public bool IsCastling(int start_x, int start_y, int final_x, int final_y)
        {
            if (!(Board.board.GetLength(0) == 8 && Board.board.GetLength(1) == 8))
            {
                return false;
            }
            //je to rošáda
            if (start_x == final_x && start_y == final_y + 2)
            {
                //je to rošáda nahoře
                if (start_x == 0)
                {
                    Board.board[0, 3] = Board.board[0, 0];
                    Board.board[0, 0] = null;


                    PictureBox rook = piecesPictures[0, 0];
                    piecesPictures[0, 0] = null;
                    piecesPictures[0, 3] = rook;
                    rook.Location = location[0, 3];
                    rook.BringToFront();


                    return true;
                }
                //je to rošáda dole
                if (start_x == 7)
                {
                    Board.board[7, 3] = Board.board[7, 0];
                    Board.board[7, 0] = null;


                    PictureBox rook = piecesPictures[7, 0];
                    piecesPictures[7, 0] = null;
                    piecesPictures[7, 3] = rook;
                    rook.Location = location[7, 3];
                    rook.BringToFront();


                    return true;
                }
            }
            if (start_x == final_x && start_y == final_y - 2)
            {
                //je to rošáda nahoře
                if (start_x == 0)
                {
                    Board.board[0, 5] = Board.board[0, 7];
                    Board.board[0, 7] = null;


                    PictureBox rook = piecesPictures[0, 7];
                    piecesPictures[0, 7] = null;
                    piecesPictures[0, 5] = rook;
                    rook.Location = location[0, 5];
                    rook.BringToFront();


                    return true;
                }
                //je to rošáda dole
                if (start_x == 7)
                {
                    Board.board[7, 5] = Board.board[7, 7];
                    Board.board[7, 7] = null;


                    PictureBox rook = piecesPictures[7, 7];
                    piecesPictures[7, 7] = null;
                    piecesPictures[7, 5] = rook;
                    rook.Location = location[7, 5];
                    rook.BringToFront();


                    return true;
                }
            }
            return false;
        }


        public bool EndGame()
        {
            label2.Visible = false;
            //konec hry dáma
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
            {
                if (Gameclass.CurrentGame.CheckersEnd())
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
                if (Gameclass.CurrentGame.KingOut())
                {
                    label2.Text = "Konec hry.";
                    label2.Visible = true;
                    Gameclass.CurrentGame.GameEnded = true;
                    return true;
                }
            }

            //tady by se mělo zkontrolovat, zda se neudělá šach TÍMTO tahem?
            Generating.WhitePlays = !Generating.WhitePlays;
            if ((Gameclass.CurrentGame.gameType == Gameclass.GameType.chess) && (Gameclass.CurrentGame.KingCheck()))
            {
                label2.Text = "Šach!";
                label2.Visible = true;
                if (Gameclass.CurrentGame.CheckMate())
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
                        Generating.Generate(Board.board[i, j], false, i, j);
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

            Moves.EmptyCoordinates();
            return false;
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

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LoadCustomGameDialog.ShowDialog();

            if (result == DialogResult.OK) 
            {
                string file = LoadCustomGameDialog.FileName;
                try
                {
                    using (var streamReader = new StreamReader(File.OpenRead(file), Encoding.UTF8, true))
                    {
                        String line;

                        line = streamReader.ReadLine();

                        switch (line)
                        {
                            case "chess": 
                                Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
                                break;
                            case "checkers":
                                Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
                                break;
                            case "shogi":
                                Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
                                break;
                            default:
                                throw new Exception();
                        }

                        line = streamReader.ReadLine();

                        string[] dimensions = line.Split(',');

                        int[,] board = new int[Int32.Parse(dimensions[0]), Int32.Parse(dimensions[1])];

                        int cnt = 0;

                        Pieces.DefinedPieces = new List<DefinedPiece>();

                        while ((line = streamReader.ReadLine()) != "")
                        //jedná se o definici custom figurek
                        {                            
                            DefinedPiece newPiece = new DefinedPiece();

                            string[] moves = streamReader.ReadLine().Split(',');

                            newPiece.moves = new int[moves.Length];

                            for (int i = 0; i < moves.Length; i++)
                            {
                                newPiece.moves[i] = Int32.Parse(moves[i]);
                            }

                            if (streamReader.ReadLine() == "white")
                            {
                                newPiece.isWhite = true;
                            }

                            newPiece.Value = moves.Length * 3;
                            string image = streamReader.ReadLine();
                            GamePieces.Images.Add(Image.FromFile(image));

                            Pieces.DefinedPieces.Add(newPiece);
                        }


                        while ((line = streamReader.ReadLine()) != null)
                        {
                            dimensions = line.Split(',');

                            for (int i = 0; i < board.GetLength(0); i++)
                            {
                                board[cnt, i] = Int32.Parse(dimensions[i]);
                            }

                            cnt++;
                        }

                        MainGameWindow.chessboard = board;

                    }
                }
                catch (IOException)
                {
                }

                ChooseTypeOfGame();

            }



        }
    }
}
