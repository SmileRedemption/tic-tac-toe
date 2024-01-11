using System;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class Board
    {
        private const int CountOfCell = 9;
        [SerializeField] private Cell[] _board;
        
        public Board()
        {
            _board = new Cell[CountOfCell];
            for (var i = 0; i < _board.Length; i++)
            {
                _board[i] = new Cell();
            }
        }

        public bool TryMakeMove(int cellIndex, Sign currentSign)
        {
            if (cellIndex is < 0 or > CountOfCell)
                throw new ArgumentException("Not valid data in cellIndex");

            if (_board[cellIndex].IsEmpty())
            {
                _board[cellIndex].PutSign(currentSign);
                return true;
            }

            return false;
        }

        public bool IsHorizontalWin()
        {
            for (int i = 0; i < (int) Math.Sqrt(CountOfCell); i++)
            {
                if (_board[i * 3].Sign == _board[i * 3 + 1].Sign && _board[i * 3 + 1].Sign == _board[i * 3 + 2].Sign &&
                    _board[i * 3].Sign != Sign.None)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsVerticalWin()
        {
            for (int i = 0; i < (int) Math.Sqrt(CountOfCell); i++)
            {
                if (_board[i].Sign == _board[i + 3].Sign && _board[i + 3].Sign == _board[i + 6].Sign &&
                    _board[i].Sign != Sign.None)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDiagonalWin()
        {
            int[] mainDiagonalIndex = {0, 4, 8};
            int[] secondaryDiagonalIndex = {2, 4, 6};
            if (_board[mainDiagonalIndex[0]].Sign == _board[mainDiagonalIndex[1]].Sign 
                && _board[mainDiagonalIndex[0]].Sign == _board[mainDiagonalIndex[2]].Sign 
                && _board[mainDiagonalIndex[0]].Sign != Sign.None)
            {
                return true;
            }

            if (_board[secondaryDiagonalIndex[0]].Sign == _board[secondaryDiagonalIndex[1]].Sign 
                && _board[secondaryDiagonalIndex[1]].Sign == _board[secondaryDiagonalIndex[2]].Sign 
                && _board[secondaryDiagonalIndex[0]].Sign != Sign.None)
            {
                return true;
            }

            return false;
        }
        
        public Sign[] GetCellSigns() => 
            _board.Select(cell => cell.Sign).ToArray();
    }
}