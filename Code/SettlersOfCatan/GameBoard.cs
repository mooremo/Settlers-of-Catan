using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public frm_gameBoard()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            _board = new Board();
        }

        private void DrawButton()
        {
            Button b = new Button();
            this.Controls.Add(b);
        }

        private PointF[] GetHexagonPoints(PointF center, float radius)
        {
            var ret = new PointF[6];

            for (var i = 0; i < 6; i++)
            {
                ret[i] = new PointF((float) (center.X + radius * Math.Cos(2 * Math.PI * i / 6)), (float) (center.Y + radius * Math.Sin(2 * Math.PI * i / 6)));
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
                //Button b = new Button();
                //b.Text = "IM HERE";
                //b.Location = new Point((int)hexagonPoints[4].X, (int)hexagonPoints[5].Y);
                //b.Width = 50;
                //b.Height = 50;
               
                //b.DrawToBitmap(image, b.Bounds);
                //this.Controls.Add(b);
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

        private void frm_gameBoard_Paint(object sender, PaintEventArgs e)
        {
            _tileCount = 0;
            _portCount = 0;
            _terrainCount = 0;
            DrawRowOne(new PointF((float) (Width/2.0), (float) ((Height - (14*_radius))/2.0) + _radius), 1);
        }

        private void frm_gameBoard_Load(object sender, EventArgs e)
        {

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
            _tileCount++;
            return image;
        }
    }
}
