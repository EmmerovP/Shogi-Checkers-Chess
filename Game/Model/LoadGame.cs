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

        public string upperPieceFile;
        public string bottomPieceFile;

        public int[] moves;
        public int weight;
    }


    /// <summary>
    /// Object used to represent a game defined by user.
    /// </summary>
    public class CustomGame
    {
        public object[,] Board;
        public List<NewPiece> Pieces;

        public int promotionZone = -1;

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


            if (customGame.Pieces != null)
            {
                for (int i = 0; i < customGame.Pieces.Count; i++)
                {
                    if (customGame.Pieces[i].side == null)
                    {
                        DefinedPiece upperPiece = new DefinedPiece
                        {
                            moves = customGame.Pieces[i].moves,
                            Name = customGame.Pieces[i].name
                        };

                        DefinedPiece bottomPiece = new DefinedPiece
                        {
                            moves = customGame.Pieces[i].moves,
                            Name = customGame.Pieces[i].name
                        };


                        if (customGame.Pieces[i].weight != 0)
                        {
                            upperPiece.Value = customGame.Pieces[i].weight;
                            bottomPiece.Value = customGame.Pieces[i].weight;

                        }
                        else
                        {
                            upperPiece.Value = GetPieceWeight(upperPiece);
                            bottomPiece.Value = GetPieceWeight(bottomPiece);
                        }

                        PiecesNumbers.UpdatePiece(customGame.Pieces[i].name, "Vrchní " + customGame.Pieces[i].name, "Spodní " + customGame.Pieces[i].name);

                        upperPiece.isWhite = false;
                        bottomPiece.isWhite = true;

                        Pieces.DefinedPieces.Add(bottomPiece);
                        Pieces.DefinedPieces.Add(upperPiece);

                    }
                    else 
                    {
                        DefinedPiece newPiece = new DefinedPiece
                        {
                            moves = customGame.Pieces[i].moves,
                            Name = customGame.Pieces[i].name
                        };


                        if (customGame.Pieces[i].weight != 0)
                        {
                            newPiece.Value = customGame.Pieces[i].weight;
                        }
                        else
                        {
                            newPiece.Value = GetPieceWeight(newPiece);
                        }

                        if (customGame.Pieces[i].side == "white")
                        {
                            newPiece.isWhite = true;
                        }

                        PiecesNumbers.UpdatePiece(newPiece.Name);
                        Pieces.DefinedPieces.Add(newPiece);
                    }
                }
            }



            MainGameWindow.baseBoard = new int[customGame.Board.GetLength(0), customGame.Board.GetLength(1)];

            for (int i = 0; i < customGame.Board.GetLength(0); i++)
            {
                for (int j = 0; j < customGame.Board.GetLength(1); j++)
                {
                    bool succes = Int32.TryParse(customGame.Board[i, j].ToString(), out MainGameWindow.baseBoard[i, j]);       

                    if (!succes)
                    {
                        try
                        {
                            MainGameWindow.baseBoard[i, j] = PiecesNumbers.getNumber[customGame.Board[i, j].ToString()];
                        }
                        catch
                        {
                            throw new Exception("Figurka se jménem \"" + customGame.Board[i, j].ToString() + "\" neexistuje.");
                        }
                    }
                    else
                    {
                        if ((MainGameWindow.baseBoard[i, j] < -1) || (MainGameWindow.baseBoard[i, j] >= PiecesNumbers.getName.Count))
                        {
                            throw new Exception("Figurka s číslem" + MainGameWindow.baseBoard[i, j].ToString() + " neexistuje.");
                        }
                    }
                }
            }

            CheckGameRules();

            if (customGame.promotionZone != -1)
            {
                PiecesNumbers.PromotionZone = customGame.promotionZone;
            }


            return customGame;
        }

        /// <summary>
        /// Returns value of newly defined piece.
        /// Currenty, the value is based on how many moves the piece can do.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public int GetPieceWeight(DefinedPiece piece)
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

            if (result == DialogResult.OK)
            {
                if (LoadGame(LoadCustomGameDialog.FileName))
                {
                    ChooseTypeOfGame();
                }
                
            }

        }

        public bool LoadGame(string FileName)
        {
            LoadGame loadGame = new LoadGame();
            CustomGame customgame;

            try
            {
                customgame = loadGame.GetGame(FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Zadaný soubor není validní: " + exception.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (customgame == null)
            {
                return false;
            }

            if (customgame.Pieces != null)
            {
                for (int i = 0; i < customgame.Pieces.Count; i++)
                {
                    try
                    {
                        if (customgame.Pieces[i].file == null)
                        {
                            string image = customgame.Pieces[i].bottomPieceFile.Replace("\\\\", "\\");
                            GamePieces.Images.Add(Image.FromFile(image));

                            image = customgame.Pieces[i].upperPieceFile.Replace("\\\\", "\\");
                            GamePieces.Images.Add(Image.FromFile(image));
                        }
                        else
                        {
                            string image = customgame.Pieces[i].file.Replace("\\\\", "\\");
                            GamePieces.Images.Add(Image.FromFile(image));
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nelze načíst obrázek figurky.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }



    }

}