/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gibbed.Dredmor.Maximap
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            this.InitializeComponent();

            this._MapPictureBox.Width = 1;
            this._MapPictureBox.Height = 1;
        }

        private Game.State _State;
        private int _Scale = 1;
        private Bitmap _Minimap;
        private Bitmap _Overlay;

        private void UpdateState()
        {
            var selectedRooms = new List<byte>();
            if (this._RoomListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._RoomListView.SelectedItems)
                {
                    selectedRooms.Add((byte)item.Tag);
                }
            }

            var selectedQuestItems = new List<uint>();
            if (this._QuestItemListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._QuestItemListView.SelectedItems)
                {
                    selectedQuestItems.Add((uint)item.Tag);
                }
            }

            var selectedMonsters = new List<uint>();
            if (this._MonsterListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._MonsterListView.SelectedItems)
                {
                    selectedMonsters.Add((uint)item.Tag);
                }
            }

            this.toolStripStatusLabel1.Text = "";
            this.toolStripStatusLabel2.Text = "";

            this._RoomListView.Items.Clear();
            this._MonsterListView.Items.Clear();
            this._QuestItemListView.Items.Clear();

            if (this._State != null)
            {
                var level = this._State.CurrentLevel;

                if (level == null)
                {
                    this._MapPictureBox.Width = 32;
                    this._MapPictureBox.Height = 32;
                }
                else
                {
                    var visibleRooms = new List<int>();
                    var visibleQuestItems = new List<uint>();
                    var visibleMonsters = new List<uint>();

                    for (int y = 0; y < level.Height; y++)
                    {
                        for (int x = 0; x < level.Width; x++)
                        {
                            var square = level.Squares[x, y];

                            if (this._CheatButton.Checked == true ||
                                square.Unknown14 != 0 ||
                                square.Unknown20 != 0)
                            {
                                if (visibleRooms.Contains(square.Room) == false)
                                {
                                    visibleRooms.Add(square.Room);

                                    this._RoomListView.Items.Add(new ListViewItem()
                                    {
                                        Text = level.RoomNames[square.Room],
                                        Tag = square.Room,
                                        Selected = selectedRooms.Contains(square.Room),
                                    });
                                }

                                if (square.QuestItem.HasValue == true &&
                                    visibleQuestItems.Contains(square.QuestItem.Value) == false)
                                {
                                    visibleQuestItems.Add(square.QuestItem.Value);

                                    this._QuestItemListView.Items.Add(new ListViewItem()
                                    {
                                        Text = square.QuestItemName,
                                        Tag = square.QuestItem.Value,
                                        Selected = selectedQuestItems.Contains(square.QuestItem.Value),
                                    });
                                }

                                if (square.BossMonster.HasValue == true &&
                                    visibleMonsters.Contains(square.BossMonster.Value) == false)
                                {
                                    visibleMonsters.Add(square.BossMonster.Value);

                                    this._MonsterListView.Items.Add(new ListViewItem()
                                    {
                                        Text = square.BossMonsterName,
                                        Tag = square.BossMonster.Value,
                                        Selected = selectedMonsters.Contains(square.BossMonster.Value),
                                    });
                                }
                            }
                        }
                    }

                    if (this._State.Player != null)
                    {
                        var player = this._State.Player;
                        var square = level.Squares[player.X, player.Y];
                        this.toolStripStatusLabel2.Text = level.RoomNames[square.Room];
                    }

                    this.toolStripStatusLabel1.Text = string.Format("Level {0}", 1 + level.Floor);
                }
            }
        }

        private static Color ColorForSquare(Game.Square square, bool highlight)
        {
            if (square.QuestItem.HasValue == true)
            {
                return Color.Violet;
            }

            if (square.BossMonster.HasValue == true)
            {
                return Color.Tomato;
            }

            if (square.HasDredmorStatue == true ||
                square.HasUberChest == true)
            {
                return Color.Gold;
            }

            switch (square.Tile)
            {
                case Game.Tile.Blank: return Color.Transparent;
                case Game.Tile.Floor: return highlight == false ? Color.Gray : Color.LightGray;
                case Game.Tile.Door: return highlight == false ? Color.Gray : Color.LightGray;
                case Game.Tile.Wall: return highlight == false ? Color.DarkGray : Color.GhostWhite;
                case Game.Tile.StairsUp: return Color.Yellow;
                case Game.Tile.StairsDown: return Color.Orange;
                case Game.Tile.Water: return Color.DarkBlue;
                case Game.Tile.Lava: return Color.DarkRed;
                case Game.Tile.Shop: return Color.Magenta;
                case Game.Tile.Zoo: return Color.Aqua;
                case Game.Tile.Goo: return Color.DarkGreen;

                case Game.Tile.Unknown5:
                case Game.Tile.Unknown10:
                case Game.Tile.Unknown11:
                case Game.Tile.Unknown12: return Color.Olive;
            }

            return Color.Lime;
        }

        private void RenderLevel()
        {
            if (this._Minimap != null)
            {
                this._Minimap.Dispose();
                this._Minimap = null;
            }

            var selectedRooms = new List<byte>();
            if (this._RoomListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._RoomListView.SelectedItems)
                {
                    selectedRooms.Add((byte)item.Tag);
                }
            }

            var selectedQuestItems = new List<uint>();
            if (this._QuestItemListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._QuestItemListView.SelectedItems)
                {
                    selectedQuestItems.Add((uint)item.Tag);
                }
            }

            var selectedMonsters = new List<uint>();
            if (this._MonsterListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this._MonsterListView.SelectedItems)
                {
                    selectedMonsters.Add((uint)item.Tag);
                }
            }

            if (this._State != null)
            {
                var level = this._State.CurrentLevel;

                if (level == null)
                {
                    this._MapPictureBox.Width = 32;
                    this._MapPictureBox.Height = 32;
                }
                else
                {
                    var visibleRooms = new List<int>();
                    var visibleQuestItems = new List<uint>();
                    var visibleMonsters = new List<uint>();

                    var crosshairs = new List<Point>();

                    for (int y = 0; y < level.Height; y++)
                    {
                        for (int x = 0; x < level.Width; x++)
                        {
                            var square = level.Squares[x, y];

                            if (this._CheatButton.Checked == true ||
                                square.Unknown14 != 0 ||
                                square.Unknown20 != 0)
                            {
                                if (visibleRooms.Contains(square.Room) == false)
                                {
                                    visibleRooms.Add(square.Room);
                                }

                                if (square.QuestItem.HasValue == true &&
                                    selectedQuestItems.Contains(square.QuestItem.Value) == true)
                                {
                                    var point = new Point(x, y);
                                    if (crosshairs.Contains(point) == false)
                                    {
                                        crosshairs.Add(point);
                                    }
                                }

                                if (square.BossMonster.HasValue == true &&
                                    selectedMonsters.Contains(square.BossMonster.Value) == true)
                                {
                                    var point = new Point(x, y);
                                    if (crosshairs.Contains(point) == false)
                                    {
                                        crosshairs.Add(point);
                                    }
                                }
                            }
                        }
                    }

                    var bitmap = new Bitmap(level.Width, level.Height);
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.Transparent);

                        for (int y = 0; y < level.Height; y++)
                        {
                            for (int x = 0; x < level.Width; x++)
                            {
                                var square = level.Squares[x, y];

                                if (this._CheatButton.Checked == true ||
                                    square.Unknown14 != 0 ||
                                    square.Unknown20 != 0)
                                {
                                    var color = ColorForSquare(square, selectedRooms.Contains(square.Room));
                                    bitmap.SetPixel(x, y, color);
                                }
                            }
                        }

                        var crosshair = new Pen(Color.White);
                        foreach (var point in crosshairs)
                        {
                            // top left
                            g.DrawLine(crosshair, point.X - 2, point.Y - 1, point.X - 2, point.Y - 2);
                            g.DrawLine(crosshair, point.X - 1, point.Y - 2, point.X - 2, point.Y - 2);

                            // bottom left
                            g.DrawLine(crosshair, point.X - 2, point.Y + 1, point.X - 2, point.Y + 2);
                            g.DrawLine(crosshair, point.X - 1, point.Y + 2, point.X - 2, point.Y + 2);

                            // top right
                            g.DrawLine(crosshair, point.X + 2, point.Y - 1, point.X + 2, point.Y - 2);
                            g.DrawLine(crosshair, point.X + 1, point.Y - 2, point.X + 2, point.Y - 2);

                            // bottom right
                            g.DrawLine(crosshair, point.X + 2, point.Y + 1, point.X + 2, point.Y + 2);
                            g.DrawLine(crosshair, point.X + 1, point.Y + 2, point.X + 2, point.Y + 2);
                        }

                        if (this._State.Player != null)
                        {
                            var player = this._State.Player;
                            bitmap.SetPixel(player.X, player.Y, Color.White);
                        }
                    }

                    this._Minimap = bitmap;
                }
            }
        }

        private void PaintLevel()
        {
            if (this._Minimap == null)
            {
                this._MapPictureBox.Width = 1;
                this._MapPictureBox.Height = 1;
                this._MapPictureBox.Image = null;
            }
            else
            {
                this._MapPictureBox.Width = this._Minimap.Width * this._Scale;
                this._MapPictureBox.Height = this._Minimap.Height * this._Scale;

                var bitmap = new Bitmap(this._MapPictureBox.Width, this._MapPictureBox.Height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.SmoothingMode = SmoothingMode.None;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.Clear(Color.Transparent);
                    g.DrawImage(this._Minimap, 0, 0, bitmap.Width, bitmap.Height);
                }

                this._MapPictureBox.Image = bitmap;
            }
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            this._State = Game.State.ReadState();
            this.UpdateState();
            this.RenderLevel();
            this.PaintLevel();
        }

        private void OnChangeScale(object sender, EventArgs e)
        {
            if (sender == this._ZoomInButton)
            {
                this._Scale = Math.Min(100, this._Scale + 1);
            }
            else if (sender == this._ZoomOutButton)
            {
                this._Scale = Math.Max(1, this._Scale - 1);
            }
            else if (sender == this._ZoomActualButton)
            {
                this._Scale = 1;
            }

            this._ZoomInButton.Enabled = this._Scale < 100;
            this._ZoomOutButton.Enabled = this._Scale > 1;
            this.PaintLevel();
        }

        private void _CheatButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateState();
            this.RenderLevel();
            this.PaintLevel();
        }

        private void OnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.RenderLevel();
            this.PaintLevel();
        }
    }
}
