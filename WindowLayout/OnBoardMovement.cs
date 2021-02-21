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


//třída primárně určena pro vizualizaci tahu figurkou na grafické šachovnici
namespace ShogiCheckersChess
{
    public partial class MainGameWindow : Form
    {
        public static bool CheckersTake;

        public void MoveGamePiece(object sender, EventArgs e)    //poté, co se klikne na políčko šachovnice, najde se v poli příslušný PictureBox, na který se kliklo
        {

            //zvýraznit tahy nejdřív a podívat se, zda jsou všechny napsané správně
            PictureBox picture = (PictureBox)sender;

            //dostaneme souřadnice, na které jsme klikli, asi nevím jak to udělat elegantněji než projít celou šachovnici
            int selected_x = GetX(picture);
            int selected_y = GetY(picture);


            if (AddPiece)
            {
                WhichPiece(selected_x, selected_y);
                return;
            }

            if (Gameclass.CurrentGame.GameEnded)
                return;

            if (AddBottomShogiPiece)
            {

                AddBottomShogi(selected_x, selected_y);

                return;
            }


            if (AddUpperShogiPiece)
            {

                AddUpperShogi(selected_x, selected_y);

                return;
            }


            Color background;

            if (Board.board[selected_x, selected_y] == null)
            {
                background = Color.Crimson;
            }
            else
            {
                background = Color.DarkBlue;
            }


            if (Board.board[selected_x, selected_y] != null && Board.board[selected_x, selected_y].isWhite != Generating.WhitePlays)
            {
                return;
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

                if (CheckersTake)
                {
                    Generating.WhitePlays = !Generating.WhitePlays;
                    return;
                }


                //hraje AIčko
                if (Gameclass.CurrentGame.playerType == Gameclass.PlayerType.single)
                {
                    isPlayer = false;
                    int move = RandomMoveGen.FindPiece();

                    //int move = MonteCarlo.MonteCarloMove();

                    if (move == -1)
                    {
                        label2.Text = "Vyhráli jste!";
                        return;
                    }

                    PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                        piecesPictures[Moves.start_x[move], Moves.start_y[move]]);

                    while (CheckersTake)
                    {
                        Generating.WhitePlays = !Generating.WhitePlays;

                        move = RandomMoveGen.FindPiece();

                        //int move = MonteCarlo.MonteCarloMove();

                        if (move == -1)
                        {
                            label2.Text = "Vyhráli jste!";
                            return;
                        }

                        PieceMovement(Moves.start_x[move], Moves.start_y[move], Moves.final_x[move], Moves.final_y[move],
                            piecesPictures[Moves.start_x[move], Moves.start_y[move]]);
                    }

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

        public bool PieceMovement(int start_x, int start_y, int final_x, int final_y, PictureBox movingPicture)
        {
            CheckersTake = false;

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

                if (Gameclass.CurrentGame.MustTakeCheckersPiece())
                {
                    CheckersTake = true;
                }
            }

            //v shogi se vyhazuje figurka, přidáváme jí do seznamu vyhozených figurek
            if (Gameclass.CurrentGame.gameType == Gameclass.GameType.shogi && Board.board[final_x, final_y] != null)
            {
                if ((isPlayer) && (Generating.WhitePlays))
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

    }

}