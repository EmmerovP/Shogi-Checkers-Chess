using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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

    public static class LoadGame
    {
        public static CustomGame GetGame(string file)
        {
            CustomGame customGame;

            string fileWithGame = File.ReadAllText(file);

            var words = string.Join("|", PiecesNumbers.getNumber.Keys);


            fileWithGame = Regex.Replace(fileWithGame, $@"\b({words})\b", delegate (Match m)
            {
                return PiecesNumbers.getNumber[m.Value].ToString();
            });

            /*words = string.Join("|", PiecesNumbers.getMoveName.Keys);

            fileWithGame = Regex.Replace(fileWithGame, $@"\b({words})\b", delegate (Match m)
            {
                return PiecesNumbers.getMoveName[m.Value].ToString();
            });*/

            try
            {
                customGame = JsonConvert.DeserializeObject<CustomGame>(fileWithGame);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Zadaný soubor není validní: " + exception.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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

            MainGameWindow.baseBoard = customGame.Board;

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




                    Pieces.DefinedPieces.Add(newPiece);

                    PiecesNumbers.UpdatePiece(newPiece.Name);
                }
            }

            return customGame;
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
                var customgame = LoadGame.GetGame(LoadCustomGameDialog.FileName);

                if (customgame == null)
                {
                    return;
                }

                if (customgame.Pieces != null)
                {
                    for (int i = 0; i < customgame.Pieces.Length; i++)
                    {
                        try
                        {
                            string image = customgame.Pieces[i].Item3.Replace("\\\\", "\\");
                            GamePieces.Images.Add(Image.FromFile(image));
                        }
                        catch
                        {
                            MessageBox.Show("Nelze načíst obrázek figurky.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                ChooseTypeOfGame();
            }



        }



    }

}