using KR.DB.Service;
using System;

namespace KR
{
    internal class Game
    {
        public Account player {  get; set; }
        public int playRating { get; set; }
        public string isWin { get; set; }
        public GameService _service { get; set; }

        private int rows { get; set; }
        private int cols { get; set; }
        private int minesCount { get; set; }

        public Game(Account player, GameService service, int rows = 0, int cols = 0, int minesCount = 0)
        {
            this.player = player;
            _service = service;

            this.rows = rows;
            this.cols = cols;
            this.minesCount = minesCount;
        }

        public void StartGame()
        {
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Write rating: ");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Rating can`t be less than 0");
                playRating = int.Parse(Console.ReadLine());
            }

            char[,] field = InitializeField(rows, cols, minesCount);
            char[,] playerField = InitializePlayerField(rows, cols);

            bool gameOver = false;

            while (!gameOver)
            {
                DisplayField(playerField);

                int[] move = GetPlayerMove(rows, cols);
                int row = move[0];
                int col = move[1];

                if (field[row, col] == '*')
                {
                    _service.Create(this);
                    isWin = "lose";
                    player.LoseGame(this, player.UserName, isWin, player.GamesCount);
                    Console.WriteLine("Game end, you lose");
                    DisplayField(field);
                    gameOver = true;
                }
                else
                {
                    int minesCountAround = CountMinesAround(field, row, col);
                    playerField[row, col] = char.Parse(minesCountAround.ToString());

                    if (minesCountAround == 0)
                    {
                        RevealEmptyCells(field, playerField, row, col);
                    }

                    if (CheckWin(playerField, minesCount))
                    {
                        _service.Create(this);
                        isWin = "win";
                        player.WinGame(this, player.UserName, isWin, player.GamesCount);
                        Console.WriteLine("Game end, you win");
                        DisplayField(playerField);
                        gameOver = true;
                    }
                }
            }
        }

        private char[,] InitializeField(int rows, int cols, int minesCount)
        {
            char[,] field = new char[rows, cols];

            // Заповнення поля
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '0';
                }
            }

            // Розставлення мін
            Random random = new Random();
            int minesPlaced = 0;
            while (minesPlaced < minesCount)
            {
                int randomRow = random.Next(0, rows);
                int randomCol = random.Next(0, cols);

                if (field[randomRow, randomCol] != '*')
                {
                    field[randomRow, randomCol] = '*';
                    minesPlaced++;
                }
            }

            return field;
        }

        private char[,] InitializePlayerField(int rows, int cols)
        {
            char[,] playerField = new char[rows, cols];

            // Заповнення поля гравця
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playerField[i, j] = '-';
                }
            }

            return playerField;
        }

        private void DisplayField(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("Поле:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private int[] GetPlayerMove(int rows, int cols)
        {
            int[] move = new int[2];

            Console.Write($"Input row (0 to {rows - 1}): ");
            move[0] = int.Parse(Console.ReadLine());

            Console.Write($"Input column (0 to {cols - 1}): ");
            move[1] = int.Parse(Console.ReadLine());

            return move;
        }

        private int CountMinesAround(char[,] field, int row, int col)
        {
            int minesCount = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int i = Math.Max(0, row - 1); i <= Math.Min(row + 1, rows - 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(col + 1, cols - 1); j++)
                {
                    if (field[i, j] == '*')
                    {
                        minesCount++;
                    }
                }
            }

            return minesCount;
        }

        private void RevealEmptyCells(char[,] field, char[,] playerField, int row, int col)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int i = Math.Max(0, row - 1); i <= Math.Min(row + 1, rows - 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(col + 1, cols - 1); j++)
                {
                    if (playerField[i, j] == '-' && field[i, j] != '*')
                    {
                        int minesCountAround = CountMinesAround(field, i, j);
                        playerField[i, j] = char.Parse(minesCountAround.ToString());

                        if (minesCountAround == 0)
                        {
                            RevealEmptyCells(field, playerField, i, j);
                        }
                    }
                }
            }
        }

        private bool CheckWin(char[,] playerField, int minesCount)
        {
            int uncoveredCells = 0;
            int rows = playerField.GetLength(0);
            int cols = playerField.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (playerField[i, j] != '-' && playerField[i, j] != '*')
                    {
                        uncoveredCells++;
                    }
                }
            }

            return uncoveredCells == (rows * cols - minesCount);
        }

        public virtual int getPlayRating(Account player) { return playRating; }
    }
}
