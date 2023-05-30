using ChessBoard.Controls;
using DiplomaApp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ChessBoard
{
    public class MainViewModel : NotifyPropertyChanged
    {

        public static PlayWindow playWindow;
        public Board _board = new();
        private ICommand _newGameCommand;
        private ICommand _clearCommand;
        private ICommand _cellCommand;
        private ICommand _puzzlenext;
        private ICommand _puzzleprevious;
        private ICommand _puzzlecheck;
        int CurrentPuzzleNumber = 1;
        string CurrentPuzzleName = "";
        public string WhiteCastledQueenSide = "false";
        public string WhiteCastledKingSide = "false";
        public string BlackCastledQueenSide = "false";
        public string BlackCastledKingSide = "false";

        public static IEnumerable<char> Numbers => "87654321";
        public static IEnumerable<char> Letters => "ABCDEFGH";

        public int CurrentPlayer = 0;
        public bool IsItWhitesPiece;
        public bool IsWhitesKingInCheck = false;
        public bool IsBlacksKingInCheck = false;
        public static string CurrentLanguage = "English";

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }
        public ICommand PuzzlePCheck => _puzzlecheck ??= new RelayCommand(parameter =>
        {
            if (CurrentPuzzleName == "PuzzleBeginner1")
            {
                if (Board._area[0, 0].State == State.WhiteKing && Board._area[1, 2].State == State.BlackKing && Board._area[0, 3].State == State.BlackRook)
                {
                    MessageBox.Show("Верно!");
                }
                else
                    MessageBox.Show("Неверно!");
            }
            if (CurrentPuzzleName == "PuzzleBeginner2")
            {
                if (Board._area[0, 5].State == State.WhiteKing && Board._area[1, 1].State == State.WhiteRook && Board._area[0, 7].State == State.BlackKing && Board._area[2, 6].State == State.WhiteKnight)
                {
                    MessageBox.Show("Верно!");
                }
                else
                    MessageBox.Show("Неверно!");
            }
            if (CurrentPuzzleName == "PuzzleBeginner3")
            {
                if (Board._area[6, 1].State == State.WhiteBishop && Board._area[4, 3].State == State.BlackKing && Board._area[0, 7].State == State.BlackQueen)
                {
                    MessageBox.Show("Верно!");
                }
                else
                    MessageBox.Show("Неверно!");
            }
        });
        public ICommand PuzzlePrevious => _puzzleprevious ??= new RelayCommand(parameter =>
        {
            if (CurrentPuzzleNumber == 0)
                CurrentPuzzleNumber = 3;
            else if (CurrentPuzzleNumber == 1)
            {
                CurrentPlayer = 1;
                CurrentPuzzleName = "PuzzleBeginner3";
                Board board = new();
                board[0, 7] = State.BlackQueen;
                board[7, 5] = State.WhiteKing;
                board[7, 4] = State.WhiteQueen;
                board[7, 3] = State.WhiteRook;
                board[7, 2] = State.WhiteBishop;
                board[5, 3] = State.BlackPawn;
                board[4, 3] = State.BlackKing;
                Board = board;
                CurrentPuzzleNumber = 3;
            }
            else if (CurrentPuzzleNumber == 2)
            {
                CurrentPuzzleName = "PuzzleBeginner1";
                CurrentPlayer = 2;
                Board board = new();
                board[0, 0] = State.WhiteKing;
                board[1, 0] = State.WhitePawn;
                board[2, 0] = State.WhitePawn;
                board[5, 3] = State.WhiteKnight;
                board[1, 2] = State.BlackKing;
                board[1, 3] = State.BlackRook;
                Board = board;
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 3)
            {
                CurrentPlayer = 1;
                CurrentPuzzleName = "PuzzleBeginner2";
                Board board = new();
                board[1, 1] = State.WhiteRook;
                board[0, 5] = State.WhiteKing;
                board[0, 7] = State.BlackKing;
                board[7, 2] = State.BlackQueen;
                board[3, 4] = State.WhiteKnight;
                board[4, 4] = State.BlackPawn;
                Board = board;
                CurrentPuzzleNumber--;
            }
        });
        public ICommand PuzzleNext => _puzzlenext ??= new RelayCommand(parameter =>
        {
            if (CurrentPuzzleNumber == 0)
                CurrentPuzzleNumber = 1;
            else if (CurrentPuzzleNumber == 1)
            {
                CurrentPuzzleName = "PuzzleBeginner1";
                CurrentPlayer = 2;
                Board board = new();
                board[0, 0] = State.WhiteKing;
                board[1, 0] = State.WhitePawn;
                board[2, 0] = State.WhitePawn;
                board[5, 3] = State.WhiteKnight;
                board[1, 2] = State.BlackKing;
                board[1, 3] = State.BlackRook;
                Board = board;
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 2)
            {
                CurrentPuzzleName = "PuzzleBeginner2";
                CurrentPlayer = 1;
                Board board = new();
                board[1, 1] = State.WhiteRook;
                board[0, 5] = State.WhiteKing;
                board[0, 7] = State.BlackKing;
                board[7, 2] = State.BlackQueen;
                board[3, 4] = State.WhiteKnight;
                board[4, 4] = State.BlackPawn;
                Board = board;
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 3)
            {
                CurrentPuzzleName = "PuzzleBeginner3";
                CurrentPlayer = 1;
                Board board = new();
                board[0, 7] = State.BlackQueen;
                board[7, 5] = State.WhiteKing;
                board[7, 4] = State.WhiteQueen;
                board[7, 3] = State.WhiteRook;
                board[7, 2] = State.WhiteBishop;
                board[5, 3] = State.BlackPawn;
                board[4, 3] = State.BlackKing;
                Board = board;
                CurrentPuzzleNumber = 1;
            }
        });

        public ICommand NewGameCommand => _newGameCommand ??= new RelayCommand(parameter =>
        {
            SetupBoard();
        });

        public ICommand ClearCommand => _clearCommand ??= new RelayCommand(parameter =>
        {
            Board = new Board();
        });

        public ICommand CellCommand => _cellCommand ??= new RelayCommand(parameter =>
        {
            Cell cell = (Cell)parameter;
            Cell activeCell = Board.FirstOrDefault(x => x.Active);
            if (CurrentPlayer == 1)
            {
                WhichPlayersPiece(cell, cell.RowNumber, cell.ColumnNumber);
                if (cell.State != State.Empty && IsItWhitesPiece == true)
                {
                    if (!cell.Active && activeCell != null)
                    {
                        activeCell.Active = false;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    }
                    cell.Active = !cell.Active;
                }
                else if (activeCell != null && IsItWhitesPiece == false)
                {
                    if (cell.PossibleMove == true && activeCell.State != State.WhiteKing)
                    {
                        activeCell.Active = false;
                        cell.State = activeCell.State;
                        activeCell.State = State.Empty;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                        SwitchPlayer();
                    }
                    else if (cell.PossibleMove == true && activeCell.State == State.WhiteKing)
                    {
                        if (Board._area[cell.RowNumber, cell.ColumnNumber] == Board._area[7, 6])
                        {
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            Board._area[7, 5].State = State.WhiteRook;
                            Board._area[7, 7].State = State.Empty;
                            WhiteCastledKingSide = "true";
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                        else if (Board._area[cell.RowNumber, cell.ColumnNumber] == Board._area[7, 2])
                        {
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            Board._area[7, 3].State = State.WhiteRook;
                            Board._area[7, 0].State = State.Empty;
                            WhiteCastledQueenSide = "true";
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                        else
                        {
                            if (activeCell.State == State.WhiteKing)
                            {
                                WhiteCastledQueenSide = "impossible";
                                WhiteCastledKingSide = "impossible";
                            }
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                    }
                }
                else if (activeCell == null)
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                else
                {
                    if (IsItWhitesPiece == true)
                    {
                        activeCell.Active = true;
                        cell.State = activeCell.State;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    }
                }
                MarkLegalMoves(activeCell, cell);
                if (!cell.Active)
                {
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                }
            }
            else if (CurrentPlayer != 1)
            {
                WhichPlayersPiece(cell, cell.RowNumber, cell.ColumnNumber);
                if (cell.State != State.Empty && IsItWhitesPiece == false)
                {
                    if (!cell.Active && activeCell != null)
                    {
                        activeCell.Active = false;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    }
                    cell.Active = !cell.Active;
                }
                else if (activeCell != null && IsItWhitesPiece == true)
                {
                    if (cell.PossibleMove == true && activeCell.State != State.BlackKing)
                    {
                        activeCell.Active = false;
                        cell.State = activeCell.State;
                        activeCell.State = State.Empty;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                        SwitchPlayer();
                    }
                    else if (cell.PossibleMove == true && activeCell.State == State.BlackKing)
                    {
                        if (Board._area[cell.RowNumber, cell.ColumnNumber] == Board._area[0, 6])
                        {
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            Board._area[0, 5].State = State.BlackRook;
                            Board._area[0, 7].State = State.Empty;
                            BlackCastledKingSide = "true";
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                        else if (Board._area[cell.RowNumber, cell.ColumnNumber] == Board._area[0, 2])
                        {
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            Board._area[0, 3].State = State.BlackRook;
                            Board._area[0, 0].State = State.Empty;
                            BlackCastledQueenSide = "true";
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                        else
                        {
                            if (activeCell.State == State.BlackKing)
                            {
                                BlackCastledQueenSide = "impossible";
                                BlackCastledKingSide = "impossible";
                            }
                            activeCell.Active = false;
                            cell.State = activeCell.State;
                            activeCell.State = State.Empty;
                            DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                            SwitchPlayer();
                        }
                    }
                }
                else if (activeCell == null)
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                else
                {
                    if (IsItWhitesPiece == true)
                    {
                        activeCell.Active = true;
                        cell.State = activeCell.State;
                        DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    }
                }
                MarkLegalMoves(activeCell, cell);
                if (!cell.Active)
                {
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                }
            }
        }, parameter => parameter is Cell cell && (Board.Any(x => x.Active) || cell.State != State.Empty));

        private void SetupBoard()
        {
            CurrentPlayer = 1;
            Board board = new();
            board[0, 0] = State.BlackRook;
            board[0, 1] = State.BlackKnight;
            board[0, 2] = State.BlackBishop;
            board[0, 3] = State.BlackQueen;
            board[0, 4] = State.BlackKing;
            board[0, 5] = State.BlackBishop;
            board[0, 6] = State.BlackKnight;
            board[0, 7] = State.BlackRook;
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = State.BlackPawn;
                board[6, i] = State.WhitePawn;
            }
            board[7, 0] = State.WhiteRook;
            board[7, 1] = State.WhiteKnight;
            board[7, 2] = State.WhiteBishop;
            board[7, 3] = State.WhiteQueen;
            board[7, 4] = State.WhiteKing;
            board[7, 5] = State.WhiteBishop;
            board[7, 6] = State.WhiteKnight;
            board[7, 7] = State.WhiteRook;
            Board = board;
            WhiteCastledQueenSide = "false";
            WhiteCastledKingSide = "false";
            BlackCastledQueenSide = "false";
            BlackCastledKingSide = "false";
        }

        public static bool InsideBorder(int i, int j)
        {
            if (i >= 8 || j >= 8 || i < 0 || j < 0)
                return false;
            else
                return true;
        }

        public void MarkLegalMoves(Cell activeCell, Cell cell)
        {
            if (CurrentPlayer == 1)
            {
                int i, j;

                switch (cell.State)
                {
                    case State.WhiteBishop:
                        if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                        {
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].PossibleMove = true;
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        if (Board._area[i, j].IsOccupiedByWhite == true && Board._area[i, j].State == State.BlackKing)
                                        {
                                            MessageBox.Show("Black king is in check!", "Warning");
                                            IsBlacksKingInCheck = true;
                                        }
                                        i = i - 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i - 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].PossibleMove = true;
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        if (Board._area[i, j].IsOccupiedByWhite == true && Board._area[i, j].State == State.BlackKing)
                                        {
                                            MessageBox.Show("Black king is in check!", "Warning");
                                            IsBlacksKingInCheck = true;
                                        }
                                        i = i - 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i - 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].PossibleMove = true;
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        if (Board._area[i, j].IsOccupiedByWhite == true && Board._area[i, j].State == State.BlackKing)
                                        {
                                            MessageBox.Show("Black king is in check!", "Warning");
                                            IsBlacksKingInCheck = true;
                                        }
                                        i = i + 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i + 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].PossibleMove = true;
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        if (Board._area[i, j].IsOccupiedByWhite == true && Board._area[i, j].State == State.BlackKing)
                                        {
                                            MessageBox.Show("Black king is in check!", "Warning");
                                            IsBlacksKingInCheck = true;
                                        }
                                        i = i + 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i + 8;
                            }
                        }
                        break;

                    case State.WhiteKing:
                        i = cell.RowNumber;
                        j = cell.ColumnNumber;
                        if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State == State.Empty && Board._area[i - 1, j].IsOccupiedByBlack == false)
                        {
                            Board._area[i - 1, j].PossibleMove = true;
                            Board._area[i - 1, j].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State != State.Empty && Board._area[i - 1, j].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i - 1, j);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j].IsOccupiedByWhite = true;
                                Board._area[i - 1, j].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State == State.Empty && Board._area[i + 1, j].IsOccupiedByBlack == false)
                        {
                            Board._area[i + 1, j].PossibleMove = true;
                            Board._area[i + 1, j].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State != State.Empty && Board._area[i + 1, j].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i + 1, j);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j].PossibleMove = true;
                                Board._area[i + 1, j].IsOccupiedByWhite = true;
                            }
                        }

                        if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State == State.Empty && Board._area[i, j - 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i, j - 1].PossibleMove = true;
                            Board._area[i, j - 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State != State.Empty && Board._area[i, j - 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i, j - 1].PossibleMove = true;
                                Board._area[i, j - 1].IsOccupiedByWhite = true;
                            }
                        }

                        if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State == State.Empty && Board._area[i, j + 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i, j + 1].PossibleMove = true;
                            Board._area[i, j + 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State != State.Empty && Board._area[i, j + 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i, j + 1].PossibleMove = true;
                                Board._area[i, j + 1].IsOccupiedByWhite = true;
                            }
                        }

                        if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State == State.Empty && Board._area[i - 1, j - 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i - 1, j - 1].PossibleMove = true;
                            Board._area[i - 1, j - 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State != State.Empty && Board._area[i - 1, j - 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i - 1, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j - 1].PossibleMove = true;
                                Board._area[i - 1, j - 1].IsOccupiedByWhite = true;
                            }
                        }

                        if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State == State.Empty && Board._area[i + 1, j + 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i + 1, j + 1].PossibleMove = true;
                            Board._area[i + 1, j + 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State != State.Empty && Board._area[i + 1, j + 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i + 1, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j + 1].PossibleMove = true;
                                Board._area[i + 1, j + 1].IsOccupiedByWhite = true;
                            }
                        }

                        if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State == State.Empty && Board._area[i - 1, j + 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i - 1, j + 1].PossibleMove = true;
                            Board._area[i - 1, j + 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State != State.Empty && Board._area[i - 1, j + 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i - 1, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j + 1].PossibleMove = true;
                                Board._area[i - 1, j + 1].IsOccupiedByWhite = true;
                            }
                        }
                        if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State == State.Empty && Board._area[i + 1, j - 1].IsOccupiedByBlack == false)
                        {
                            Board._area[i + 1, j - 1].PossibleMove = true;
                            Board._area[i + 1, j - 1].IsOccupiedByWhite = true;
                        }
                        else if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State != State.Empty && Board._area[i + 1, j - 1].IsOccupiedByBlack == false)
                        {
                            WhichPlayersPiece(cell, i + 1, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j - 1].PossibleMove = true;
                                Board._area[i + 1, j - 1].IsOccupiedByWhite = true;
                            }
                        }
                        if (Board._area[7, 4].State == State.WhiteKing && Board._area[7, 7].State == State.WhiteRook)
                        {
                            if (WhiteCastledKingSide == "false" && WhiteCastledQueenSide == "false")
                            {
                                if (Board._area[7, 5].State == State.Empty && Board._area[7, 6].State == State.Empty)
                                    Board._area[7, 6].PossibleMove = true;
                            }
                        }
                        if (Board._area[7, 4].State == State.WhiteKing && Board._area[7, 0].State == State.WhiteRook)
                        {
                            if (WhiteCastledKingSide == "false" && WhiteCastledQueenSide == "false")
                            {
                                if (Board._area[7, 3].State == State.Empty && Board._area[7, 2].State == State.Empty && Board._area[7, 1].State == State.Empty)
                                    Board._area[7, 2].PossibleMove = true;
                            }
                        }
                        break;

                    case State.WhitePawn:
                        if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber) == true && cell.RowNumber == 6)
                        {
                            WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber);
                            if (Board._area[cell.RowNumber - 1, cell.ColumnNumber].State == State.Empty)
                            {
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber].PossibleMove = true;
                                if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 1))
                                {
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].IsOccupiedByWhite = true;
                                }
                                if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 1))
                                {
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                                }
                                WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber);
                                if (Board._area[cell.RowNumber - 2, cell.ColumnNumber].State == State.Empty)
                                {
                                    if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber))
                                    {
                                        Board._area[cell.RowNumber - 2, cell.ColumnNumber].PossibleMove = true;
                                        if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber - 1))
                                        {
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                                        }
                                        if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber + 1))
                                        {
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].IsOccupiedByWhite = true;
                                        }
                                    }
                                    if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 1))
                                    {
                                        Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].IsOccupiedByWhite = false;
                                    }
                                    if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 1))
                                    {
                                        Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].IsOccupiedByWhite = false;
                                    }
                                }
                            }
                        }
                        else if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber) == true && cell.RowNumber != 6 && Board._area[cell.RowNumber - 1, cell.ColumnNumber].State == State.Empty)
                        {
                            Board._area[cell.RowNumber - 1, cell.ColumnNumber].PossibleMove = true;
                            if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 1))
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                            if(InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 1))
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].IsOccupiedByWhite = true;

                        }
                        if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 1) == true)
                        {
                            WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber - 1);
                            if (IsItWhitesPiece == false && Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].State != State.Empty)
                            {
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].PossibleMove = true;
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                            }
                        }
                        if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 1) == true)
                        {
                            WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber + 1);
                            if (IsItWhitesPiece == false && Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].State != State.Empty)
                            {
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].PossibleMove = true;
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].IsOccupiedByWhite = true;
                            }
                        }
                        break;

                    case State.WhiteKnight:
                        if (cell != null)
                        {
                            if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber + 1) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber + 2, cell.ColumnNumber + 1);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].PossibleMove = true;
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber - 1) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber + 2, cell.ColumnNumber - 1);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].PossibleMove = true;
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber - 1) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber - 1);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].PossibleMove = true;
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber + 1) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber + 1);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].PossibleMove = true;
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 2) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber + 2);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].PossibleMove = true;
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 2) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber - 2);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].PossibleMove = true;
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 2) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber - 2);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].PossibleMove = true;
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].PossibleMove = false;
                            }

                            if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 2) == true)
                            {
                                WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber + 2);
                                if (IsItWhitesPiece == false)
                                {
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].PossibleMove = true;
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].IsOccupiedByWhite = true;
                                }
                                else
                                    Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].PossibleMove = false;
                            }
                        }
                        break;

                    case State.WhiteRook:
                        if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                        {
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j == cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                    Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = true;
                                    if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                        i = i - 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j == cell.ColumnNumber)
                                    i = i - 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j == cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                    Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = true;
                                    if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                        i = i + 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j == cell.ColumnNumber)
                                    i = i + 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i == cell.RowNumber && j != cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[cell.RowNumber, j].PossibleMove = true;
                                    Board._area[cell.RowNumber, j].IsOccupiedByWhite = true;
                                    if (Board._area[cell.RowNumber, j].State != State.Empty)
                                        j = j - 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[cell.RowNumber, j].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j != cell.ColumnNumber)
                                    j = j - 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i == cell.RowNumber && j != cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[cell.RowNumber, j].PossibleMove = true;
                                    Board._area[cell.RowNumber, j].IsOccupiedByWhite = true;
                                    if (Board._area[cell.RowNumber, j].State != State.Empty)
                                        j = j + 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[cell.RowNumber, j].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j != cell.ColumnNumber)
                                    j = j + 8;
                            }
                        }
                        break;

                    case State.WhiteQueen:
                        if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                        {
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j == cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                    Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = true;
                                    if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                        i = i - 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j == cell.ColumnNumber)
                                    i = i - 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j == cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                    Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = true;
                                    if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                        i = i + 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j == cell.ColumnNumber)
                                    i = i + 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i == cell.RowNumber && j != cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[cell.RowNumber, j].PossibleMove = true;
                                    Board._area[cell.RowNumber, j].IsOccupiedByWhite = true;
                                    if (Board._area[cell.RowNumber, j].State != State.Empty)
                                        j = j - 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[cell.RowNumber, j].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j != cell.ColumnNumber)
                                    j = j - 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i == cell.RowNumber && j != cell.ColumnNumber && InsideBorder(i, j) == true)
                                {
                                    Board._area[cell.RowNumber, j].PossibleMove = true;
                                    Board._area[cell.RowNumber, j].IsOccupiedByWhite = true;
                                    if (Board._area[cell.RowNumber, j].State != State.Empty)
                                        j = j + 8;
                                }
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[cell.RowNumber, j].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i == cell.RowNumber && j != cell.ColumnNumber)
                                    j = j + 8;
                            }
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        Board._area[i, j].PossibleMove = true;
                                        i = i - 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                    Board._area[i, j].PossibleMove = false;
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i - 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = true;
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        Board._area[i, j].PossibleMove = true;
                                        i = i - 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i - 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    Board._area[i, j].PossibleMove = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        Board._area[i, j].PossibleMove = true;
                                        i = i + 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i + 8;
                            }

                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                            {
                                WhichPlayersPiece(cell, i, j);
                                if (IsItWhitesPiece == false && i != cell.RowNumber && j != cell.ColumnNumber)
                                {
                                    Board._area[i, j].IsOccupiedByWhite = true;
                                    Board._area[i, j].PossibleMove = true;
                                    if (Board._area[i, j].State != State.Empty)
                                    {
                                        Board._area[i, j].IsOccupiedByWhite = true;
                                        Board._area[i, j].PossibleMove = true;
                                        i = i + 8;
                                    }
                                }
                                else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                {
                                    Board._area[i, j].PossibleMove = false;
                                }
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i + 8;
                            }
                        }
                        break;

                    case State.Empty:
                        break;

                    default:
                        break;
                }
            }
            else
            {
                int i, j;
                if (CurrentPlayer != 1)
                {
                    switch (cell.State)
                    {
                        case State.BlackBishop:
                            if (IsBlacksKingInCheck == false)
                            {
                                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                                {
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = true;
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].IsOccupiedByBlack = true;
                                                Board._area[i, j].PossibleMove = true;
                                                i = i - 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i - 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            Board._area[i, j].PossibleMove = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].PossibleMove = true;
                                                Board._area[i, j].IsOccupiedByBlack = true;
                                                i = i - 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i - 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = true;
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].IsOccupiedByBlack = true;
                                                Board._area[i, j].PossibleMove = true;
                                                i = i + 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i + 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            Board._area[i, j].PossibleMove = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].IsOccupiedByBlack = true;
                                                Board._area[i, j].PossibleMove = true;
                                                i = i + 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i + 8;
                                    }
                                }
                            }
                            break;
                        case State.BlackKing:
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State == State.Empty && Board._area[i - 1, j].IsOccupiedByWhite == false)
                            {
                                Board._area[i - 1, j].PossibleMove = true;
                                Board._area[i - 1, j].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State != State.Empty && Board._area[i - 1, j].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i - 1, j);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j].IsOccupiedByBlack = true;
                                    Board._area[i - 1, j].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State == State.Empty && Board._area[i + 1, j].IsOccupiedByWhite == false)
                            {
                                Board._area[i + 1, j].PossibleMove = true;
                                Board._area[i + 1, j].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State != State.Empty && Board._area[i + 1, j].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i + 1, j);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j].PossibleMove = true;
                                    Board._area[i + 1, j].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State == State.Empty && Board._area[i, j - 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i, j - 1].PossibleMove = true;
                                Board._area[i, j - 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State != State.Empty && Board._area[i, j - 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i, j - 1].PossibleMove = true;
                                    Board._area[i, j - 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State == State.Empty && Board._area[i, j + 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i, j + 1].PossibleMove = true;
                                Board._area[i, j + 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State != State.Empty && Board._area[i, j + 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i, j + 1].PossibleMove = true;
                                    Board._area[i, j + 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State == State.Empty && Board._area[i - 1, j - 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i - 1, j - 1].PossibleMove = true;
                                Board._area[i - 1, j - 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State != State.Empty && Board._area[i - 1, j - 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i - 1, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j - 1].PossibleMove = true;
                                    Board._area[i - 1, j - 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State == State.Empty && Board._area[i + 1, j + 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i + 1, j + 1].PossibleMove = true;
                                Board._area[i + 1, j + 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State != State.Empty && Board._area[i + 1, j + 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i + 1, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j + 1].PossibleMove = true;
                                    Board._area[i + 1, j + 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State == State.Empty && Board._area[i - 1, j + 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i - 1, j + 1].PossibleMove = true;
                                Board._area[i - 1, j + 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State != State.Empty && Board._area[i - 1, j + 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i - 1, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j + 1].PossibleMove = true;
                                    Board._area[i - 1, j + 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State == State.Empty && Board._area[i + 1, j - 1].IsOccupiedByWhite == false)
                            {
                                Board._area[i + 1, j - 1].PossibleMove = true;
                                Board._area[i + 1, j - 1].IsOccupiedByBlack = true;
                            }
                            else if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State != State.Empty && Board._area[i + 1, j - 1].IsOccupiedByWhite == false)
                            {
                                WhichPlayersPiece(cell, i + 1, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j - 1].PossibleMove = true;
                                    Board._area[i + 1, j - 1].IsOccupiedByBlack = true;
                                }
                            }
                            if (Board._area[0, 4].State == State.BlackKing && Board._area[0, 7].State == State.BlackRook)
                            {
                                if (BlackCastledKingSide == "false" && BlackCastledQueenSide == "false")
                                {
                                    if (Board._area[0, 5].State == State.Empty && Board._area[0, 6].State == State.Empty)
                                        Board._area[0, 6].PossibleMove = true;
                                }
                            }
                            if (Board._area[0, 4].State == State.BlackKing && Board._area[0, 0].State == State.BlackRook)
                            {
                                if (BlackCastledKingSide == "false" && BlackCastledQueenSide == "false")
                                {
                                    if (Board._area[0, 3].State == State.Empty && Board._area[0, 2].State == State.Empty && Board._area[0, 1].State == State.Empty)
                                        Board._area[0, 2].PossibleMove = true;
                                }
                            }
                            break;

                        case State.BlackPawn:
                            if (IsBlacksKingInCheck == false)
                            {
                                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber) == true && cell.RowNumber == 1)
                                {
                                    if (Board._area[cell.RowNumber + 1, cell.ColumnNumber].State == State.Empty)
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber].PossibleMove = true;
                                        if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 1))
                                        {
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].IsOccupiedByBlack = true;
                                        }
                                        if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 1))
                                        {
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                        }
                                        if (Board._area[cell.RowNumber + 2, cell.ColumnNumber].State == State.Empty)
                                        {
                                            if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber))
                                            {
                                                Board._area[cell.RowNumber + 2, cell.ColumnNumber].PossibleMove = true;
                                                if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber - 1))
                                                {
                                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                                }
                                                if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber - 1))
                                                {
                                                    Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                                }
                                            }
                                            if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 1))
                                            {
                                                Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].IsOccupiedByBlack = false;
                                            }
                                            if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 1))
                                            {
                                                Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].IsOccupiedByBlack = false;
                                            }
                                        }
                                    }
                                }
                                else if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber) == true && cell.RowNumber != 1 && Board._area[cell.RowNumber + 1, cell.ColumnNumber].State == State.Empty)
                                {
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber].PossibleMove = true;
                                    if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 1))
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                    }
                                    if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 1))
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].IsOccupiedByBlack = true;
                                    }
                                }
                                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 1) == true)
                                {
                                    WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber - 1);
                                    if (IsItWhitesPiece == true && Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].State != State.Empty)
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].PossibleMove = true;
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                    }
                                }
                                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 1) == true)
                                {
                                    WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber + 1);
                                    if (IsItWhitesPiece == true && Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].State != State.Empty)
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].PossibleMove = true;
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].IsOccupiedByBlack = true;
                                    }
                                }
                            }
                            break;

                        case State.BlackKnight:
                            if (IsBlacksKingInCheck == false)
                            {
                                if (cell != null)
                                {
                                    if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber + 1) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber + 2, cell.ColumnNumber + 1);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].PossibleMove = true;
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber - 1) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber + 2, cell.ColumnNumber - 1);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].PossibleMove = true;
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber - 1) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber - 1);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].PossibleMove = true;
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber + 1) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber + 1);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].PossibleMove = true;
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 2) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber + 2);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].PossibleMove = true;
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 2) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber - 2);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].PossibleMove = true;
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 2) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber - 2);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].PossibleMove = true;
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].PossibleMove = false;
                                    }

                                    if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 2) == true)
                                    {
                                        WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber + 2);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty)
                                        {
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].PossibleMove = true;
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].IsOccupiedByBlack = true;
                                        }
                                        else
                                            Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].PossibleMove = false;
                                    }
                                }
                            }
                            break;
                        case State.BlackRook:
                            if (IsBlacksKingInCheck == false)
                            {
                                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                                {
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = true;
                                            if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                                i = i - 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                            i = i - 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = true;
                                            if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                                i = i + 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                            i = i + 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[cell.RowNumber, j].PossibleMove = true;
                                            Board._area[cell.RowNumber, j].IsOccupiedByBlack = true;
                                            if (Board._area[cell.RowNumber, j].State != State.Empty)
                                                j = j - 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[cell.RowNumber, j].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                            j = j - 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[cell.RowNumber, j].PossibleMove = true;
                                            Board._area[cell.RowNumber, j].IsOccupiedByBlack = true;
                                            if (Board._area[cell.RowNumber, j].State != State.Empty)
                                                j = j + 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[cell.RowNumber, j].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                            j = j + 8;
                                    }
                                }
                            }
                            break;

                        case State.BlackQueen:
                            if (IsBlacksKingInCheck == false)
                            {
                                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                                {
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = true;
                                            if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                                i = i - 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                            i = i - 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, cell.ColumnNumber].PossibleMove = true;
                                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = true;
                                            if (Board._area[i, cell.ColumnNumber].State != State.Empty)
                                                i = i + 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[i, cell.ColumnNumber].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j == cell.ColumnNumber)
                                            i = i + 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[cell.RowNumber, j].PossibleMove = true;
                                            Board._area[cell.RowNumber, j].IsOccupiedByBlack = true;
                                            if (Board._area[cell.RowNumber, j].State != State.Empty)
                                                j = j - 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[cell.RowNumber, j].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                            j = j - 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[cell.RowNumber, j].PossibleMove = true;
                                            Board._area[cell.RowNumber, j].IsOccupiedByBlack = true;
                                            if (Board._area[cell.RowNumber, j].State != State.Empty)
                                                j = j + 8;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j == cell.ColumnNumber)
                                            Board._area[cell.RowNumber, j].PossibleMove = false;
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i == cell.RowNumber && j != cell.ColumnNumber)
                                            j = j + 8;
                                    }
                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = true;
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].PossibleMove = true;
                                                i = i - 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i - 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            Board._area[i, j].PossibleMove = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].PossibleMove = true;
                                                i = i - 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i - 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = true;
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].PossibleMove = true;
                                                i = i + 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i + 8;
                                    }

                                    i = cell.RowNumber;
                                    j = cell.ColumnNumber;
                                    for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                                    {
                                        WhichPlayersPiece(cell, i, j);
                                        if (IsItWhitesPiece == true || cell.State == State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = true;
                                            Board._area[i, j].IsOccupiedByBlack = true;
                                            if (Board._area[i, j].State != State.Empty)
                                            {
                                                Board._area[i, j].PossibleMove = true;
                                                i = i + 8;
                                            }
                                        }
                                        else if (i == cell.RowNumber && j == cell.ColumnNumber)
                                        {
                                            Board._area[i, j].PossibleMove = false;
                                        }
                                        else if (IsItWhitesPiece == false && cell.State != State.Empty && i != cell.RowNumber && j != cell.ColumnNumber)
                                            i = i + 8;
                                    }
                                }
                            }
                            break;
                        case State.Empty:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DeleteMarks(int i, int j)
        {
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    Board._area[i, j].PossibleMove = false;
                }
            }
        }
        public void DeleteOccupiedSquares(Cell cell, int i, int j)
        {
            if (cell.State == State.WhiteKnight || cell.State == State.BlackKnight)
            {
                if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber + 1) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber - 1) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber + 2, cell.ColumnNumber + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber + 2, cell.ColumnNumber - 1].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber - 1) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber - 2, cell.ColumnNumber - 1].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber + 1) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber - 2, cell.ColumnNumber + 1].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 2) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 2].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 2) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 2].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 2) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber - 1, cell.ColumnNumber - 2].IsOccupiedByBlack = false;
                }

                if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 2) == true)
                {
                    if (CurrentPlayer == 2)
                        Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 1)
                        Board._area[cell.RowNumber - 1, cell.ColumnNumber + 2].IsOccupiedByBlack = false;
                }
            }
            else if (cell.State == State.WhiteBishop || cell.State == State.BlackBishop)
            {
                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                {
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }
                }
            }
            else if (cell.State == State.WhitePawn || cell.State == State.BlackPawn)
            {
                if (InsideBorder(i, j) == true)
                {
                    if (CurrentPlayer == 1)
                    {
                        if (InsideBorder(i, j - 1) == true)
                        {
                            Board._area[i, j - 1].IsOccupiedByWhite = false;
                        }
                        if (InsideBorder(i, j + 1))
                        {
                            Board._area[i, j + 1].IsOccupiedByWhite = false;
                        }
                    }
                    else if (CurrentPlayer == 2)
                    {
                        if (InsideBorder(i, j - 1) == true)
                        {
                            Board._area[i, j - 1].IsOccupiedByBlack = false;
                        }
                        if (InsideBorder(i, j + 1))
                        {
                            Board._area[i, j + 1].IsOccupiedByBlack = false;
                        }
                    }
                }
            }
            else if (cell.State == State.WhiteRook || cell.State == State.BlackRook)
            {
                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                {
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                }
            }
            else if (cell.State == State.WhiteQueen || cell.State == State.BlackQueen)
            {
                if (InsideBorder(cell.RowNumber, cell.ColumnNumber) == true)
                {
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && j < 8 && InsideBorder(i, j) == true; i--, j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && j >= 0 && InsideBorder(i, j); i--, j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && j < 8 && InsideBorder(i, j) == true; i++, j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }

                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && j >= 0 && InsideBorder(i, j) == true; i++, j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 1)
                            Board._area[i, j].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i >= 0 && InsideBorder(i, cell.ColumnNumber); i--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; i < 8 && InsideBorder(i, cell.ColumnNumber); i++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; j >= 0 && InsideBorder(cell.RowNumber, j); j--)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                    i = cell.RowNumber;
                    j = cell.ColumnNumber;
                    for (; j < 8 && InsideBorder(cell.RowNumber, j); j++)
                    {
                        if (CurrentPlayer == 1)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByWhite = false;
                        else if (CurrentPlayer == 2)
                            Board._area[i, cell.ColumnNumber].IsOccupiedByBlack = false;
                    }
                }
            }
            else if (cell.State == State.WhiteKing || cell.State == State.BlackKing)
            {
                i = cell.RowNumber;
                j = cell.ColumnNumber;
                if (InsideBorder(i - 1, j) == true)
                {
                    Board._area[i - 1, j].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i - 1, j) == true)
                {
                    Board._area[i - 1, j].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i + 1, j) == true)
                {
                    Board._area[i + 1, j].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i + 1, j) == true)
                {
                    Board._area[i + 1, j].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i, j - 1) == true)
                {
                    Board._area[i, j - 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i, j - 1) == true)
                {
                    Board._area[i, j - 1].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i, j + 1) == true)
                {
                    Board._area[i, j + 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i, j + 1) == true)
                {
                    Board._area[i, j + 1].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i - 1, j - 1) == true)
                {
                    Board._area[i - 1, j - 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i - 1, j - 1) == true)
                {
                    Board._area[i - 1, j - 1].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i + 1, j + 1) == true)
                {
                    Board._area[i + 1, j + 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i + 1, j + 1) == true)
                {
                    if (CurrentPlayer == 1)
                        Board._area[i + 1, j + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 2)
                        Board._area[i + 1, j + 1].IsOccupiedByBlack = false;
                }
                if (InsideBorder(i - 1, j + 1) == true)
                {
                    if (CurrentPlayer == 1)
                        Board._area[i - 1, j + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 2)
                        Board._area[i - 1, j + 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i - 1, j + 1) == true)
                {
                    if (CurrentPlayer == 1)
                        Board._area[i + 1, j + 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 2)
                        Board._area[i - 1, j + 1].IsOccupiedByBlack = false;

                }
                if (InsideBorder(i + 1, j - 1) == true)
                {
                    if (CurrentPlayer == 1)
                        Board._area[i + 1, j - 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 2)
                        Board._area[i + 1, j - 1].IsOccupiedByBlack = false;
                }
                else if (InsideBorder(i + 1, j - 1) == true)
                {
                    if (CurrentPlayer == 1)
                        Board._area[i + 1, j - 1].IsOccupiedByWhite = false;
                    else if (CurrentPlayer == 2)
                        Board._area[i + 1, j - 1].IsOccupiedByBlack = false;
                }
            }
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == 1)
            {
                CurrentPlayer = 2;
                return;
            }
            else
            {
                CurrentPlayer = 1;
                return;
            }
        }

        public void WhichPlayersPiece(Cell cell, int i, int j)
        {
            if (CurrentPlayer == 1)
            {
                if (InsideBorder(i, j) == true)
                {
                    if (Board._area[i, j].State == State.WhiteKing || Board._area[i, j].State == State.WhiteKnight || Board._area[i, j].State == State.WhiteRook || Board._area[i, j].State == State.WhitePawn || Board._area[i, j].State == State.WhiteQueen || Board._area[i, j].State == State.WhiteBishop)
                        IsItWhitesPiece = true;
                    else
                        IsItWhitesPiece = false;
                }
            }
            else if (CurrentPlayer != 1)
            {
                if (InsideBorder(i, j) == true)
                {
                    if (Board._area[i, j].State == State.BlackKing || Board._area[i, j].State == State.BlackKnight || Board._area[i, j].State == State.BlackRook || Board._area[i, j].State == State.BlackPawn || Board._area[i, j].State == State.BlackQueen || Board._area[i, j].State == State.BlackBishop)
                        IsItWhitesPiece = false;
                    else
                        IsItWhitesPiece = true;
                }
            }
        }

        public MainViewModel()
        {
        }
    }
}