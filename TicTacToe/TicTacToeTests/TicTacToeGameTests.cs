using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoFixture;
using TicTacToe.GameLogic;
using TicTacToe.Entities;

namespace TicTacToeTests
{
    [TestClass]
    public class TicTacToeGameTests
    {
        [TestMethod]
        public void StartRound_AddsNewRound()
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();

            Assert.AreEqual(1, sut.RoundHistory.Count);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(2, 2)]
        public void MakeMove_ValidMove_UpdatesBoard(int x, int y)
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();
            var move = new PlayerMove()
            {
                Position = new Tuple<int, int>(x, y),
                Piece = GamePiece.X
            };
            var result = sut.MakeMove(move);
            Assert.IsNotNull(result.Positions[x,y]);
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(4, 0)]
        [DataRow(0, 4)]
        public void MakeMove_InvalidMove_DoesNotUpdateBoard(int x, int y)
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();
            var move = new PlayerMove()
            {
                Position = new Tuple<int, int>(x, y),
                Piece = GamePiece.X
            };
            sut.MakeMove(move);           
            Assert.AreEqual(0, sut.RoundHistory[0].MoveHistory.Count);
        }

        [TestMethod]
        public void MakeMove_PlayerMakesHorizontalStreak_DeclaresWinner()
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 0),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 1),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(1, 0),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 2),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(2, 0),
                Piece = GamePiece.X
            });
            Assert.AreEqual(GameState.Player1Win, sut.GameState);
        }

        [TestMethod]
        public void MakeMove_PlayerMakesVerticalStreak_DeclaresWinner()
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 0),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(1, 0),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 1),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(2, 0),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 2),
                Piece = GamePiece.X
            });
            Assert.AreEqual(GameState.Player1Win, sut.GameState);
        }

        [TestMethod]
        public void MakeMove_PlayerMakesDiagonalStreak_DeclaresWinner()
        {
            var sut = new TicTacToeGameEngine("B. Harmon", "V. Borgov");

            sut.StartRound();
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(0, 0),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(1, 0),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(1, 1),
                Piece = GamePiece.X
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(2, 0),
                Piece = GamePiece.O
            });
            sut.MakeMove(new PlayerMove()
            {
                Position = new Tuple<int, int>(2, 2),
                Piece = GamePiece.X
            });
            Assert.AreEqual(GameState.Player1Win, sut.GameState);
        }
    }
}
