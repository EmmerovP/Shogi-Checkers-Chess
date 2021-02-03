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

namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        public MainGameWindow()
        {
            InitializeComponent();
        }

        //radši přejmenuj tlačítka 

        public static Stopwatch watch;

        public static int[,] chessboard;

        private void SelectChessButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
            chessboard = GameStarts.chess;
            ChooseTypeOfGame();
        }

        private void SelectCheckersButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
            chessboard = GameStarts.checkers;
            ChooseTypeOfGame();
        }

        private void SelectShogiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
            chessboard = GameStarts.shogi;
            ChooseTypeOfGame();
        }

        private void SelectCustomGameButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.custom;
            label1.Text = "Zatím není implementováno";
            label1.Visible = true;
        }

        public void ChooseTypeOfGame()
        {
            SelectChessButton.Visible = false;
            SelectCheckersButton.Visible = false;
            SelectShogiButton.Visible = false;
            SelectCustomGameButton.Visible = false;
            AboutGameButton.Visible = false;
            AboutAuthorButton.Visible = false;
            CreditsButton.Visible = false;
            label1.Visible = false;

            SelectSingleplayerButton.Visible = true;
            SelectLocMultiButton.Visible = true;
            SelectWebMultiButton.Visible = true;
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
            SelectWebMultiButton.Visible = false;
        }

        private void SelectSingleplayerButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;
            HidePlayerTypeButtons();
            DrawChessboard();
        }

        private void SelectLocMultiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.localmulti;
            HidePlayerTypeButtons();
            DrawChessboard();
        }

        private void SelectWebMultiButton_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.webmulti;
            HidePlayerTypeButtons();
            label2.Text = "Nepodporovaná možnost.";
            label2.Visible = true;
            //draw_chess();
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

        public bool isCastling(int start_x, int start_y, int final_x, int final_y)
        {
            //je to rošáda
            if (start_x == final_x && start_y== final_y + 2)
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


        //souřadnice z location
        public void MoveGamePiece(object sender, EventArgs e)    //poté, co se klikne na políčko šachovnice, najde se v poli příslušný PictureBox, na který se kliklo
        {
            if (Gameclass.CurrentGame.GameEnded)
                return;

            //zvýraznit tahy nejdřív a podívat se, zda jsou všechny napsané správně
            PictureBox picture = (PictureBox)sender;
            Color background;
            if (picture.Name[0] == 'B')
            {
                background = Color.Crimson;
            }              
            else
            {
                background = Color.DarkBlue;
            }
                
            //dostaneme souřadnice, na které jsme klikli, asi nevím jak to udělat elegantněji než projít celou šachovnici
            int selected_x = GetX(picture);
            int selected_y = GetY(picture);

            //klikli jsme někam náhodně, nic se neděje
            if (Board.board[selected_x, selected_y] != null)
            {
                if ((Board.board[selected_x, selected_y].isWhite != Generating.WhitePlays) && (pictureBoxes[selected_x, selected_y].BackColor == Color.Transparent))
                {
                    return;
                }                    
            }

            //přesun figurky
            if ((selected) && (CurrentMoving.BackColor != Color.Crimson) && (pictureBoxes[selected_x, selected_y].BackColor != Color.Transparent))
            {
                int piecePosition_x = GetX(CurrentMoving);
                int piecePosition_y = GetY(CurrentMoving);
                Pieces piece = GetPiece(CurrentMoving);

                //dáma
                if (Generating.CheckersTake)
                {
                    int xpiece, ypiece;
                    if (selected_x > piecePosition_x)
                    {
                        xpiece = piecePosition_x + 1;
                    }
                    else
                    {
                        xpiece = selected_x + 1;
                    }

                    if (selected_y > piecePosition_y)
                    {
                        ypiece = piecePosition_y + 1;
                    }
                    else
                    {
                        ypiece = selected_y + 1;
                    }
                    Board.board[xpiece, ypiece] = null;
                    piecesPictures[xpiece, ypiece].Dispose();
                }

                Board.board[selected_x, selected_y] = piece;
                Board.board[piecePosition_x, piecePosition_y] = null;

                piecesPictures[piecePosition_x, piecePosition_y] = null;

                //pokud se figurka vyhazuje, musíme její obrázek zrušit
                if (piecesPictures[selected_x, selected_y] != null)
                {
                    piecesPictures[selected_x, selected_y].Dispose();
                }


                piecesPictures[selected_x, selected_y] = CurrentMoving;

                //změna figurky
                if (ChangePiece(selected_x, selected_y, piece))
                    CurrentMoving.Image = GamePieces.Images[Board.board[selected_x, selected_y].GetNumber()];

                Generating.WhitePlays = !Generating.WhitePlays;

                CurrentMoving.BackColor = Color.Transparent;
                selected = false;
                CurrentMoving.Location = picture.Location;
                CurrentMoving.BringToFront();
                DeleteHighlight();

                if (piece.Value == 900)
                {
                    piece.Moved = true;
                    //pokud se král posunul o dvě políčka, jedná se o rošádu
                    isCastling(piecePosition_x, piecePosition_y, selected_x, selected_y);
                }

                //hlídání konců her
                if (EndGame())
                {
                    return;
                }


                //hraje AIčko
                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
                {
                    int move = RandomMoveGen.FindPiece();
                    if (move == -1)
                    {
                        label2.Text = "Vyhráli jste!";
                        return;
                    }
                    CurrentMoving = piecesPictures[Moves.start_x[move], Moves.start_y[move]];
                    piecesPictures[Moves.start_x[move], Moves.start_y[move]] = null;
                    if (Generating.CheckersTake)
                    {
                        int xpiece, ypiece;
                        if (Moves.final_x[move] > Moves.start_x[move])
                        {
                              xpiece = Moves.start_x[move] + 1;
                        }
                        else
                        {
                            xpiece = Moves.final_x[move] + 1;
                        }

                        if (Moves.final_y[move] > Moves.start_y[move])
                        {
                            ypiece = Moves.start_y[move] + 1;
                        }
                        else
                        {
                            ypiece = Moves.final_y[move] + 1;
                        }
                        Board.board[xpiece, ypiece] = null;
                        piecesPictures[xpiece, ypiece].Dispose();
                    }

                    if (piecesPictures[Moves.final_x[move], Moves.final_y[move]] != null)
                    {
                        piecesPictures[Moves.final_x[move], Moves.final_y[move]].Dispose();
                    }

                    piecesPictures[Moves.final_x[move], Moves.final_y[move]] = CurrentMoving;
                    CurrentMoving.Location = pictureBoxes[Moves.final_x[move], Moves.final_y[move]].Location;
                    CurrentMoving.BringToFront();

                    if (Board.board[Moves.final_x[move], Moves.final_y[move]].Value == 900)
                    {
                        //rošáda
                        Board.board[Moves.final_x[move], Moves.final_y[move]].Moved = true;
                        isCastling(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move]);
                    }

                    Generating.WhitePlays = !Generating.WhitePlays;
                    Moves.EmptyCoordinates();

                    EndGame();
                }
            }

            //pokud je nějaké políčko selected, ale vybrané políčko není správný cíl vybrané figurky, stane se toto 
            else if (selected)
            {
                DeleteHighlight();
                CurrentMoving.BackColor = Color.Transparent;
                selected = false;
            }

            //uživatel klikne na políčko s figurkou, když není nic vybráno
            else if (!selected)
            {
                DeleteHighlight();
                picture.BackColor = background;
                CurrentMoving = picture;
                selected = true;
                if (background == Color.DarkBlue)
                {
                    Generating.Generate(GetPiece(picture), true, GetX(picture), GetY(picture));

                    Highlight();
                }
            }
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

        //měnění figurek - logika
        public bool ChangePiece(int x, int y, Pieces piece)
        {

            //bool ChangedPiece = false;
            //upperpawn
            if ((piece.GetNumber() == 26) && (x == Board.board.GetLength(1) - 1))
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

        //animac
        //mysli na to, že (velikost rozměrová) velikost šachovnice podle počtu políček se bude měnit
        //rozměr šachovnice - neměla by asi být fixní, každý má jinak velký monitor
        public void DrawChessboard()             //vykreslí na pozadí formuláře šachovnici
        {
            Gameclass.CurrentGame.GameEnded = false;

            int boxsize = 50;
            int dimension = MainGameWindow.chessboard.GetLength(0);
            int border = 1;
            location = new Point[dimension, dimension];
            piecesPictures = new PictureBox[dimension, dimension];
            pictureBoxes = new PictureBox[dimension, dimension];
            Board.board = new Pieces[dimension, dimension];
            Bitmap chessboard = new Bitmap(boxsize * dimension + border * boxsize, boxsize * dimension + border * boxsize);
            Graphics graphics = Graphics.FromImage(chessboard);
            using (SolidBrush blackBrush = new SolidBrush(Color.DarkGray))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))  //na vykreslení bílých i černých polí

                for (int j = border; j < dimension + border; j++)
                {
                    for (int i = border; i < dimension + border; i++)
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

                            //aby se po kliknutí na picturebox zavolala příslušná metoda
                            //PictureBoxArray[j, i] = picture;
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
                            graphics.FillRectangle(whiteBrush, i * boxsize, j * boxsize, boxsize, boxsize);
                        }
                        else  //vykreslí se černý čtvereček
                        {
                            graphics.FillRectangle(blackBrush, i * boxsize, j * boxsize, boxsize, boxsize);
                        }
                    }
                }
            BackgroundImage = chessboard;
            BackgroundImageLayout = ImageLayout.None;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            MainGameWindow NewWindow = new MainGameWindow();
            NewWindow.Show(this);
        }
    }
}
