using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ShogiCheckersChess
{
    public class NewPiece
    {
        public string name;
        public string side;
        public string file;
        public int[] moves;
    }


    /// <summary>
    /// Object used to represent a game defined by user.
    /// </summary>
    public class CustomGame
    {
        public int[,] Board;
        public List<NewPiece> Pieces;

        public string gameType;

        public string whitePlayType;
        public string blackPlayType;

        public string whiteEndGameType;
        public string blackEndGameType;
    }

    public class LoadGame
    {
        public CustomGame GetGame(string file)
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

            customGame = JsonConvert.DeserializeObject<CustomGame>(fileWithGame);



            Pieces.DefinedPieces = new List<DefinedPiece>();

            if (customGame.gameType != null)
            {
                switch (customGame.gameType)
                {
                    case "chess":
                        Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.chess;
                        Gameclass.CurrentGame.blackGameType = Gameclass.GameType.chess;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;

                        Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.chess;
                        Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.chess;
                        Gameclass.CurrentGame.playType = Gameclass.GameType.chess;
                        break;
                    case "checkers":
                        Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.checkers;
                        Gameclass.CurrentGame.blackGameType = Gameclass.GameType.checkers;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;

                        Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.checkers;
                        Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.checkers;
                        Gameclass.CurrentGame.playType = Gameclass.GameType.checkers;
                        break;
                    case "shogi":
                        Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.shogi;
                        Gameclass.CurrentGame.blackGameType = Gameclass.GameType.shogi;
                        Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;

                        Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.shogi;
                        Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.shogi;
                        Gameclass.CurrentGame.playType = Gameclass.GameType.shogi;
                        break;
                    default:
                        throw new Exception("Typ hry (chess, shogi, checkers) u není validní.");
                }
            }
            else
            {
                GetGameType(customGame);
            }

            MainGameWindow.baseBoard = customGame.Board;

            CheckGameRules();
            
            if (customGame.Pieces != null)
            {
                for (int i = 0; i < customGame.Pieces.Count; i++)
                {
                    DefinedPiece newPiece = new DefinedPiece
                    {
                        moves = customGame.Pieces[i].moves,
                        Name = customGame.Pieces[i].name

                    };

                    if (customGame.Pieces[i].side == "white")
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
        public int GetPieceValue(DefinedPiece piece)
        {
            return piece.moves.Length * 3;
        }

        public void CheckGameRules()
        {

        }

        public void GetGameType(CustomGame customGame)
        {
            switch (customGame.whiteEndGameType)
            {
                case "chess":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.chess;
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.chess;
                    break;
                case "checkers":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.checkers;
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.checkers;
                    break;
                case "shogi":
                    Gameclass.CurrentGame.whiteGameType = Gameclass.GameType.shogi;
                    Gameclass.CurrentGame.gameType = Gameclass.GameType.shogi;
                    break;
                default:
                    throw new Exception("Typ konce hry (chess, shogi, checkers) u bílé strany není validní.");
            }

            switch (customGame.blackEndGameType)
            {
                case "chess":
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.chess;
                    break;
                case "checkers":
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.checkers;
                    break;
                case "shogi":
                    Gameclass.CurrentGame.blackGameType = Gameclass.GameType.shogi;
                    break;
                default:
                    throw new Exception("Typ konce hry (chess, shogi, checkers) u černé strany není validní.");
            }

            switch (customGame.whitePlayType)
            {
                case "chess":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.chess;
                    Gameclass.CurrentGame.playType = Gameclass.GameType.chess;
                    break;
                case "checkers":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.checkers;
                    Gameclass.CurrentGame.playType = Gameclass.GameType.checkers;
                    break;
                case "shogi":
                    Gameclass.CurrentGame.whitePlayType = Gameclass.GameType.shogi;
                    Gameclass.CurrentGame.playType = Gameclass.GameType.shogi;
                    break;
                default:
                    throw new Exception("Typ hry (chess, shogi, checkers) u bílé strany není validní.");
            }

            switch (customGame.blackPlayType)
            {
                case "chess":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.chess;
                    break;
                case "checkers":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.checkers;
                    break;
                case "shogi":
                    Gameclass.CurrentGame.blackPlayType = Gameclass.GameType.shogi;
                    break;
                default:
                    throw new Exception("Typ hry (chess, shogi, checkers) u černé strany není validní.");
            }
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
            LoadGame loadGame = new LoadGame();

            if (result == DialogResult.OK)
            {
                CustomGame customgame;

                try
                {
                    customgame = loadGame.GetGame(LoadCustomGameDialog.FileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Zadaný soubor není validní: " + exception.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (customgame == null)
                {
                    return;
                }
                
                if (customgame.Pieces != null)
                {
                    for (int i = 0; i < customgame.Pieces.Count; i++)
                    {
                        try
                        {
                            string image = customgame.Pieces[i].file.Replace("\\\\", "\\");
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