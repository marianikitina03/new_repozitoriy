using System;
using System.Collections.Generic;

namespace Game2048
{
    public enum Direction { Up, Down, Left, Right }

    public class Game
    {
        private int[,] field = new int[4, 4];
        private Random random = new Random();
        private int[,] previousState;
        private int previousScore;
        private bool hasMoveToСancel;
        private bool wasСancelUsed;
        
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool CanСancel => hasMoveToСancel && !wasСancelUsed;
        public int[,] Field => (int[,])field.Clone();

        public Game()
        {
            AddRandomTile();
            AddRandomTile();
        }

        public void Move(Direction direction)
        {
            wasСancelUsed = false;
            previousState = (int[,])field.Clone();
            previousScore = Score;
            hasMoveToСancel = true;

            int[,] newField = (int[,])field.Clone();
            bool moved = false;

            switch (direction)
            {
                case Direction.Up: moved = MoveUp(newField); break;
                case Direction.Down: moved = MoveDown(newField); break;
                case Direction.Left: moved = MoveLeft(newField); break;
                case Direction.Right: moved = MoveRight(newField); break;
            }

            if (moved)
            {
                field = newField;
                AddRandomTile();
                CheckGameOver();
            }
            else
            {
                hasMoveToСancel = false;
            }
        }

        public void Сancel()
        {
            if (!CanСancel) return;

            field = (int[,])previousState.Clone();
            Score = previousScore;
            hasMoveToСancel = false;
            wasСancelUsed = true;
            IsGameOver = false;
        }

        private bool MoveUp(int[,] grid)
        {
            bool moved = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (grid[i, j] != 0)
                    {
                        int k = i;
                        while (k > 0 && grid[k - 1, j] == 0)
                        {
                            grid[k - 1, j] = grid[k, j];
                            grid[k, j] = 0;
                            k--;
                            moved = true;
                        }

                        if (k > 0 && grid[k - 1, j] == grid[k, j])
                        {
                            grid[k - 1, j] *= 2;
                            Score += grid[k - 1, j];
                            grid[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            return moved;
        }

        private bool MoveDown(int[,] grid)
        {
            bool moved = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (grid[i, j] != 0)
                    {
                        int k = i;
                        while (k < 3 && grid[k + 1, j] == 0)
                        {
                            grid[k + 1, j] = grid[k, j];
                            grid[k, j] = 0;
                            k++;
                            moved = true;
                        }

                        if (k < 3 && grid[k + 1, j] == grid[k, j])
                        {
                            grid[k + 1, j] *= 2;
                            Score += grid[k + 1, j];
                            grid[k, j] = 0;
                            moved = true;
                        }
                    }
                }
            }
            return moved;
        }

        private bool MoveLeft(int[,] grid)
        {
            bool moved = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (grid[i, j] != 0)
                    {
                        int k = j;
                        while (k > 0 && grid[i, k - 1] == 0)
                        {
                            grid[i, k - 1] = grid[i, k];
                            grid[i, k] = 0;
                            k--;
                            moved = true;
                        }

                        if (k > 0 && grid[i, k - 1] == grid[i, k])
                        {
                            grid[i, k - 1] *= 2;
                            Score += grid[i, k - 1];
                            grid[i, k] = 0;
                            moved = true;
                        }
                    }
                }
            }
            return moved;
        }

        private bool MoveRight(int[,] grid)
        {
            bool moved = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (grid[i, j] != 0)
                    {
                        int k = j;
                        while (k < 3 && grid[i, k + 1] == 0)
                        {
                            grid[i, k + 1] = grid[i, k];
                            grid[i, k] = 0;
                            k++;
                            moved = true;
                        }

                        if (k < 3 && grid[i, k + 1] == grid[i, k])
                        {
                            grid[i, k + 1] *= 2;
                            Score += grid[i, k + 1];
                            grid[i, k] = 0;
                            moved = true;
                        }
                    }
                }
            }
            return moved;
        }

        private void AddRandomTile()
        {
            List<(int, int)> emptyCells = new List<(int, int)>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == 0)
                    {
                        emptyCells.Add((i, j));
                    }
                }
            }

            if (emptyCells.Count > 0)
            {
                var (i, j) = emptyCells[random.Next(emptyCells.Count)];
                field[i, j] = random.Next(10) < 9 ? 2 : 4;
            }
        }

        private void CheckGameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (field[i, j] == 0)
                        return;

                    if (i < 3 && field[i, j] == field[i + 1, j])
                        return;

                    if (j < 3 && field[i, j] == field[i, j + 1])
                        return;
                }
            }
            IsGameOver = true;
        }

       
    }
}