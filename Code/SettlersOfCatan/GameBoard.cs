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
        private GameController _gameController;
        private List<Vertex> _alreadyDrawnButtons = new List<Vertex>();
        private Context _context = Context.None;
        private ButtonWithVertex _roadFirstVertex;
        private Color _vertexOriginalColor;
        private Player _firstPlayer;
        private bool _firstTimeFlag = true;
        private bool _roadBuildingFirst = false;


        public frm_gameBoard()
        {
            InitializeComponent();
            _gameController = new GameController();
            _board = _gameController.Board;
            UpdateUILanguage();
        }

        public frm_gameBoard(GameController controller)
        {
            InitializeComponent();
            _gameController = controller;
            _board = _gameController.Board;
            UpdateUILanguage();
            sp_PlayerScores.gc = controller;
            sp_PlayerScores.UpdateScores();

            _context = Context.PlaceVillageSetup;

            pnl_playerData.Enabled = false;
            _firstPlayer = _gameController.CurrentPlayer;
        }

        private void frm_gameBoard_Shown(object sender, EventArgs e)
        {
            DrawRowOne(new PointF((float)(Width / 2.0), (float)((Height - (14 * _radius)) / 8.0) + _radius), 1);
            GameSetup();
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
                    case TileType.Desert:
                        image = new Bitmap(Resources.desert_texture);
                        break;
                    case TileType.Fields:
                        image = new Bitmap(Resources.field_texture);
                        break;
                    case TileType.Hills:
                        image = new Bitmap(Resources.hills_texture);
                        break;
                    case TileType.Mountains:
                        image = new Bitmap(Resources.mountains_texture);
                        break;
                    case TileType.Pasture:
                        image = new Bitmap(Resources.pasture_texture);
                        break;
                    case TileType.Woods:
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

        private ButtonWithTile GetButton(Bitmap image, PointF point)
        {
            ButtonWithTile b = new ButtonWithTile();
            b.Click += new EventHandler(OnTileButtonClick);
            b.Font = new Font(FontFamily.GenericSerif, 6, FontStyle.Bold);
            if (seaTileIndices.Contains(_tileCount))
            {
                _tileCount++;
                return null;
            }
            else if (portTileIndices.Contains(_tileCount))
            {
                switch((_board.PortTiles[_portCount-1]).Type)
                {
                    case TileType.Port2Brick:
                        b.Text = "2:1 " + Resources.brick;
                        break;
                    case  TileType.Port2Grain:
                        b.Text = "2:1 " + Resources.grain;
                        break;
                    case  TileType.Port2Lumber:
                        b.Text = "2:1 " + Resources.wood;
                        break;
                    case  TileType.Port2Ore:
                        b.Text = "2:1 " + Resources.ore;
                        break;
                    case TileType.Port2Wool:
                        b.Text = "2:1 " + Resources.wool;
                        break;
                    case TileType.Port3:
                        b.Text = "3:1";
                        break;
                    default:
                        b.Text = "DEFAULT";
                        break;
                }
                b._tile = _board.PortTiles[_portCount-1];
                b.Name = "btn_Port" + b.Text;
            }
            else
            {
                if ((_board.TerrainTiles[_terrainCount - 1]).Robber)
                {
                    b.BackgroundImage = Resources.robber;
                }                switch ((_board.TerrainTiles[_terrainCount-1]).Type)
                {
                    case TileType.Desert:
                        break;
                    case TileType.Fields:
                    case TileType.Hills:
                    case TileType.Mountains:
                    case TileType.Pasture:
                    case TileType.Woods:
                        b.Text = (_board.TerrainTiles[_terrainCount - 1]).Number.ToString();
                        break;
                    default:
                        b.Text = "DEFAULT";
                        break;
                }
                b._tile = _board.TerrainTiles[_terrainCount-1];
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

                if (_alreadyDrawnButtons.Contains(vertex))
                {
                    continue;
                }

                var b = new ButtonWithVertex();
                b.Width = 25;
                b.Height = 25;
                b.Location = new Point((int)location.X - b.Width/2, (int)location.Y - b.Height/2);
                b.Name = "btn_Vertex" + vertex.Index;
                b._vertex = vertex;
                b.Click += new EventHandler(OnVertexClick);
                b.TabStop = false;
                //b.Text = vertex.Index.ToString();
                b.BackColor = Color.Transparent;

                Controls.Add(b);
                _alreadyDrawnButtons.Add(vertex);
            }
        }

        private void frm_gameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
             Application.Exit(); 
        }

        private void frm_gameBoard_Paint(object sender, PaintEventArgs e)
        {
            int wool = 0;
            int brick = 0;
            int wood = 0;
            int ore = 0;
            int grain = 0;
            int yearOfPlenty = 0;
            int monopoly = 0;
            int roadBuilding = 0;
            int soldier = 0;
            int victoryPoint = 0;
            if (_gameController.CurrentPlayer != null)
            {
                foreach (CardType t in _gameController.CurrentPlayer.ResourceHand)
                {
                    switch (t)
                    {
                        case CardType.Grain:
                            grain++;
                            break;
                        case CardType.Wool:
                            wool++;
                            break;
                        case CardType.Brick:
                            brick++;
                            break;
                        case CardType.Ore:
                            ore++;
                            break;
                        case CardType.Lumber:
                            wood++;
                            break;
                        default:
                            break;
                    }
                }
                foreach (CardType c in _gameController.CurrentPlayer.DevelopmentHand)
                {
                    switch (c)
                    {
                        case CardType.Soldier:
                            soldier++;
                            break;
                        case CardType.Monopoly:
                            monopoly++;
                            break;
                        case CardType.VictoryPoint:
                            victoryPoint++;
                            break;
                        case CardType.RoadBuilding:
                            roadBuilding++;
                            break;
                        case CardType.YearOfPlenty:
                            yearOfPlenty++;
                            break;
                        default:
                            break;
                    }
                }
            }
            lbl_playerBrick.Text = brick.ToString();
            lbl_playerWool.Text = wool.ToString();
            lbl_playerWood.Text = wood.ToString();
            lbl_playerGrain.Text = grain.ToString();
            lbl_playerOre.Text = ore.ToString();
            lbl_playerSoldier.Text = soldier.ToString();
            lbl_playerMonopoly.Text = monopoly.ToString();
            lbl_playerVictoryPoint.Text = roadBuilding.ToString();
            lbl_playerYearOfPlenty.Text = yearOfPlenty.ToString();
            lbl_playerRoadBuilding.Text = roadBuilding.ToString();
        }

        private void OnTileButtonClick(object sender, EventArgs e)
        {
            Tile tile;
            switch(_context)
            {
                case Context.None:
                    break;
                case Context.PickUpRobber:
                    tile = ((ButtonWithTile) sender)._tile;
                    if (tile.Robber)
                    {
                        tile.Robber = false;
                        ((ButtonWithTile) sender).BackgroundImage = null;
                        ((ButtonWithTile) sender).Text = tile.Number.ToString();
                    } 
                    else
                    {
                        MessageBox.Show(
                            Resources.clickRobberError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    _context = Context.PlaceRobber;
                    break;
                case Context.PlaceRobber:
                    tile = ((ButtonWithTile)sender)._tile;
                    tile.Robber = true;
                    ((ButtonWithTile) sender).BackgroundImage = Resources.robber;
                    _context = Context.None;
                    break;
                default:
                    break;
            }
        }

        private void OnVertexClick(object sender, EventArgs e)
        {
            var currentPlayer = _gameController.CurrentPlayer;
            ButtonWithVertex curVertex;
            Pen pen;
            Road road;
            Settlement piece;
            switch(_context)
            {
                case Context.None:
                    break;
                case Context.PlaceCity:
                    var settlement = new Settlement(currentPlayer, SettlementType.City);

                    try
                    {
                        _board.PlacePiece(settlement,
                                          ((ButtonWithVertex) sender)._vertex.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            Resources.settlementPlacementError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    currentPlayer.Buy(settlement);

                    ((Button) sender).BackColor = currentPlayer.GetDrawColor();
                    ((Button) sender).Text = Resources.C;

                    _context = Context.None;
                    break;
                case Context.RoadBuildingFirstVertex:
                case Context.PlaceRoadFirstVertex:
                    _roadFirstVertex = sender as ButtonWithVertex;
                    _vertexOriginalColor = _roadFirstVertex.BackColor;
                    _roadFirstVertex.BackColor = Color.Yellow;

                    if (_context == Context.PlaceRoadFirstVertex)
                    {
                        _context = Context.PlaceRoadSecondVertex;
                    } else
                    {
                        _context = Context.RoadBuildingSecondVertex;
                    }
                    break;

                case Context.RoadBuildingSecondVertex:
                case Context.PlaceRoadSecondVertex:

                    curVertex = sender as ButtonWithVertex;

                    if (!curVertex._vertex.Neighbors.Contains(_roadFirstVertex._vertex))
                    {
                        MessageBox.Show(
                            Resources.neighboringVertexError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (curVertex._vertex.HasRoad(_roadFirstVertex._vertex))
                    {
                        MessageBox.Show(
                            Resources.roadExistsError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    _roadFirstVertex.BackColor = _vertexOriginalColor;

                    road = new Road(currentPlayer);

                    try
                    {
                        _board.PlacePiece(road, curVertex._vertex, _roadFirstVertex._vertex);
                    } catch (Exception ex)
                    {
                        MessageBox.Show(
                            Resources.roadPlacementError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (_context == Context.PlaceRoadSecondVertex)
                    {
                        currentPlayer.Buy(road);
                    }

                    pen = new Pen(currentPlayer.GetDrawColor(), 10);
                    CreateGraphics().DrawLine(pen, curVertex.Location.X + 10, curVertex.Location.Y + 10, _roadFirstVertex.Location.X + 10, _roadFirstVertex.Location.Y + 10);

                    if (_context == Context.PlaceRoadSecondVertex || _roadBuildingFirst)
                    {
                        _roadBuildingFirst = false;
                        _context = Context.None;
                    } else
                    {
                        _roadBuildingFirst = true;
                        _context = Context.RoadBuildingFirstVertex;
                    }
                    break;

                case Context.PlaceVillage:
                    piece = new Settlement(currentPlayer, SettlementType.Village);

                    try
                    {
                        _board.PlacePiece(piece, ((ButtonWithVertex)sender)._vertex.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            Resources.settlementPlacementError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    currentPlayer.Buy(piece);

                    ((Button) sender).BackColor = currentPlayer.GetDrawColor();
                    ((Button) sender).Text = Resources.V;

                    _context = Context.None;
                    break;

                 case Context.Trade:
                    _context = Context.None;
                    break;

                case Context.PlaceVillageSetup:
                    piece = new Settlement(currentPlayer, SettlementType.Village);

                    try
                    {
                        _board.PlacePieceSetup(piece, ((ButtonWithVertex)sender)._vertex.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            Resources.settlementPlacementError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    ((Button) sender).BackColor = currentPlayer.GetDrawColor();
                    ((Button) sender).Text = Resources.V;

                    _roadFirstVertex = sender as ButtonWithVertex;

                    _context = Context.PlaceRoadSetup;
                    GameSetup();
                    break;

                case Context.PlaceRoadSetup:
                    curVertex = sender as ButtonWithVertex;

                    if (!curVertex._vertex.Neighbors.Contains(_roadFirstVertex._vertex))
                    {
                        MessageBox.Show(
                            Resources.neighboringVertexError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (curVertex._vertex.HasRoad(_roadFirstVertex._vertex))
                    {
                        MessageBox.Show(
                            Resources.roadExistsError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    road = new Road(currentPlayer);

                    try
                    {
                        _board.PlacePieceSetup(road, curVertex._vertex, _roadFirstVertex._vertex);
                    } catch (Exception ex)
                    {
                        MessageBox.Show(
                            Resources.roadPlacementError,
                            Resources.invalidLocation,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    pen = new Pen(currentPlayer.GetDrawColor(), 10);
                    CreateGraphics().DrawLine(pen, curVertex.Location.X + 10, curVertex.Location.Y + 10, _roadFirstVertex.Location.X + 10, _roadFirstVertex.Location.Y + 10);

                    _context = Context.PlaceVillageSetup;
                    NextPlayerSetup();
                    GameSetup();
                    break;

                default:
                    break;
            }
        }

        private void btn_placeVillage_Click(object sender, EventArgs e)
        {
            var currentPlayer = _gameController.CurrentPlayer;
            if ((currentPlayer.CanBuildVillage() && (_context != Context.PickUpRobber && _context != Context.PlaceRobber)) || Program.Debug)
            {
                _context = Context.PlaceVillage;
            }
            else
            {
                MessageBox.Show(
                    Resources.insufficientResourcesError,
                    Resources.insufficentResources,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_placeCity_Click(object sender, EventArgs e)
        {
            var currentPlayer = _gameController.CurrentPlayer;
            if ((currentPlayer.CanBuildCity() && (_context != Context.PickUpRobber && _context != Context.PlaceRobber)) || Program.Debug)
            {
                _context = Context.PlaceCity;
            } 
            else
            {
                MessageBox.Show(
                    Resources.insufficientResourcesError,
                    Resources.insufficentResources,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_moveRobber_Click(object sender, EventArgs e)
        {
            var currentPlayer = _gameController.CurrentPlayer;
            if ((currentPlayer.DevelopmentHand.Contains(CardType.Soldier) && (_context != Context.PickUpRobber && _context != Context.PlaceRobber)) || Program.Debug)
            {
                _context = Context.PickUpRobber;
            }
        }

        private void btn_placeRoad_Click(object sender, EventArgs e)
        {
            var currentPlayer = _gameController.CurrentPlayer;
            if ((currentPlayer.CanBuildRoad() && (_context != Context.PickUpRobber && _context != Context.PlaceRobber)) || Program.Debug)
            {
                _context = Context.PlaceRoadFirstVertex;
            }
            else
            {
                MessageBox.Show(
                    Resources.insufficientResourcesError,
                    Resources.insufficentResources,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_trade_Click(object sender, EventArgs e)
        {
            if (_context != Context.PickUpRobber && _context != Context.PlaceRobber)
            {
                _context = Context.Trade;
                var tradeWindow = new frm_Trade(_gameController);
                this.Hide();
                tradeWindow.ShowDialog();

                if (tradeWindow.DialogResult == DialogResult.Cancel || tradeWindow.DialogResult == DialogResult.Abort)
                {
                    this.Show();
                }
                else if (tradeWindow.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void UpdateUILanguage()
        {
            this.Text = Resources.gameBoard;
            lbl_wool.Text = Resources.wool;
            lbl_wood.Text = Resources.wood;
            lbl_brick.Text = Resources.brick;
            lbl_ore.Text = Resources.ore;
            lbl_grain.Text = Resources.grain;
            lbl_victoryPoint.Text = Resources.victoryPoint;
            lbl_soldier.Text = Resources.soldier;
            lbl_roadBuilding.Text = Resources.roadBuilding;
            lbl_yearOfPlenty.Text = Resources.yearOfPlenty;
            lbl_monopoly.Text = Resources.monopoly;

            btn_placeVillage.Text = Resources.placeVillage;
            btn_placeCity.Text = Resources.placeCity;
            btn_moveRobber.Text = Resources.moveRobber;
            btn_placeRoad.Text = Resources.placeRoad;
            btn_trade.Text = Resources.trade;
            btn_EndTurn.Text = Resources.endTurn;
            btn_Buy.Text = Resources.buyCard;
            btn_PlayCard.Text = Resources.playCard;
        }

        private void btn_rules_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
# if DEBUG
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = Path.Combine(path, Resources.rulesPDF);
            System.Diagnostics.Process.Start(path);
#else
            path = Path.Combine(path, Resources.rulesPDF);
            System.Diagnostics.Process.Start(path);
#endif
        }

        private void btn_EndTurn_Click(object sender, EventArgs e)
        {
            if (_context != Context.PickUpRobber && _context != Context.PlaceRobber)
            {
                _gameController.ChangeCurrentPlayer();
                _gameController.ScorePlayers();
                sp_PlayerScores.UpdateScores();
                foreach (Player p in _gameController.Players)
                {
                    if (p.Score >= 10)
                    {
                        this.Hide();
                        new Victory((Resources.congratulations + " " + p.Name + "!")).Show();
                    }

                }
                UpdateDiceRoll();
            }
            else
            {
                MessageBox.Show(
                    Resources.moveRobberError,
                    Resources.moveRobber,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void UpdateDiceRoll()
        {
            _gameController.RollDice();
            lbl_DiceDisplay.Text = _gameController.Dice.Value.ToString();
            if (_gameController.Dice.Value == 7)
            {
                _context = Context.PickUpRobber;
            }
        }

        private void btn_Buy_Click(object sender, EventArgs e)
        {
            var curPlayer = _gameController.CurrentPlayer;
            if (curPlayer.CanBuyDevelopmentCard())
            {
                var devCard = _gameController.DrawDevelopment();
                curPlayer.DevelopmentHand.Add(devCard);
                curPlayer.Buy(devCard);
                pnl_playerData.Update();
            } else
            {
                MessageBox.Show(
                    Resources.insufficientResourcesError,
                    Resources.insufficentResources,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void NextPlayerSetup()
        {
            if (_firstTimeFlag)
            {
                _gameController.ChangeCurrentPlayer();
                if (_gameController.CurrentPlayer == _firstPlayer)
                {
                    _firstTimeFlag = false;
                    _gameController.ChangeCurrentPlayerReverse();
                }
            } else
            {
                if (_gameController.CurrentPlayer == _firstPlayer)
                {
                    for (int i = 0; i < 13; i++ )
                    {
                        _gameController.AwardResourceForSettlementAdjacentToHex(i);
                    }
                    _context = Context.None;
                    pnl_playerData.Enabled = true;
                    UpdateDiceRoll();
                } else
                {
                    _gameController.ChangeCurrentPlayerReverse();
                }
            }
            sp_PlayerScores.UpdateScores();
        }

        private void GameSetup()
        {
            if (_context == Context.PlaceVillageSetup)
            {
                MessageBox.Show(
                    _gameController.CurrentPlayer.Name + Resources.pleaseVillage,
                    Resources.gameSetup,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            } else if (_context == Context.PlaceRoadSetup)
            {
                MessageBox.Show(
                    _gameController.CurrentPlayer.Name + Resources.pleaseRoad,
                    Resources.gameSetup,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_PlayCard_Click(object sender, EventArgs e)
        {
            if (_context == Context.PickUpRobber || _context == Context.PlaceRobber) return;

            var temp = new PlayCard();

            var curPlayer = _gameController.CurrentPlayer;
            foreach (var card in curPlayer.DevelopmentHand)
            {
                switch (card)
                {
                    case CardType.Monopoly:
                        temp.EnableMonopoly();
                        break;
                    case CardType.RoadBuilding:
                        temp.EnableRoadBuilding();
                        break;
                    case CardType.YearOfPlenty:
                        temp.EnableYOP();
                        break;
                    case CardType.VictoryPoint:
                        temp.EnableVictoryCard();
                        break;
                }
            }

            temp.ShowDialog();
            switch (temp.Choice)
            {
                case CardType.RoadBuilding:
                    _context = Context.RoadBuildingFirstVertex;
                    _roadBuildingFirst = false;
                    break;
                case CardType.Monopoly:
                    Monopoly();
                    break;
                case CardType.YearOfPlenty:
                    YearOfPlenty();
                    break;
                case CardType.VictoryPoint:
                    curPlayer.DevelopmentHand.Remove(CardType.VictoryPoint);
                    curPlayer.PlayedDevelopmentCards.Add(CardType.VictoryPoint);
                    break;
            }
        }

        private void YearOfPlenty()
        {
            var curPlayer = _gameController.CurrentPlayer;
            var yop = new ResourceSelect();
            yop.ShowDialog();

            var choice1 = yop.Result;
            var choice2 = yop.OtherResult;

            curPlayer.ResourceHand.Add(choice1);
            curPlayer.ResourceHand.Add(choice2);
        }

        private void Monopoly()
        {
            var curPlayer = _gameController.CurrentPlayer;
            var monopoly = new ResourceSelect();
            monopoly.ShowDialog();

            var choice = monopoly.Result;
            var count = 0;
            foreach(var player in _gameController.Players)
            {
                if (player == curPlayer) continue;
                for (var i=0; i<player.ResourceHand.Count; i++)
                {
                    var card = player.ResourceHand[i];
                    if (card == choice)
                    {
                        count++;
                    }
                }

                player.ResourceHand.RemoveAll(card => card == choice);
            }

            for (var i=0; i<count; i++)
            {
                curPlayer.ResourceHand.Add(choice);
            }
        }
    }
}
