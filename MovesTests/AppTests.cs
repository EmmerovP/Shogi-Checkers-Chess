using System;
using WindowLayout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameAppTests
{

    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public void Forward()
        {
            Moves moves = new Moves();
            int[,] chessboard = new int[8, 8]{
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                {0, 0, 0, 0, 0, 0, 0, 0},
                                };
            MovesList moveslist = new MovesList();

            moveslist.AddToX(6);
            moveslist.AddToX(5);
            moveslist.AddToX(4);
            moveslist.AddToX(3);
            moveslist.AddToX(2);
            moveslist.AddToX(1);
            moveslist.AddToX(0);

            moveslist.AddToY(4);
            moveslist.AddToY(4);
            moveslist.AddToY(4);
            moveslist.AddToY(4);
            moveslist.AddToY(4);
            moveslist.AddToY(4);
            moveslist.AddToY(4);

            Assert.AreEqual(moves, moves.ForwardInfinity(7, 4, chessboard));

        }

        [TestCleanup]
        public void Cleanup()
        {
        }
    }
}
