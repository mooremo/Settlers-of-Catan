using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SettlersOfCatan.Properties;

namespace SettlersOfCatan
{
    public partial class frm_gameBoard : Form
    {
        private readonly float _radius = 50f;
        private Pen _pen = new Pen(Color.Black, 5);
        private List<int> seaTileIndices = new List<int>(new int[] {1,2,6,9,20,23,31,33,36});
        private List<int> portTileIndices = new List<int>(new int[] { 0, 3, 5, 13, 16, 27, 30, 34, 35});
        private int _tileCount = 0;
        private int _portCount = 0;
        private int _terrainCount = 0;
        private Board _board;
        private List<Vertex> _doIAddAShittyButtonHere = new List<Vertex>();


        public frm_gameBoard()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            _board = new Board();
        }

        private void frm_gameBoard_Shown(object sender, EventArgs e)
        {
            DrawRowOne(new PointF((float)(Width / 2.0), (float)((Height - (14 * _radius)) / 4.0) + _radius), 1);
        }

        private PointF[] GetHexagonPoints(PointF center, float radius)
        {
            var ret = new PointF[6];
            var count = 0;
            for (var i = 1; i > -5; i--)
            {
                ret[count++] = new PointF((float) (center.X + radius * Math.Cos(Math.PI * i / 3)), (float) (center.Y - radius * Math.Sin(Math.PI * i / 3)));
            }

            return ret;
        }

        private PointF ShiftDownLeft(PointF old)
        {
            return new PointF((float)(old.X - (1.5*_radius)), (float) (old.Y + (Math.Cos(Math.PI/6)*_radius)));
        }

        private PointF ShiftDownRight(PointF old)
        {
            return new PointF((float)(old.X + (1.5 * _radius)), (float)(old.Y + (Math.Cos(Math.PI / 6) * _radius)));
        }

        private PointF ShiftRight(PointF old)
        {
            return new PointF((float) (old.X + (3*_radius)), old.Y);
        }

        private void DrawHexesOnRow(PointF seed, int numOnRow)
        {
            Bitmap image;
            TextureBrush brush;
            Button tileBtn;
            var point = new PointF(seed.X, seed.Y);
            
            for (var i = 0; i < numOnRow; i++)
            {
                var hexagonPoints = GetHexagonPoints(point, _radius);
                CreateGraphics().DrawPolygon(_pen, hexagonPoints);
                image = GetImage();
                Button b = GetButton(image, new PointF(hexagonPoints[5].X, hexagonPoints[0].Y));
                DrawVertexButtons(hexagonPoints);
                if (b != null)
                {
                    this.Controls.Add(b);
                }
                brush = new TextureBrush(image);
                CreateGraphics().FillPolygon(brush, hexagonPoints, FillMode.Alternate);
                point = ShiftRight(point);
            }
        }

        private void DrawRowOne(PointF seed, int row)
        {
            DrawHexesOnRow(seed, 1);
            var nextSeed = ShiftDownLeft(seed);
            if (row != 13)
            {
                DrawRowTwo(nextSeed, row+1);
            }
        }

        private void DrawRowTwo(PointF seed, int row)
        {
            DrawHexesOnRow(seed, 2);
            if (row == 12)
            {
                DrawRowOne(ShiftDownRight(seed), row+1);
            }
            else
            {

                DrawRowThree(ShiftDownLeft(seed), row+1);
            }
        }

        private void DrawRowThree(PointF seed, int row)
        {
            DrawHexesOnRow(seed, 3);
            if (row == 11)
            {
                DrawRowTwo(ShiftDownRight(seed), row+1);
            }
            else
            {
                DrawRowFour(ShiftDownLeft(seed), row+1);
            }
        }

        private void DrawRowFour(PointF seed, int row)
        {
            DrawHexesOnRow(seed, 4);
            DrawRowThree(ShiftDownRight(seed), row+1);
        }
        
        private Bitmap GetImage()
        {
            Bitmap image;
            if (seaTileIndices.Contains(_tileCount))
            {
                image = new Bitmap(Resources.sea_texture);
            }
            else if (portTileIndices.Contains(_tileCount))
            {
                image = new Bitmap(Resources.sea_texture);
                _portCount++;
            }
            else
            {
                switch ((_board.TerrainTiles[_terrainCount]).Type)
                {
                    case (int)TileType.Desert:
                        image = new Bitmap(Resources.desert_texture);
                        break;
                    case (int)TileType.Fields:
                        image = new Bitmap(Resources.field_texture);
                        break;
                    case (int)TileType.Hills:
                        image = new Bitmap(Resources.hills_texture);
                        break;
                    case (int)TileType.Mountains:
                        image = new Bitmap(Resources.mountains_texture);
                        break;
                    case (int)TileType.Pasture:
                        image = new Bitmap(Resources.pasture_texture);
                        break;
                    case (int)TileType.Woods:
                        image = new Bitmap(Resources.woods_texture);
                        break;
                    default:
                        image = new Bitmap(Resources.sea_texture);
                        break;
                }
                _terrainCount++;
            }
            return image;
        }

        private Button GetButton(Bitmap image, PointF point)
        {
            Button b = new Button();
            if (seaTileIndices.Contains(_tileCount))
            {
                _tileCount++;
                return null;
            }
            else if (portTileIndices.Contains(_tileCount))
            {
                switch((_board.PortTiles[_portCount-1]).Type)
                {
                    case (int)TileType.Port2Brick:
                        b.Text = "2:1 Brick";
                        break;
                    case (int) TileType.Port2Grain:
                        b.Text = "2:1 Grain";
                        break;
                    case (int) TileType.Port2Lumber:
                        b.Text = "2:1 Lumber";
                        break;
                    case (int) TileType.Port2Ore:
                        b.Text = "2:1 Ore";
                        break;
                    case (int) TileType.Port2Wool:
                        b.Text = "2:1 Wool";
                        break;
                    case (int)TileType.Port3:
                        b.Text = "3:1";
                        break;
                    default:
                        b.Text = "DEFAULT";
                        break;
                }
                b.Name = "btn_Port" + b.Text;
            }
            else
            {
                if ((_board.TerrainTiles[_terrainCount - 1]).Robber)
                {
                    //b.BackgroundImage = new Bitmap(Resources.s);
                    b.Text = "Robber";
                }
                switch ((_board.TerrainTiles[_terrainCount-1]).Type)
                {
                    case (int)TileType.Desert:
                        break;
                    case (int)TileType.Fields:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    case (int)TileType.Hills:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    case (int)TileType.Mountains:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    case (int)TileType.Pasture:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    case (int)TileType.Woods:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    default:
                        b.Text = "DEFAULT";
                        break;
                }
                b.Name = "btn_Tile" + (_terrainCount-1);
            }
            _tileCount++;
            b.Location = new Point((int)point.X, (int)point.Y+20);
            b.Width = 50;
            b.Height = 47;
            
            //b.BackgroundImage = image;
            return b;
        }

        private void DrawVertexButtons(PointF[] points) 
        {
            if (seaTileIndices.Contains(_tileCount-1) || portTileIndices.Contains(_tileCount-1))
            {
                return;
            }

            var vertices = _board.TerrainTiles[_terrainCount - 1].Vertices;

            for (var i = 0; i < points.Length; i++ )
            {
                var vertex = vertices[i];
                var location = points[i];

                if (_doIAddAShittyButtonHere.Contains(vertex))
                {
                    continue;
                }

                var b = new Button();
                b.Width = 15;
                b.Height = 15;
                b.Location = new Point((int)location.X - b.Width/2, (int)location.Y - b.Height/2);
                b.Name = "btn_Vertex" + vertex.Index;
                b.TabStop = false;
                //b.Text = vertex.Index.ToString();
                b.BackColor = Color.Transparent;

                Controls.Add(b);
                _doIAddAShittyButtonHere.Add(vertex);
            }
        }

        private void frm_gameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
