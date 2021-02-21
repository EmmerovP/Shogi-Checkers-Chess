using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;


//třída primárně určena pro vizualizaci tahu figurkou na grafické šachovnici
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
                try
                {
                    customGame = JsonConvert.DeserializeObject<CustomGame>(File.ReadAllText(file));
                }
                catch(Exception)
                {
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

                for (int i = 0; i < customGame.Pieces.Length; i++)
                {
                    DefinedPiece newPiece = new DefinedPiece();

                    newPiece.moves = customGame.Pieces[i].Item4;

                    if (customGame.Pieces[i].Item2 == "white")
                    {
                        newPiece.isWhite = true;
                    }

                    newPiece.Value = newPiece.moves.Length * 3;
                    string image = customGame.Pieces[i].Item3.Replace("\\\\", "\\");
                    GamePieces.Images.Add(Image.FromFile(image));

                    Pieces.DefinedPieces.Add(newPiece);
                }
                ChooseTypeOfGame();

            }



        }
    }

}