using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class MainForm : Form
    {
        private Game game;
        private Label[,] tileLabels;
        private ToolStripStatusLabel scoreLabel;
        private ToolStripMenuItem cancelMenuItem;

        public MainForm()
        {
            InitializeComponent();
            InitializeGameField();
            SetupMenu();
            SetupStatusBar();
            game = new Game();
            UpdateView();
        }

        private void InitializeGameField()
        {
            this.Text = "2048";
            this.ClientSize = new Size(436, 508);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.KeyPreview = true;

            tileLabels = new Label[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tileLabels[i, j] = new Label
                    {
                        Size = new Size(100, 100),
                        Location = new Point(j * 105 + 10, i * 105 + 50),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 24, FontStyle.Bold),
                        BackColor = Color.LightPink,
                        ForeColor = Color.Purple,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    this.Controls.Add(tileLabels[i, j]);
                }
            }
        }

        private void SetupMenu()
        {
            MenuStrip menu = new MenuStrip();

            ToolStripMenuItem gameMenu = new ToolStripMenuItem("Игра");

            ToolStripMenuItem newGameItem = new ToolStripMenuItem("Новая игра", null, (s, e) => StartNewGame());
            cancelMenuItem = new ToolStripMenuItem("Назад", null, (s, e) => CancelMove())
            {
                Enabled = false
            };
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход", null, (s, e) => this.Close());

            gameMenu.DropDownItems.AddRange(new ToolStripItem[] { newGameItem, cancelMenuItem, exitItem });
            menu.Items.Add(gameMenu);

            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
        }

        private void SetupStatusBar()
        {
            StatusStrip statusBar = new StatusStrip();
            scoreLabel = new ToolStripStatusLabel { Text = "Счет: 0" };
            statusBar.Items.Add(scoreLabel);
            this.Controls.Add(statusBar);
        }

        private void StartNewGame()
        {
            game.StartNewGame();
            UpdateView();
        }

        private void CancelMove()
        {
            game.Сancel();
            UpdateView();
        }

        private void UpdateView()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int value = game.Field[i, j];
                    tileLabels[i, j].Text = value == 0 ? "" : value.ToString();
                }
            }
            scoreLabel.Text = $"Счет: {game.Score}";
            cancelMenuItem.Enabled = game.CanСancel;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (game.IsGameOver) return;

            switch (e.KeyCode)
            {
                case Keys.Up: game.Move(Direction.Up); break;
                case Keys.Down: game.Move(Direction.Down); break;
                case Keys.Left: game.Move(Direction.Left); break;
                case Keys.Right: game.Move(Direction.Right); break;
                default: return;
            }

            UpdateView();

            if (game.IsGameOver)
                MessageBox.Show("Игра окончена! Ваш счет: " + game.Score);

        }
    }
}
