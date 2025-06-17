using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private const int gridsize = 4;
        private int[,] board = new int[gridsize, gridsize];
        private int[,] previousBoard = new int[gridsize, gridsize];
        private int previousScore;
        private Random rnd = new Random();
        private int score = 0;
        private bool canUndo = false;
        private bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Focus();
            this.KeyUp += Form1_KeyUp;
            ClearBoardUI();
        }

        private void ClearBoardUI()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label label && label.Name.StartsWith("label"))
                {
                    label.Text = "";
                }
            }
            toolStripStatusLabel1.Text = "Нажмите 'Новая игра'";
        }

        public void StartGame()
        {
            Array.Clear(board, 0, board.Length);
            score = 0;
            canUndo = false;
            gameStarted = true;
            AddRandomTile();
            AddRandomTile();
            UpdateUI();
            UpdateScore();
        }

        private void AddRandomTile()
        {
            var emptyTiles = board.Cast<int>()
                .Select((value, index) => new { value, index }).Where(x => x.value == 0)
                .ToArray();
            if (emptyTiles.Length > 0)
            {
                var randomTile = emptyTiles[rnd.Next(emptyTiles.Length)];
                board[randomTile.index / gridsize, randomTile.index % gridsize] = rnd.Next(0, 10) == 0 ? 4 : 2;
            }
        }

        private void UpdateUI()
        {
            if (!gameStarted) return;

            label00.Text = board[0, 0] == 0 ? "" : board[0, 0].ToString();
            label01.Text = board[0, 1] == 0 ? "" : board[0, 1].ToString();
            label02.Text = board[0, 2] == 0 ? "" : board[0, 2].ToString();
            label03.Text = board[0, 3] == 0 ? "" : board[0, 3].ToString();

            label10.Text = board[1, 0] == 0 ? "" : board[1, 0].ToString();
            label11.Text = board[1, 1] == 0 ? "" : board[1, 1].ToString();
            label12.Text = board[1, 2] == 0 ? "" : board[1, 2].ToString();
            label13.Text = board[1, 3] == 0 ? "" : board[1, 3].ToString();

            label20.Text = board[2, 0] == 0 ? "" : board[2, 0].ToString();
            label21.Text = board[2, 1] == 0 ? "" : board[2, 1].ToString();
            label22.Text = board[2, 2] == 0 ? "" : board[2, 2].ToString();
            label23.Text = board[2, 3] == 0 ? "" : board[2, 3].ToString();

            label30.Text = board[3, 0] == 0 ? "" : board[3, 0].ToString();
            label31.Text = board[3, 1] == 0 ? "" : board[3, 1].ToString();
            label32.Text = board[3, 2] == 0 ? "" : board[3, 2].ToString();
            label33.Text = board[3, 3] == 0 ? "" : board[3, 3].ToString();
        }

        private void UpdateScore()
        {
            if (!gameStarted) return;
            toolStripStatusLabel1.Text = $"Счёт: {score}";
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!gameStarted) return;

            bool moved = false;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Array.Copy(board, previousBoard, board.Length);
                previousScore = score;
            }

            switch (e.KeyCode)
            {
                case Keys.Up: moved = MoveUp(); break;
                case Keys.Down: moved = MoveDown(); break;
                case Keys.Left: moved = MoveLeft(); break;
                case Keys.Right: moved = MoveRight(); break;
            }

            if (moved)
            {
                canUndo = true;
                AddRandomTile();
                UpdateUI();
                UpdateScore();
                if (CheckGameOver())
                {
                    MessageBox.Show("Вы проиграли! \nСвободных ходов не осталось.");
                    gameStarted = false;
                    ClearBoardUI();
                }
            }
        }

        private bool CheckGameOver()
        {
            for (int row = 0; row < gridsize; row++)
            {
                for (int col = 0; col < gridsize; col++)
                {
                    if (board[row, col] == 0) return false;
                    if (col < gridsize - 1 && board[row, col] == board[row, col + 1]) return false;
                    if (row < gridsize - 1 && board[row, col] == board[row + 1, col]) return false;
                }
            }
            return true;
        }

        private bool MoveUp()
        {
            bool moved = false;
            for (int col = 0; col < gridsize; col++)
            {
                for (int row = 1; row < gridsize; row++)
                {
                    if (board[row, col] == 0) continue;
                    int target = row - 1;
                    while (target >= 0 && board[target, col] == 0)
                    {
                        target--;
                    }
                    if (target + 1 != row)
                    {
                        board[target + 1, col] = board[row, col];
                        board[row, col] = 0;
                        moved = true;
                    }
                    if (target >= 0 && board[target, col] == board[target + 1, col])
                    {
                        board[target, col] *= 2;
                        board[target + 1, col] = 0;
                        score += board[target, col];
                        moved = true;
                    }
                }
            }
            return moved;
        }

        private bool MoveDown()
        {
            bool moved = false;
            for (int col = 0; col < gridsize; col++)
            {
                for (int row = gridsize - 2; row >= 0; row--)
                {
                    if (board[row, col] == 0) continue;
                    int target = row + 1;
                    while (target < gridsize && board[target, col] == 0)
                    {
                        target++;
                    }
                    if (target - 1 != row)
                    {
                        board[target - 1, col] = board[row, col];
                        board[row, col] = 0;
                        moved = true;
                    }
                    if (target < gridsize && board[target, col] == board[target - 1, col])
                    {
                        board[target, col] *= 2;
                        board[target - 1, col] = 0;
                        score += board[target, col];
                        moved = true;
                    }
                }
            }
            return moved;
        }

        private bool MoveLeft()
        {
            bool moved = false;
            for (int row = 0; row < gridsize; row++)
            {
                for (int col = 1; col < gridsize; col++)
                {
                    if (board[row, col] == 0) continue;
                    int target = col - 1;
                    while (target >= 0 && board[row, target] == 0)
                    {
                        target--;
                    }
                    if (target + 1 != col)
                    {
                        board[row, target + 1] = board[row, col];
                        board[row, col] = 0;
                        moved = true;
                    }
                    if (target >= 0 && board[row, target] == board[row, target + 1])
                    {
                        board[row, target] *= 2;
                        board[row, target + 1] = 0;
                        score += board[row, target];
                        moved = true;
                    }
                }
            }
            return moved;
        }

        private bool MoveRight()
        {
            bool moved = false;
            for (int row = 0; row < gridsize; row++)
            {
                for (int col = gridsize - 2; col >= 0; col--)
                {
                    if (board[row, col] == 0) continue;
                    int target = col + 1;
                    while (target < gridsize && board[row, target] == 0)
                    {
                        target++;
                    }
                    if (target - 1 != col)
                    {
                        board[row, target - 1] = board[row, col];
                        board[row, col] = 0;
                        moved = true;
                    }
                    if (target < gridsize && board[row, target] == board[row, target - 1])
                    {
                        board[row, target] *= 2;
                        board[row, target - 1] = 0;
                        score += board[row, target];
                        moved = true;
                    }
                }
            }
            return moved;
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void возвратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameStarted) return;
            UndoMove();
        }

        private void UndoMove()
        {
            if (canUndo)
            {
                Array.Copy(previousBoard, board, board.Length);
                score = previousScore;
                UpdateUI();
                UpdateScore();
                canUndo = false;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
