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
        public static Board _board = new();
        private ICommand _newGameCommand;
        private ICommand _clearCommand;
        private ICommand _cellCommand;
        private ICommand _puzzlenext;
        private ICommand _puzzleprevious;
        private ICommand _puzzlecheck;
        private ICommand _selectedpuzzleshow;
        public int CurrentPuzzleNumber = 1;
        public string CurrentPuzzleName = "";
        public string WhiteCastledQueenSide = "false";
        public string WhiteCastledKingSide = "false";
        public string BlackCastledQueenSide = "false";
        public string BlackCastledKingSide = "false";

        public static IEnumerable<char> Numbers => "87654321";
        public static IEnumerable<char> Letters => "ABCDEFGH";

        public static int CurrentPlayer = 0;
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
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner2")
            {
                if (Board._area[0, 5].State == State.WhiteKing && Board._area[1, 1].State == State.WhiteRook && Board._area[0, 7].State == State.BlackKing && Board._area[2, 6].State == State.WhiteKnight)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner3")
            {
                if (Board._area[6, 1].State == State.WhiteBishop && Board._area[4, 3].State == State.BlackKing && Board._area[0, 7].State == State.BlackQueen)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner4")
            {
                if (Board._area[0, 4].State == State.BlackKing && Board._area[4, 2].State == State.WhiteBishop && Board._area[1, 5].State == State.WhiteQueen && Board._area[3, 3].State == State.Empty && Board._area[2, 4].State == State.Empty && Board._area[2, 7].State != State.BlackKnight)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner5")
            {
                if (Board._area[0, 7].State == State.WhitePawn && Board._area[1, 6].State == State.WhitePawn)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner6")
            {
                if (Board._area[7, 7].State == State.BlackRook && Board._area[6, 1].State == State.BlackRook && Board._area[7, 5].State == State.WhiteKing)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
            if (CurrentPuzzleName == "PuzzleBeginner7")
            {
                if (Board._area[1, 7].State == State.BlackBishop && Board._area[6, 0].State == State.BlackRook && Board._area[7, 0].State == State.WhiteKing && Board._area[4,1].State == State.BlackKnight)
                {
                    SuccessMessageBoxes();
                }
                else
                    FailureMessageBoxes();
            }
        });

        private void SuccessMessageBoxes()
        {
            if (CurrentLanguage == "English")
                MessageBox.Show("Correct!", "Puzzle was solved");
            else if (CurrentLanguage == "Russian")
                MessageBox.Show("Верно!", "Задача решена");
            else if (CurrentLanguage == "Korean")
                MessageBox.Show("맞아요!", "문제를 해결했습니다");
        }
        private void FailureMessageBoxes()
        {
            if (CurrentLanguage == "English")
                MessageBox.Show("Wrong, please try again", "Incorrect answer");
            else if (CurrentLanguage == "Russian")
                MessageBox.Show("Неверно, пожалуйста, попробуйте снова", "Ответ неверный");
            else if (CurrentLanguage == "Korean")
                MessageBox.Show("오답입니다. 다시 시도하십시오", "오답입니다.");
        }

        public ICommand SelectedPuzzleShow => _selectedpuzzleshow ??= new RelayCommand(parameter =>
        {
            PuzzlesWindow puzzles = new();
            CurrentPuzzleNumber = PuzzlesWindow.newpuzzle;
            PuzzlesShow();
        });

        public void PuzzlesShow()
        {
            if (CurrentPuzzleNumber == 1)
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
                PuzzlePlayerChanged();
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
                PuzzlePlayerChanged();
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
                PuzzlePlayerChanged();
            }
            else if (CurrentPuzzleNumber == 4)
            {
                CurrentPuzzleName = "PuzzleBeginner4";
                CurrentPlayer = 1;
                Board board = new();
                board[0, 0] = State.BlackRook;
                board[2, 2] = State.BlackKnight;
                board[0, 2] = State.BlackBishop;
                board[0, 3] = State.BlackQueen;
                board[0, 4] = State.BlackKing;
                board[0, 6] = State.BlackKnight;
                board[0, 7] = State.BlackRook;
                for (int i = 0; i < 8; i++)
                {
                    board[1, i] = State.BlackPawn;
                    board[6, i] = State.WhitePawn;
                }
                board[1, 6] = State.BlackBishop;
                board[2, 3] = State.Empty;
                board[6, 4] = State.Empty;
                board[1, 0] = State.Empty;
                board[2, 6] = State.BlackPawn;
                board[2, 0] = State.BlackPawn;
                board[3, 4] = State.BlackPawn;
                board[4, 4] = State.WhitePawn;
                board[7, 0] = State.WhiteRook;
                board[7, 1] = State.WhiteKnight;
                board[7, 2] = State.WhiteBishop;
                board[5, 5] = State.WhiteQueen;
                board[7, 4] = State.WhiteKing;
                board[4, 2] = State.WhiteBishop;
                board[6, 4] = State.WhiteKnight;
                board[7, 7] = State.WhiteRook;
                Board = board;
                PuzzlePlayerChanged();
            }
            else if (CurrentPuzzleNumber == 5)
            {
                CurrentPuzzleName = "PuzzleBeginner5";
                CurrentPlayer = 1;
                Board board = new();
                board[0, 0] = State.BlackRook;
                board[2, 2] = State.BlackKnight;
                board[4, 2] = State.BlackBishop;
                board[1, 6] = State.WhitePawn;
                board[1, 7] = State.WhitePawn;
                board[4, 1] = State.BlackPawn;
                board[7, 2] = State.WhiteKing;
                board[3, 5] = State.BlackKing;
                Board = board;
                PuzzlePlayerChanged();
            }
            else if (CurrentPuzzleNumber == 6)
            {
                CurrentPuzzleName = "PuzzleBeginner6";
                CurrentPlayer = 2;
                Board board = new();
                board[6, 1] = State.BlackRook;
                board[0, 7] = State.BlackRook;
                board[3, 2] = State.BlackBishop;
                board[3, 6] = State.BlackKing;
                board[7, 5] = State.WhiteKing;
                Board = board;
                PuzzlePlayerChanged();
            }
            else if (CurrentPuzzleNumber == 7)
            {
                CurrentPuzzleName = "PuzzleBeginner7";
                CurrentPlayer = 2;
                Board board = new();
                board[4, 1] = State.BlackKnight;
                board[1, 7] = State.BlackBishop;
                board[7, 0] = State.WhiteKing;
                board[2, 0] = State.BlackRook;
                board[1, 3] = State.BlackKing;
                board[6, 1] = State.WhitePawn;
                board[6, 0] = State.WhitePawn;
                board[6, 5] = State.WhiteQueen;
                board[3, 6] = State.WhitePawn;
                Board = board;
                PuzzlePlayerChanged();
            }
        }

        private void PuzzlePlayerChanged()
        {
            if (CurrentLanguage == "English")
            {
                if (CurrentPlayer == 1)
                    MessageBox.Show("Move: white");
                else if (CurrentPlayer == 2)
                    MessageBox.Show("Move: black");
            }
            else if (CurrentLanguage == "Russian")
            {
                if (CurrentPlayer == 1)
                    MessageBox.Show("Ход: белые");
                else if (CurrentPlayer == 2)
                    MessageBox.Show("Ход: чёрные");
            }
            else if (CurrentLanguage == "Korean")
            {
                if (CurrentPlayer == 1)
                    MessageBox.Show("무브: 하얀색");
                else if (CurrentPlayer == 2)
                    MessageBox.Show("무브: 검은색");
            }
        }

        public ICommand PuzzlePrevious => _puzzleprevious ??= new RelayCommand(parameter =>
        {
            if (CurrentPuzzleNumber == 0)
                CurrentPuzzleNumber = 6;
            else if (CurrentPuzzleNumber == 1)
            {
                CurrentPlayer = 1;
                CurrentPuzzleName = "PuzzleBeginner6";
                PuzzlesShow();
                CurrentPuzzleNumber = 7;
            }
            else if (CurrentPuzzleNumber == 2)
            {
                CurrentPuzzleName = "PuzzleBeginner1";
                CurrentPlayer = 2;
                PuzzlesShow();
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 3)
            {
                CurrentPlayer = 1;
                CurrentPuzzleName = "PuzzleBeginner2";
                PuzzlesShow();
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 4)
            {
                CurrentPuzzleName = "PuzzleBeginner4";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 5)
            {
                CurrentPuzzleName = "PuzzleBeginner5";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 6)
            {
                CurrentPuzzleName = "PuzzleBeginner6";
                CurrentPlayer = 2;
                PuzzlesShow();
                CurrentPuzzleNumber--;
            }
            else if (CurrentPuzzleNumber == 7)
            {
                CurrentPuzzleName = "PuzzleBeginner7";
                CurrentPlayer = 2;
                PuzzlesShow();
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
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 2)
            {
                CurrentPuzzleName = "PuzzleBeginner2";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 3)
            {
                CurrentPuzzleName = "PuzzleBeginner3";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 4)
            {
                CurrentPuzzleName = "PuzzleBeginner4";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 5)
            {
                CurrentPuzzleName = "PuzzleBeginner5";
                CurrentPlayer = 1;
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 6)
            {
                CurrentPuzzleName = "PuzzleBeginner6";
                CurrentPlayer = 2;
                PuzzlesShow();
                CurrentPuzzleNumber++;
            }
            else if (CurrentPuzzleNumber == 7)
            {
                CurrentPuzzleName = "PuzzleBeginner7";
                CurrentPlayer = 2;
                PuzzlesShow();
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
                else if (cell.PossibleMove == true && activeCell.State == State.WhitePawn && cell.RowNumber == 0)
                {
                    activeCell.Active = false;
                    cell.State = activeCell.State;
                    Board._area[cell.RowNumber, cell.ColumnNumber].State = State.WhiteQueen;
                    activeCell.State = State.Empty;
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    SwitchPlayer();
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
                else if (cell.PossibleMove == true && activeCell.State == State.BlackPawn && cell.RowNumber == 7)
                {
                    activeCell.Active = false;
                    cell.State = activeCell.State;
                    Board._area[cell.RowNumber, cell.ColumnNumber].State = State.BlackQueen;
                    activeCell.State = State.Empty;
                    DeleteMarks(cell.RowNumber, cell.ColumnNumber);
                    SwitchPlayer();
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
                                else if (IsItWhitesPiece == true && i != cell.RowNumber && j != cell.ColumnNumber)
                                    i = i + 8;
                            }
                        }
                        break;

                    case State.WhiteKing:
                        i = cell.RowNumber;
                        j = cell.ColumnNumber;
                        if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State == State.Empty)
                        {
                            Board._area[i - 1, j].PossibleMove = true;
                        }
                        else if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i - 1, j);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State == State.Empty)
                        {
                            Board._area[i + 1, j].PossibleMove = true;
                        }
                        else if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i + 1, j);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State == State.Empty)
                        {
                            Board._area[i, j - 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i, j - 1].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State == State.Empty)
                        {
                            Board._area[i, j + 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i, j + 1].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State == State.Empty)
                        {
                            Board._area[i - 1, j - 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i - 1, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j - 1].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State == State.Empty)
                        {
                            Board._area[i + 1, j + 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i + 1, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j + 1].PossibleMove = true;
                            }
                        }

                        if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State == State.Empty)
                        {
                            Board._area[i - 1, j + 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i - 1, j + 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i - 1, j + 1].PossibleMove = true;
                            }
                        }
                        if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State == State.Empty)
                        {
                            Board._area[i + 1, j - 1].PossibleMove = true;
                        }
                        else if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State != State.Empty)
                        {
                            WhichPlayersPiece(cell, i + 1, j - 1);
                            if (IsItWhitesPiece == false)
                            {
                                Board._area[i + 1, j - 1].PossibleMove = true;
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

                                WhichPlayersPiece(cell, cell.RowNumber - 2, cell.ColumnNumber);
                                if (Board._area[cell.RowNumber - 2, cell.ColumnNumber].State == State.Empty)
                                {
                                    if (InsideBorder(cell.RowNumber - 2, cell.ColumnNumber))
                                    {
                                        Board._area[cell.RowNumber - 2, cell.ColumnNumber].PossibleMove = true;
                                    }
                                }
                            }
                        }
                        else if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber) == true && cell.RowNumber != 6 && Board._area[cell.RowNumber - 1, cell.ColumnNumber].State == State.Empty)
                        {
                            Board._area[cell.RowNumber - 1, cell.ColumnNumber].PossibleMove = true;

                        }
                        if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber - 1) == true)
                        {
                            WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber - 1);
                            if (IsItWhitesPiece == false && Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].State != State.Empty)
                            {
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber - 1].PossibleMove = true;
                            }
                        }
                        if (InsideBorder(cell.RowNumber - 1, cell.ColumnNumber + 1) == true)
                        {
                            WhichPlayersPiece(cell, cell.RowNumber - 1, cell.ColumnNumber + 1);
                            if (IsItWhitesPiece == false && Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].State != State.Empty)
                            {
                                Board._area[cell.RowNumber - 1, cell.ColumnNumber + 1].PossibleMove = true;
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
                                    if (Board._area[i, j].State != State.Empty)
                                    {
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
                        case State.BlackKing:
                            i = cell.RowNumber;
                            j = cell.ColumnNumber;
                            if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State == State.Empty)
                            {
                                Board._area[i - 1, j].PossibleMove = true;
                            }
                            else if (InsideBorder(i - 1, j) == true && Board._area[i - 1, j].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i - 1, j);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State == State.Empty)
                            {
                                Board._area[i + 1, j].PossibleMove = true;
                            }
                            else if (InsideBorder(i + 1, j) == true && Board._area[i + 1, j].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i + 1, j);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State == State.Empty)
                            {
                                Board._area[i, j - 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i, j - 1) == true && Board._area[i, j - 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i, j - 1].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State == State.Empty)
                            {
                                Board._area[i, j + 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i, j + 1) == true && Board._area[i, j + 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i, j + 1].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State == State.Empty)
                            {
                                Board._area[i - 1, j - 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i - 1, j - 1) == true && Board._area[i - 1, j - 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i - 1, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j - 1].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State == State.Empty)
                            {
                                Board._area[i + 1, j + 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i + 1, j + 1) == true && Board._area[i + 1, j + 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i + 1, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j + 1].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State == State.Empty)
                            {
                                Board._area[i - 1, j + 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i - 1, j + 1) == true && Board._area[i - 1, j + 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i - 1, j + 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i - 1, j + 1].PossibleMove = true;
                                }
                            }
                            if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State == State.Empty)
                            {
                                Board._area[i + 1, j - 1].PossibleMove = true;
                            }
                            else if (InsideBorder(i + 1, j - 1) == true && Board._area[i + 1, j - 1].State != State.Empty)
                            {
                                WhichPlayersPiece(cell, i + 1, j - 1);
                                if (IsItWhitesPiece == true)
                                {
                                    Board._area[i + 1, j - 1].PossibleMove = true;
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
                                        if (Board._area[cell.RowNumber + 2, cell.ColumnNumber].State == State.Empty)
                                        {
                                            if (InsideBorder(cell.RowNumber + 2, cell.ColumnNumber))
                                            {
                                                Board._area[cell.RowNumber + 2, cell.ColumnNumber].PossibleMove = true;
                                            }
                                        }
                                    }
                                }
                                else if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber) == true && cell.RowNumber != 1 && Board._area[cell.RowNumber + 1, cell.ColumnNumber].State == State.Empty)
                                {
                                    Board._area[cell.RowNumber + 1, cell.ColumnNumber].PossibleMove = true;
                                }
                                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber - 1) == true)
                                {
                                    WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber - 1);
                                    if (IsItWhitesPiece == true && Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].State != State.Empty)
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber - 1].PossibleMove = true;
                                    }
                                }
                                if (InsideBorder(cell.RowNumber + 1, cell.ColumnNumber + 1) == true)
                                {
                                    WhichPlayersPiece(cell, cell.RowNumber + 1, cell.ColumnNumber + 1);
                                    if (IsItWhitesPiece == true && Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].State != State.Empty)
                                    {
                                        Board._area[cell.RowNumber + 1, cell.ColumnNumber + 1].PossibleMove = true;
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