using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;


//třída primárně určena pro vizualizaci tahu figurkou na grafické šachovnici

//pro model-view-controller nechat tuto třídu jako model, controller, tedy samotné to tlačítko bude v nějaké controller třídě

namespace ShogiCheckersChess
{
    public class CustomGame
    {
        public string TypeOfGame;
        public int[,] Board;
        public Tuple<string, string, string, int[]>[] Pieces;

    }

    public partial class MainGameWindow : Form
    {
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            DialogResult result = LoadCustomGameDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                CustomGame customGame;

                string file = LoadCustomGameDialog.FileName;

                //try
                //{
                    customGame = JsonConvert.DeserializeObject<CustomGame>(File.ReadAllText(file));
                //}
                //catch(Exception)
                //{
                //   throw new Exception();
                //}

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

                        newPiece.Value = newPiece.moves.Length * 3;
                        string image = customGame.Pieces[i].Item3.Replace("\\\\", "\\");
                        GamePieces.Images.Add(Image.FromFile(image));

                        Pieces.DefinedPieces.Add(newPiece);

                        PiecesNumbers.getName.Add(PiecesNumbers.getName.Count, customGame.Pieces[i].Item1);
                        PiecesNumbers.getNumber.Add(customGame.Pieces[i].Item1, PiecesNumbers.getName.Count);
                    }
                }


                ChooseTypeOfGame();

            }



        }
    }

}