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

        private void button1_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
            chessboard = GameStarts.chess;
            ShowPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
            chessboard = GameStarts.checkers;
            ShowPlayer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
            chessboard = GameStarts.shogi;
            ShowPlayer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.gameType = Gameclass.GameType.custom;
            ShowPlayer();
        }

        public void ShowPlayer()
        {
            SelectChess.Visible = false;
            SelectCheckers.Visible = false;
            SelectShogi.Visible = false;
            SelectCustomGame.Visible = false;
            AboutGame.Visible = false;
            AboutAuthor.Visible = false;
            Credits.Visible = false;
            label1.Visible = false;

            SelectSingleplayer.Visible = true;
            SelectLocMulti.Visible = true;
            SelectWebMulti.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AboutGame popup = new AboutGame();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AboutAuthor popup = new AboutAuthor();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Credits popup = new Credits();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

        public void TrueVoid()
        {
            SelectSingleplayer.Visible = false;
            SelectLocMulti.Visible = false;
            SelectWebMulti.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.single;
            TrueVoid();
            draw_chess();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.localmulti;
            TrueVoid();
            draw_chess();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Gameclass.CurrentGame.playerType = Gameclass.PlayerType.webmulti;
            TrueVoid();
            label2.Text = "Nepodporovaná možnost.";
            label2.Visible = true;
            //draw_chess();
        }

        //reprezentace figurek bude intem
        //public static List<PictureBox> piecesPictures = new List<PictureBox>();
        public static PictureBox[,] piecesPictures;
        public static Point[,] location;
        public static PictureBox[,] picBoxes;

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
                picBoxes[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
                if (piecesPictures[Moves.final_x[i], Moves.final_y[i]] != null)
                    piecesPictures[Moves.final_x[i], Moves.final_y[i]].BackColor = Color.Yellow;
            }
        }

        public void DeleteHighlight()
        {
            for (int i = 0; i < picBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < picBoxes.GetLength(1); j++)
                {
                    picBoxes[i, j].BackColor = Color.Transparent;
                    if (piecesPictures[i, j] != null)
                        piecesPictures[i, j].BackColor = Color.Transparent;
                }
            }
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
                background = Color.Crimson;
            else
                background = Color.DarkBlue;

            int xpic = GetX(picture);
            int ypic = GetY(picture);

            //klikli jsme někam náhodně, nic se neděje
            if (Board.board[xpic, ypic] != null)
            {
                if ((Board.board[xpic, ypic].isWhite != Generating.WhitePlays) && (picBoxes[xpic, ypic].BackColor == Color.Transparent))
                    return;
            }

            //přesun figurky
            if ((selected) && (CurrentMoving.BackColor != Color.Crimson) && (picBoxes[xpic, ypic].BackColor != Color.Transparent))
            {
                int x = GetX(CurrentMoving);
                int y = GetY(CurrentMoving);
                Pieces pic = GetPiece(CurrentMoving);

                if (Generating.CheckersTake)
                {
                    int xpiece, ypiece;
                    if (xpic > x)
                    {
                        xpiece = x + 1;
                    }
                    else
                    {
                        xpiece = xpic + 1;
                    }

                    if (ypic > y)
                    {
                        ypiece = y + 1;
                    }
                    else
                    {
                        ypiece = ypic + 1;
                    }
                    Board.board[xpiece, ypiece] = null;
                    piecesPictures[xpiece, ypiece].Dispose();
                }

                Board.board[xpic, ypic] = pic;
                Board.board[x, y] = null;

                piecesPictures[x, y] = null;
                if (piecesPictures[xpic, ypic] != null)
                {
                    piecesPictures[xpic, ypic].Dispose();
                }

                //změna figurky
                bool changed = ChangePiece(xpic, ypic, pic);

                piecesPictures[xpic, ypic] = CurrentMoving;

                if (changed)
                    CurrentMoving.Image = GamePieces.Images[Board.board[xpic, ypic].GetNumber()];

                Generating.WhitePlays = !Generating.WhitePlays;

                CurrentMoving.BackColor = Color.Transparent;
                selected = false;
                CurrentMoving.Location = picture.Location;
                CurrentMoving.BringToFront();
                DeleteHighlight();

                //hlídání konců her
                EndGame();


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
                    CurrentMoving.Location = picBoxes[Moves.final_x[move], Moves.final_y[move]].Location;
                    CurrentMoving.BringToFront();
                    Generating.WhitePlays = !Generating.WhitePlays;
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

            //uživatel klikne na políčko s figurkou, kdy není nic vybráno
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

        public void EndGame()
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
                }
            }
            Generating.WhitePlays = !Generating.WhitePlays;
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
        public void draw_chess()             //vykreslí na pozadí formuláře šachovnici
        {
            Gameclass.CurrentGame.GameEnded = false;

            int boxsize = 50;
            int dimension = chessboard.GetLength(0);
            int border = 1;
            location = new Point[dimension, dimension];
            piecesPictures = new PictureBox[dimension, dimension];
            picBoxes = new PictureBox[dimension, dimension];
            Board.board = new Pieces[dimension, dimension];
            Bitmap bm = new Bitmap(boxsize * dimension + border * boxsize, boxsize * dimension + border * boxsize);
            Graphics g = Graphics.FromImage(bm);
            using (SolidBrush blackBrush = new SolidBrush(Color.DarkGray))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))  //na vykreslení bílých i černých polí

                for (int j = border; j < dimension + border; j++)
                {
                    for (int i = border; i < dimension + border; i++)
                    {
                        int a = i - border;
                        int b = j - border;

                        location[a, b] = new Point(j * boxsize, i * boxsize);

                        int piece = chessboard[a, b];
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
                        picBoxes[a, b] = backpicture;
                        this.Controls.Add(backpicture);
                        backpicture.Click += MoveGamePiece;



                        if (((a % 2 == 1) & (b % 2 == 1)) || ((a % 2 == 0) & (b % 2 == 0)))  //vykreslí se bílý čtvereček
                        {
                            g.FillRectangle(whiteBrush, i * boxsize, j * boxsize, boxsize, boxsize);
                        }
                        else  //vykreslí se černý čtvereček
                        {
                            g.FillRectangle(blackBrush, i * boxsize, j * boxsize, boxsize, boxsize);
                        }
                    }
                }
            BackgroundImage = bm;
            BackgroundImageLayout = ImageLayout.None;
        }

    }
}
