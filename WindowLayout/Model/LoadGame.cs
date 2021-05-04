using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShogiCheckersChess
{

    /// <summary>
    /// Object used to represent a game defined by user.
    /// </summary>
    public class CustomGame
    {
        public string TypeOfGame;
        public int[,] Board;
        public Tuple<string, string, string, int[]>[] Pieces;

    }

    public partial class MainGameWindow : Form
    {

        /// <summary>
        /// Loading custom game from JSON file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LoadCustomGameDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                CustomGame customGame;

                string file = LoadCustomGameDialog.FileName;

                try
                {
                    customGame = JsonConvert.DeserializeObject<CustomGame>(File.ReadAllText(file));
                }
                catch
                {
                    //dialogové okno s chybou?
                    return;
                }
               


                Pieces.DefinedPieces = new List<DefinedPiece>();

                switch (customGame.TypeOfGame)
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

                MainGameWindow.chessboard = customGame.Board;

                if (customGame.Pieces != null)
                {
                    for (int i = 0; i < customGame.Pieces.Length; i++)
                    {
                        DefinedPiece newPiece = new DefinedPiece
                        {
                            moves = customGame.Pieces[i].Item4,
                            Name = customGame.Pieces[i].Item1

                        };

                        if (customGame.Pieces[i].Item2 == "white")
                        {
                            newPiece.isWhite = true;
                        }

                        newPiece.Value = GetPieceValue(newPiece);

                        string image = customGame.Pieces[i].Item3.Replace("\\\\", "\\");
                        GamePieces.Images.Add(Image.FromFile(image));

                        Pieces.DefinedPieces.Add(newPiece);

                        PiecesNumbers.UpdatePiece(newPiece.Name);
                    }
                }


                ChooseTypeOfGame();

            }



        }


        /// <summary>
        /// Returns value of newly defined piece.
        /// Currenty, the value is based on how many moves the piece can do.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static int GetPieceValue(DefinedPiece piece)
        {
            return piece.moves.Length * 3;
        }
    }

}