﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class frm_gameBoard : Form
    {
        private readonly float _radius = 50f;
        private Pen _pen = new Pen(Color.Black, 5);
        private List<int> seaTileIndices = new List<int>(new int[] {0,1,2,3,5,6,9,13,16,20,23,27,30,31,33,34,35,36});
        private int tileCount = 0;

        public frm_gameBoard()
        {
            InitializeComponent();
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
            Bitmap brush;
            TextureBrush image;
            image = new Bitmap(path);
            brush = new TextureBrush(image);
            var point = new PointF(seed.X, seed.Y);
            var hexagonPoints = GetHexagonPoints(point, _radius);
            for (var i = 0; i < numOnRow; i++)
            {
                CreateGraphics().DrawPolygon(_pen, hexagonPoints);
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
            DrawRowOne(new PointF((float)(Width / 2.0), (float)((Height - (14 * _radius)) / 2.0) + _radius), 1);
        }

        private void frm_gameBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
