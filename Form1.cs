using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Security.AccessControl;
using System.Security.Claims;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private List<List<Tile>> tiles;

        private int uncoveredCount;

        private Image bombImage;
        private Image flagImage;

        const int WIDTH = 20;
        const int HEIGHT = 10;
        const int totalCount = WIDTH * HEIGHT;

        int bombCount = 20;

        public Form1()
        {
            bombImage = Image.FromFile("res\\BombIcon.png");
            flagImage = Image.FromFile("res\\Flag.png");

            InitializeComponent();

            tiles = new List<List<Tile>>();

            uncoveredCount = 0;

            for (int j = 0; j < field.RowCount; j++)
            {
                tiles.Add(new List<Tile>());
                for (int i = 0; i < field.ColumnCount; i++)
                {
                    field.Controls.Add(new Button() { Size = new Size(32, 32) });
                    tiles.Last().Add(new Tile(0));

                    Button? tile = field.GetControlFromPosition(i, j) as Button;
                    if (tile == null)
                        throw new Exception("aaaaaaaaaaaaaaaaaaa");

                    tile.Tag = (i, j).ToString();
                    tile.FlatStyle = FlatStyle.Flat;
                    tile.Font = new Font("Segoe UI Black", 10);
                    tile.BackgroundImageLayout = ImageLayout.Zoom;

                    if (tiles.Last().Last().IsBomb()) // LOL
                    {
                        tile.BackgroundImage = bombImage;
                    }

                    tile.MouseUp += Tile_Click;
                }

                int bombs = 0;
                foreach (Tile tile in tiles.Last())
                    if (tile.IsBomb())
                        bombs++;

                Console.WriteLine(bombs);
            }


            ResetField();
        }

        private void ResetField()
        {
            for (int i = 0; i < field.RowCount; i++)
            {
                for (int j = 0; j <  field.ColumnCount; j++)
                {
                    tiles[i][j].Disarm();
                }
            }

            foreach (Button tile in field.Controls)
            {
                tile.ForeColor = Color.Silver;
            }

            Random random = new Random();
            for (int i = 0; i < bombCount; i++)
            {
                int x = random.Next(20);
                int y = random.Next(10);

                if (tiles[y][x].IsBomb())
                {
                    i--;
                    continue;
                }

                tiles[y][x].ArmForSure();
            }




            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    UncheckTile(i, j);
                }
            }


            UpdateThreatIndicators();

            uncoveredCount = 0; // again because of this ^
        }


        private void CheckTile_Wrapped(int x, int y)
        {
            if (tiles[x][y].ThreatIndicator > 0)
                CheckTile(x, y);
            else
                CheckEmptyTile(x, y);
        }



        private void CheckTile(int x, int y)
        {
            var tile = field.GetControlFromPosition(y, x) ?? throw new Exception("tile position out of range");
            var vtile = tiles[x][y]; // virutal tile aka tile data (Tile class)

            if (vtile.Checked)
                return;

            vtile.Checked = true;
            uncoveredCount++;

            Console.WriteLine(uncoveredCount);

            if (vtile.ThreatIndicator != 0 && !vtile.IsBomb())
            {
                tile.Text = vtile.ThreatIndicator.ToString();

                switch (vtile.ThreatIndicator)
                {
                    case 0:
                        tile.ForeColor = Color.White;
                        break;
                    case 1:
                        tile.ForeColor = Color.Blue;
                        break;
                    case 2:
                        tile.ForeColor = Color.Green;
                        break;
                    case 3:
                        tile.ForeColor = Color.Red;
                        break;
                    case 4:
                        tile.ForeColor = Color.DarkBlue;
                        break;
                    case 5:
                        tile.ForeColor = Color.Brown;
                        break;
                    case 6:
                        tile.ForeColor = Color.Cyan;
                        break;
                    case 7:
                        tile.ForeColor = Color.DarkRed;
                        break;
                    case 8:
                        tile.ForeColor = Color.Black;
                        break;
                    case 9:
                        // LMAO
                        break;
                    default:
                        tile.ForeColor = Color.White;
                        break;
                }
            }

            if (vtile.IsBomb())
                tile.BackgroundImage = bombImage;
            else
                tile.BackgroundImage = null;

            tile.BackColor = Color.White;
        }



        private void UncheckTile(int x, int y)
        {
            var tile = field.GetControlFromPosition(y, x) ?? throw new Exception("tile position out of range");
            var vtile = tiles[x][y]; // virutal tile aka tile data (Tile class)
            vtile.Checked = false;
            vtile.Flagged = false;

            uncoveredCount--;

            tile.Text = string.Empty;
            tile.BackgroundImage = null;
            //tile.BackColor = Color.FromKnownColor(KnownColor.Control);
            tile.BackColor = Color.Silver;
        }



        private void FlagTile(int x, int y)
        {
            var tile = field.GetControlFromPosition(y, x) ?? throw new Exception("tile position out of range");
            var vtile = tiles[x][y]; // virutal tile aka tile data (Tile class)

            if (vtile.Checked)
                return;

            if (!vtile.Flagged)
                tile.BackgroundImage = flagImage;
            else
                tile.BackgroundImage = null;

            vtile.Flagged = !vtile.Flagged;
        }


        private void UpdateThreatIndicators()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (tiles[i][j].IsBomb())
                    {
                        for (int k = i - 1; k <= i + 1; k++)
                        {
                            for (int l = j - 1; l <= j + 1; l++)
                            {
                                if (k == i && l == j)
                                    continue;

                                if (k < 0 || k >= HEIGHT)
                                    continue;

                                if (l < 0 || l >= WIDTH)
                                    continue;

                                tiles[k][l].ThreatIndicator++;
                            }
                        }
                    }
                }
            }
        }


        void CheckEmptyTile(int i, int j)
        {
            if (tiles[i][j].Checked)
            {
                return;
            }

            CheckTile(i, j);

            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (k == i && l == j)
                        continue;

                    if (k < 0 || k >= HEIGHT)
                        continue;

                    if (l < 0 || l >= WIDTH)
                        continue;

                    if (tiles[i][j].ThreatIndicator > 0)
                        continue;

                    CheckEmptyTile(k, l);
                }
            }
        }



        int AutoCheckTiles()
        {
            Random random = new Random();
            int changesCount = 0;

            if (uncoveredCount == 0)
            {
                CheckTile_Wrapped(random.Next(10), random.Next(20));
                return -1;
            }


            for (int n = 1; n < 9; n++)
            {
                // flag possible bombs for [n] corners
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if (!tiles[i][j].Checked)
                            continue;

                        if (tiles[i][j].ThreatIndicator == n)
                        {
                            int hiddenCount = 0;
                            List<(int, int)> pos = new List<(int, int)>();

                            for (int k = i - 1; k <= i + 1; k++)
                            {
                                for (int l = j - 1; l <= j + 1; l++)
                                {
                                    if (k == i && l == j)
                                        continue;

                                    if (k < 0 || k >= HEIGHT)
                                        continue;

                                    if (l < 0 || l >= WIDTH)
                                        continue;

                                    if (!tiles[k][l].Checked || tiles[k][l].Flagged)
                                    {
                                        hiddenCount++;
                                        pos.Add((k, l));
                                    }
                                }
                            }

                            if (hiddenCount == n)
                            {
                                foreach (var itr in pos)
                                {
                                    if (!tiles[itr.Item1][itr.Item2].Flagged)
                                        FlagTile(itr.Item1, itr.Item2);
                                }
                            }
                        }
                    }
                }

                // solve for [n]
                for (int i = 0; i < HEIGHT; i++)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        if (!tiles[i][j].Checked)
                            continue;

                        if (tiles[i][j].ThreatIndicator == n)
                        {
                            int flaggedCount = 0;

                            for (int k = i - 1; k <= i + 1; k++)
                            {
                                for (int l = j - 1; l <= j + 1; l++)
                                {
                                    if (k == i && l == j)
                                        continue;

                                    if (k < 0 || k >= HEIGHT)
                                        continue;

                                    if (l < 0 || l >= WIDTH)
                                        continue;

                                    if (tiles[k][l].Flagged)
                                    {
                                        flaggedCount++;
                                    }
                                }
                            }

                            if (flaggedCount == n)
                            {
                                for (int k = i - 1; k <= i + 1; k++)
                                {
                                    for (int l = j - 1; l <= j + 1; l++)
                                    {
                                        if (k == i && l == j)
                                            continue;

                                        if (k < 0 || k >= HEIGHT)
                                            continue;

                                        if (l < 0 || l >= WIDTH)
                                            continue;

                                        if (!tiles[k][l].Flagged && !tiles[k][l].Checked)
                                        {
                                            CheckTile_Wrapped(k, l);
                                            changesCount++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return changesCount;
        }


        void PrintDebugInfo(int i, int j)
        {
            int hiddenCount = 0;

            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (k == i && l == j)
                        continue;

                    if (k < 0 || k >= HEIGHT)
                        continue;

                    if (l < 0 || l >= WIDTH)
                        continue;

                    if (!tiles[k][l].Checked || tiles[k][l].Flagged)
                    {
                        hiddenCount++;
                    }
                }
            }

            Console.Write("TILE ({0}, {1}): ", i, j);
            Console.WriteLine(hiddenCount);
        }



        private void Tile_Click(object? sender, MouseEventArgs e)
        {
            //MouseEventArgs? me = e as MouseEventArgs;

            //if (me == null)
            //    return;

            Button? tile = sender as Button;

            var pos = field.GetPositionFromControl(tile);

            if (e.Button == MouseButtons.Right)
            {
                FlagTile(pos.Row, pos.Column);
            }
            else if (e.Button == MouseButtons.Left)
            {
                //if (tiles[pos.Row][pos.Column].ThreatIndicator > 0)
                //    CheckTile(pos.Row, pos.Column);
                //else
                //    CheckEmptyTile(pos.Row, pos.Column);
                CheckTile_Wrapped(pos.Row, pos.Column);

            }
            else if (e.Button == MouseButtons.Middle)
            {
                PrintDebugInfo(pos.Row, pos.Column);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (AutoCheckTiles() == 0)
                timer1.Stop();
        }

        private void autoSolveButton_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetField();
        }
    }
}