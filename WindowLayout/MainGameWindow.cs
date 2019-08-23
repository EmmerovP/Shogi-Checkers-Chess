using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowLayout
{
    public partial class MainGameWindow : Form
    {
        public MainGameWindow()
        {
            InitializeComponent();
        }

        //radši přejmenuj tlačítka 

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
            draw_chess();
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
            //zvýraznit tahy nejdřív a podívat se, zda jsou všechny napsané správně
            PictureBox picture = (PictureBox)sender;
            Color background;
            if (picture.Name[0] == 'B')
                background = Color.Crimson;
            else
                background = Color.DarkBlue;

            int xpic = GetX(picture);
            int ypic = GetY(picture);

            bool musttake = false;

            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
            {
                musttake = Gameclass.CurrentGame.MustTake();
            }


            //???
            if (Board.board[xpic, ypic] != null)
            {
                if ((Board.board[xpic, ypic].isWhite != GameCourse.WhitePlays) && (picBoxes[xpic, ypic].BackColor == Color.Transparent))
                    return;
            }

            //přesun figurky
            if ((selected) && (CurrentMoving.BackColor != Color.Crimson) && (picBoxes[xpic, ypic].BackColor != Color.Transparent))
            {
                label2.Visible = false;

                int x = GetX(CurrentMoving);
                int y = GetY(CurrentMoving);
                Pieces pic = GetPiece(CurrentMoving);

                //vyhazování při dámě

                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
                {
                    if (musttake)
                    {
                        if (Math.Abs(xpic - x) == 2)
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
                        else
                        {
                            DeleteHighlight();
                            CurrentMoving.BackColor = Color.Transparent;
                            selected = false;
                            return;
                        }
                    }
                }


                Board.board[xpic, ypic] = pic;
                Board.board[x, y] = null;
                piecesPictures[x, y] = null;
                if (piecesPictures[xpic, ypic] != null)
                {
                    piecesPictures[xpic, ypic].Dispose();
                }
                piecesPictures[xpic, ypic] = CurrentMoving;

                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.chess)
                {
                    if (Gameclass.CurrentGame.KingCheck())
                    {
                        label2.Text = "Šach!";
                        label2.Visible = true;
                    }
                }

                GameCourse.WhitePlays = !GameCourse.WhitePlays;


                CurrentMoving.BackColor = Color.Transparent;
                selected = false;
                CurrentMoving.Location = picture.Location;
                CurrentMoving.BringToFront();
                DeleteHighlight();

                if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers)
                {
                    if (Gameclass.CurrentGame.CheckersEnd())
                    {
                        label2.Text = "Konec hry.";
                        label2.Visible = true;
                    }
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
                    GameCourse.Generate(GetPiece(picture), true, GetX(picture), GetY(picture));

                    Highlight();
                }
            }             
        }

        //animac
        //mysli na to, že (velikost rozměrová) velikost šachovnice podle počtu políček se bude měnit
        //rozměr šachovnice - neměla by asi být fixní, každý má jinak velký monitor
        public void draw_chess()             //vykreslí na pozadí formuláře šachovnici
        {
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
                        if (piece != 0)
                        {
                            piece--;

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
