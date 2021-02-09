﻿using System;
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

        public static Stopwatch watch;

        const int MAX_SIZE = 15;
        const int MIN_SIZE = 3;

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

        public static bool isPlayer;
        public static bool AddBottomShogiPiece = false;
        public static bool AddUpperShogiPiece = false;

        public static bool AddPiece = false;
        public static int AddPieceNumber;

        public static int ShogiPiece;

        public static List<Pieces> shogiPlayerPieces = new List<Pieces>();
        public static List<Pieces> shogiAIPieces = new List<Pieces>();


        //souřadnice z location
        public void MoveGamePiece(object sender, EventArgs e)    //poté, co se klikne na políčko šachovnice, najde se v poli příslušný PictureBox, na který se kliklo
        {
            




            //zvýraznit tahy nejdřív a podívat se, zda jsou všechny napsané správně
            PictureBox picture = (PictureBox)sender;

            //dostaneme souřadnice, na které jsme klikli, asi nevím jak to udělat elegantněji než projít celou šachovnici
            int selected_x = GetX(picture);
            int selected_y = GetY(picture);


            if(AddPiece)
            {
                AddPieceToBoard(selected_x, selected_y);
                return;
            }

            if (Gameclass.CurrentGame.GameEnded)
                return;

            if (AddBottomShogiPiece)
            {
                PutShogiPieceLabelBottom.Visible = false;
                AddBottomShogiPiece = false;
                if (Board.board[selected_x, selected_y] != null)
                {
                    return;
                }

                var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
                {
                    Name = Convert.ToString(ShogiPiece),
                    Size = new Size(50, 50),
                    Location = location[selected_x, selected_y],
                    BackColor = Color.Transparent,
                    Image = GamePieces.Images[ShogiPiece],
                    SizeMode = PictureBoxSizeMode.CenterImage,
                };
                
                this.Controls.Add(gamepiece);
                gamepiece.Click += MoveGamePiece;

                piecesPictures[selected_x, selected_y] = gamepiece;
                Board.AddPiece(ShogiPiece, selected_x, selected_y);

                gamepiece.BringToFront();

                Generating.WhitePlays = !Generating.WhitePlays;


                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
                {
                    
                    isPlayer = false;
                    int move = RandomMoveGen.FindPiece();

                    if (move == -1)
                    {
                        label2.Text = "Vyhráli jste!";
                        return;
                    }

                    PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                        piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                    isPlayer = true;

                }

                return;
            }


            if (AddUpperShogiPiece)
            {
                PutShogiPieceLabelUpper.Visible = false;
                AddUpperShogiPiece = false;
                if (Board.board[selected_x, selected_y] != null)
                {
                    return;
                }

                var gamepiece = new PictureBox                 //za běhu vytvoří příslušné pictureboxy
                {
                    Name = Convert.ToString(ShogiPiece),
                    Size = new Size(50, 50),
                    Location = location[selected_x, selected_y],
                    BackColor = Color.Transparent,
                    Image = GamePieces.Images[ShogiPiece],
                    SizeMode = PictureBoxSizeMode.CenterImage,
                };

                this.Controls.Add(gamepiece);
                gamepiece.Click += MoveGamePiece;

                piecesPictures[selected_x, selected_y] = gamepiece;
                Board.AddPiece(ShogiPiece, selected_x, selected_y);

                gamepiece.BringToFront();

                Generating.WhitePlays = !Generating.WhitePlays;


                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
                {
                    
                    isPlayer = false;
                    int move = RandomMoveGen.FindPiece();

                    if (move == -1)
                    {
                        label2.Text = "Vyhráli jste!";
                        return;
                    }

                    PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                        piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                    isPlayer = true;

                }

                return;
            }


            Color background;
            if (picture.Name[0] == 'B')
            {
                background = Color.Crimson;
            }              
            else
            {
                background = Color.DarkBlue;
            }
               

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
                isPlayer = true;
                int piecePosition_x = GetX(CurrentMoving);
                int piecePosition_y = GetY(CurrentMoving);

                if (PieceMovement(piecePosition_x, piecePosition_y, selected_x, selected_y, CurrentMoving))
                {
                    return;
                }


                //hraje AIčko
                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
                {
                    isPlayer = false;
                    int move = RandomMoveGen.FindPiece();

                    if (move == -1)
                    {
                        label2.Text = "Vyhráli jste!";
                        return;
                    }

                    PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                        piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                    isPlayer = true;
                   
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

        public bool PieceMovement(int start_x, int start_y, int final_x, int final_y, PictureBox movingPicture)
        {
            Pieces piece = Board.board[start_x, start_y];
           //dáma
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.checkers && Board.board[start_x, start_y].Value == 10 &&
                    (start_x == final_x - 2 || start_x == final_x + 2))
            {
                int xpiece, ypiece;
                if (final_x > start_x)
                {
                    xpiece = start_x + 1;
                }
                else
                {
                    xpiece = final_x + 1;
                }

                if (final_y > start_y)
                {
                    ypiece = start_y + 1;
                }
                else
                {
                    ypiece = final_y + 1;
                }
                Board.board[xpiece, ypiece] = null;
                piecesPictures[xpiece, ypiece].Dispose();
            }

            //v shogi se vyhazuje figurka, přidáváme jí do seznamu vyhozených figurek
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && Board.board[final_x, final_y] != null)
            {
                if ((isPlayer)&&(Generating.WhitePlays))
                {
                    ShowBottomShogiAddon();
                    ChooseShogiBoxBottom.Items.Add(Board.board[final_x, final_y].Name);
                }
                else if ((isPlayer) && (!Generating.WhitePlays))
                {
                    ShowUpperShogiAddon();
                    ChooseShogiBoxUpper.Items.Add(Board.board[final_x, final_y].Name);
                }
                else
                {
                    shogiAIPieces.Add(Board.board[final_x, final_y]);
                }
            }

            Board.board[final_x, final_y] = piece;
            Board.board[start_x, start_y] = null;

            piecesPictures[start_x, start_y] = null;

            //pokud se figurka vyhazuje, musíme její obrázek zrušit
            if (piecesPictures[final_x, final_y] != null)
            {
                piecesPictures[final_x, final_y].Dispose();
            }


            piecesPictures[final_x, final_y] = movingPicture;

            //změna figurky
            if (ChangePiece(final_x, final_y, piece))
                movingPicture.Image = GamePieces.Images[Board.board[final_x, final_y].GetNumber()];

            Generating.WhitePlays = !Generating.WhitePlays;

            if (isPlayer)
            {
                movingPicture.BackColor = Color.Transparent;
            }

            selected = false;
            movingPicture.Location = location[final_x, final_y]; ;
            movingPicture.BringToFront();
            DeleteHighlight();

            if (piece.Value == 900)
            {
                piece.Moved = true;
                //pokud se král posunul o dvě políčka, jedná se o rošádu
                IsCastling(start_x, start_y, final_x, final_y);
            }

            //hlídání konců her
            return EndGame();
        }

        //měnění figurek - logika
        public bool ChangePiece(int x, int y, Pieces piece)
        {

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
            if (isPlayer)
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
            else
            {
                Board.AddPiece(PieceNumber, x, y);
                return true;
            }

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
            //Koukni, zda je na šachovnici správná figurka pro danou hru
            //Pro všechny - alespoň jedna figurka příslušné barvy
            // šachy - jsou tam oba krílové?
            // shogi - jsou tam oba králové? (shogi)
            //dáma - vlastně je dost chill
            //Pokud ne, vyhoď příslušnou chybu
            //Jinak spusť hru
        }

        private void ChooseShogiButtonBottom_Click(object sender, EventArgs e)
        {
            if (AddBottomShogiPiece)
            {
                return;
            }

            if (!Generating.WhitePlays)
            {
                return;
            }

            string Piece = ChooseShogiBoxBottom.Text;
            PutShogiPieceLabelBottom.Visible = true;
            ChooseShogiBoxBottom.Text = "";
            switch (Piece)
            {
                case "":
                    return;
                case "King":
                    ShogiPiece = 7;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("King");
                    break;
                case "Rook":
                    ShogiPiece = 8;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Rook");
                    break;
                case "Bishop":
                    ShogiPiece = 10;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Bishop");
                    break;
                case "Gold general":
                    ShogiPiece = 12;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Gold general");
                    break;
                case "Silver General":
                    ShogiPiece = 13;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Silver General");
                    break;
                case "Horse":
                    ShogiPiece = 15;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Horse");
                    break;
                case "Lance":
                    ShogiPiece = 17;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Lance");
                    break;
                case "Pawn":
                    ShogiPiece = 19;
                    AddBottomShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Pawn");
                    break;
                default:
                    break;
            }
        }

        private void ChooseShogiButtonUpper_Click(object sender, EventArgs e)
        {
            if (AddUpperShogiPiece)
            {
                return;
            }

            if (Generating.WhitePlays)
            {
                return;
            }

            string Piece = ChooseShogiBoxUpper.Text;
            PutShogiPieceLabelUpper.Visible = true;
            ChooseShogiBoxUpper.Text = "";
            switch (Piece)
            {
                case "":
                    return;
                case "King":
                    ShogiPiece = 28;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("King");
                    break;
                case "Rook":
                    ShogiPiece = 29;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Rook");
                    break;
                case "Bishop":
                    ShogiPiece = 31;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Bishop");
                    break;
                case "Gold general":
                    ShogiPiece = 33;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Gold general");
                    break;
                case "Silver General":
                    ShogiPiece = 34;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Silver General");
                    break;
                case "Horse":
                    ShogiPiece = 36;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Horse");
                    break;
                case "Lance":
                    ShogiPiece = 38;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Lance");
                    break;
                case "Pawn":
                    ShogiPiece = 40;
                    AddUpperShogiPiece = true;
                    ChooseShogiBoxBottom.Items.Remove("Pawn");
                    break;
                default:
                    break;
            }
        }


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

            if (number_x<MIN_SIZE)
            {
                CustomGameSizeErrorLabel.Text = "Souřadnice x je moc malá, musí být alespoň 3.";
                CustomGameSizeErrorLabel.Visible = true;
                return;
            }

            if (number_x>MAX_SIZE)
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

            CustomGameTypeButton.Visible = true;
            CustomGameTypeCombobox.Visible = true;
            CustomGameTypeLabel.Visible = true;
        }

        private void CustomGameTypeButton_Click(object sender, EventArgs e)
        {
            string GameType = CustomGameTypeCombobox.Text;

            switch (GameType)
            {
                case "":
                    return;
                case "Šachy":
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
                    break;
                case "Dáma":
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
                    break;
                case "Shogi":
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
                    break;
            }

            CustomGameTypeButton.Visible = false;
            CustomGameTypeCombobox.Visible = false;
            CustomGameTypeLabel.Visible = false;
            SelectCustomGameButton.Visible = false;


            DrawChessboard();
            Gameclass.CurrentGame.GameEnded = true;

            CustomGameChooseButton.Visible = true;
            CustomGameChooseCombobox.Visible = true;
            CustomGameChooseLabel.Visible = true;
            NewGameButton.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddPieceToBoard(int x, int y)
        {
            AddPiece = false;
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
        }

        private void CustomGameChooseButton_Click(object sender, EventArgs e)
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

            AddPiece = true;
        }
    }
}
