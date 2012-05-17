using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    public partial class frm_Trade : Form
    {
        public GameController GameController;
        private List<string> _ports = new List<string>(new string[] { TileType.Port2Brick.ToString(), TileType.Port2Grain.ToString(), TileType.Port2Lumber.ToString(), TileType.Port2Ore.ToString(), TileType.Port2Wool.ToString(), TileType.Port3.ToString() });
        private ArrayList _labels = new ArrayList(); 

        public frm_Trade(GameController g)
        {
            GameController = g;
            InitializeComponent();
            UpdateUILanguage();
            foreach (Player p in GameController.Players)
            {
                if (p != GameController.CurrentPlayer)
                {
                    cBox_tradePlayer.Items.Add(p.Name);
                }
            }
            foreach (var t in _ports)
            {
                cBox_tradePort.Items.Add(t);
            }
            _labels.Add(lbl_tradeBrickOffer);
            _labels.Add(lbl_tradeGrainOffer);
            _labels.Add(lbl_tradeLumberOffer);
            _labels.Add(lbl_tradeOreOffer);
            _labels.Add(lbl_tradeWoolOffer);

            Dictionary<CardType, int> resources = new Dictionary<CardType, int>();
            if (GameController.CurrentPlayer != null)
            {
                resources = GameController.CurrentPlayer.GetNumberOfResources();
            }
            lbl_tradeBrickHave.Text = resources[CardType.Brick].ToString();
            lbl_tradeWoolHave.Text = resources[CardType.Wool].ToString();
            lbl_tradeLumberHave.Text = resources[CardType.Lumber].ToString();
            lbl_tradeGrainHave.Text = resources[CardType.Grain].ToString();
            lbl_tradeOreHave.Text = resources[CardType.Ore].ToString();
        }

        public void UpdateUILanguage()
        {
            lbl_tradeBrick.Text = Resources.brick;
            lbl_tradeGrain.Text = Resources.grain;
            lbl_tradeLumber.Text = Resources.wood;
            lbl_tradeOre.Text = Resources.ore;
            lbl_tradeWool.Text = Resources.wool;

            lbl_tradePlayerBrick.Text = Resources.brick;
            lbl_tradePlayerGrain.Text = Resources.grain;
            lbl_tradePlayerLumber.Text = Resources.wood;
            lbl_tradePlayerOre.Text = Resources.ore;
            lbl_tradePlayerWool.Text = Resources.wool;
            
            btn_tradeBankBrick.Text = Resources.brick;
            btn_tradeBankGrain.Text = Resources.grain;
            btn_tradeBankLumber.Text = Resources.wood;
            btn_tradeBankOre.Text = Resources.ore;
            btn_tradeBankWool.Text = Resources.wool;

            btn_tradePortBrick.Text = Resources.brick;
            btn_tradePortGrain.Text = Resources.grain;
            btn_tradePortLumber.Text = Resources.wood;
            btn_tradePortOre.Text = Resources.ore;
            btn_tradePortWool.Text = Resources.wool;

            lbl_tradeHave.Text = Resources.owned;
            lbl_tradeOffer.Text = Resources.toTrade;

            cBox_tradePlayer.Text = Resources.tradePlayer;
            cBox_tradePort.Text = Resources.tradePort;

            btn_cancel.Text = Resources.Cancel;

            for (int i = 0; i < _ports.Count; i++ )
            {
                switch (_ports[i])
                {
                    case "Port2Brick":
                        _ports[i] = "Port2" + Resources.brick;
                        break;
                    case "Port2Grain":
                        _ports[i] = "Port2" + Resources.grain;
                        break;
                    case "Port2Lumber":
                        _ports[i] = "Port2" + Resources.wood;
                        break;
                    case "Port2Ore":
                        _ports[i] = "Port2" + Resources.ore;
                        break;
                    case "Port2Wool":
                        _ports[i] = "Port2" + Resources.wool;
                        break;
                    default:
                        _ports[i] = "Port3";
                        break;
                }
            }
        }

        private void btn_tradeBrickLeft_Click(object sender, EventArgs e)
        {
            int offer;
            int.TryParse(lbl_tradeBrickOffer.Text, out offer);
            if (offer > 0)
            {
                int have;
                int.TryParse(lbl_tradeBrickHave.Text, out have);
                lbl_tradeBrickHave.Text = (have + 1).ToString();

                lbl_tradeBrickOffer.Text = (offer - 1).ToString();
            }
        }

        private void btn_tradeBrickRight_Click(object sender, EventArgs e)
        {
            int have;
            int.TryParse(lbl_tradeBrickHave.Text, out have);
            if (have > 0)
            {
                lbl_tradeBrickHave.Text = (have - 1).ToString();

                int offer;
                int.TryParse(lbl_tradeBrickOffer.Text, out offer);
                lbl_tradeBrickOffer.Text = (offer + 1).ToString();
            }
        }

        private void btn_tradeGrainLeft_Click(object sender, EventArgs e)
        {
            int offer;
            int.TryParse(lbl_tradeGrainOffer.Text, out offer);
            if (offer > 0)
            {
                int have;
                int.TryParse(lbl_tradeGrainHave.Text, out have);
                lbl_tradeGrainHave.Text = (have + 1).ToString();

                lbl_tradeGrainOffer.Text = (offer - 1).ToString();
            }
        }

        private void btn_tradeGrainRight_Click(object sender, EventArgs e)
        {
            int have;
            int.TryParse(lbl_tradeGrainHave.Text, out have);
            if (have > 0)
            {
                lbl_tradeGrainHave.Text = (have - 1).ToString();

                int offer;
                int.TryParse(lbl_tradeGrainOffer.Text, out offer);
                lbl_tradeGrainOffer.Text = (offer + 1).ToString();
            }
        }

        private void btn_tradeLumberLeft_Click(object sender, EventArgs e)
        {
            int offer;
            int.TryParse(lbl_tradeLumberOffer.Text, out offer);
            if (offer > 0)
            {
                int have;
                int.TryParse(lbl_tradeLumberHave.Text, out have);
                lbl_tradeLumberHave.Text = (have + 1).ToString();

                lbl_tradeLumberOffer.Text = (offer - 1).ToString();
            }
        }

        private void btn_tradeLumberRight_Click(object sender, EventArgs e)
        {
            int have;
            int.TryParse(lbl_tradeLumberHave.Text, out have);
            if (have > 0)
            {
                lbl_tradeLumberHave.Text = (have - 1).ToString();

                int offer;
                int.TryParse(lbl_tradeLumberOffer.Text, out offer);
                lbl_tradeLumberOffer.Text = (offer + 1).ToString();
            }
        }

        private void btn_tradeOreLeft_Click(object sender, EventArgs e)
        {
            int offer;
            int.TryParse(lbl_tradeOreOffer.Text, out offer);
            if (offer > 0)
            {
                int have;
                int.TryParse(lbl_tradeOreHave.Text, out have);
                lbl_tradeOreHave.Text = (have + 1).ToString();

                lbl_tradeOreOffer.Text = (offer - 1).ToString();
            }
        }

        private void btn_tradeOreRight_Click(object sender, EventArgs e)
        {
            int have;
            int.TryParse(lbl_tradeOreHave.Text, out have);
            if (have > 0)
            {
                lbl_tradeOreHave.Text = (have - 1).ToString();

                int offer;
                int.TryParse(lbl_tradeOreOffer.Text, out offer);
                lbl_tradeOreOffer.Text = (offer + 1).ToString();
            }
        }

        private void btn_tradeWoolLeft_Click(object sender, EventArgs e)
        {
            int offer;
            int.TryParse(lbl_tradeWoolOffer.Text, out offer);
            if (offer > 0)
            {
                int have;
                int.TryParse(lbl_tradeWoolHave.Text, out have);
                lbl_tradeWoolHave.Text = (have + 1).ToString();

                lbl_tradeWoolOffer.Text = (offer - 1).ToString();
            }
        }

        private void btn_tradeWoolRight_Click(object sender, EventArgs e)
        {
            int have;
            int.TryParse(lbl_tradeWoolHave.Text, out have);
            if (have > 0)
            {
                lbl_tradeWoolHave.Text = (have - 1).ToString();

                int offer;
                int.TryParse(lbl_tradeWoolOffer.Text, out offer);
                lbl_tradeWoolOffer.Text = (offer + 1).ToString();
            }
        }

        private void btn_tradeBankBrick_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if(temp >= 4)
                {
                    l.Text = (temp - 4).ToString();
                    int.TryParse(lbl_tradeBrickHave.Text, out temp);
                    lbl_tradeBrickHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                MessageBox.Show(
                    Resources.trade4to1,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradeBankGrain_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if(temp >= 4)
                {
                    l.Text = (temp - 4).ToString();
                    int.TryParse(lbl_tradeGrainHave.Text, out temp);
                    lbl_tradeGrainHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if(flag)
            {
                MessageBox.Show(
                    Resources.trade4to1,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradeBankLumber_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= 4)
                {
                    l.Text = (temp - 4).ToString();
                    int.TryParse(lbl_tradeLumberHave.Text, out temp);
                    lbl_tradeLumberHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.trade4to1,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradeBankOre_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= 4)
                {
                    l.Text = (temp - 4).ToString();
                    int.TryParse(lbl_tradeOreHave.Text, out temp);
                    lbl_tradeOreHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.trade4to1,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradeBankWool_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= 4)
                {
                    l.Text = (temp - 4).ToString();
                    int.TryParse(lbl_tradeWoolHave.Text, out temp);
                    lbl_tradeWoolHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.trade4to1,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradePlayerMinusBrick_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumBrick.Text, out amount);
            if (amount > 0)
            {
                lbl_tradePlayerNumBrick.Text = (amount - 1).ToString();
            }
        }

        private void btn_tradePlayerPlusBrick_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumBrick.Text, out amount);
            lbl_tradePlayerNumBrick.Text = (amount + 1).ToString();
        }

        private void btn_tradePlayerMinusGrain_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumGrain.Text, out amount);
            if (amount > 0)
            {
                lbl_tradePlayerNumGrain.Text = (amount - 1).ToString();
            }
        }

        private void btn_tradePlayerPlusGrain_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumGrain.Text, out amount);
            lbl_tradePlayerNumGrain.Text = (amount + 1).ToString();
        }

        private void btn_tradePlayerMinusLumber_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumLumber.Text, out amount);
            if (amount > 0)
            {
                lbl_tradePlayerNumLumber.Text = (amount - 1).ToString();
            }
        }

        private void btn_tradePlayerPlusLumber_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumLumber.Text, out amount);
            lbl_tradePlayerNumLumber.Text = (amount + 1).ToString();
        }

        private void btn_tradePlayerMinusOre_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumOre.Text, out amount);
            if (amount > 0)
            {
                lbl_tradePlayerNumOre.Text = (amount - 1).ToString();
            }
        }

        private void btn_tradePlayerPlusOre_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumOre.Text, out amount);
            lbl_tradePlayerNumOre.Text = (amount + 1).ToString();
        }

        private void btn_tradePlayerMinusWool_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumWool.Text, out amount);
            if (amount > 0)
            {
                lbl_tradePlayerNumWool.Text = (amount - 1).ToString();
            }
        }

        private void btn_tradePlayerPlusWool_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(lbl_tradePlayerNumWool.Text, out amount);
            lbl_tradePlayerNumWool.Text = (amount + 1).ToString();
        }

        private void btn_tradePortBrick_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            int numberOfPort = 2;
            if (cBox_tradePort.SelectedIndex == 5)
            {
                numberOfPort = 3;
            }
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= numberOfPort)
                {
                    l.Text = (temp - numberOfPort).ToString();
                    int.TryParse(lbl_tradeBrickHave.Text, out temp);
                    lbl_tradeBrickHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.tradeAtLeast + numberOfPort + Resources.ofResource,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradePortGrain_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            int numberOfPort = 2;
            if (cBox_tradePort.SelectedIndex == 5)
            {
                numberOfPort = 3;
            }
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= numberOfPort)
                {
                    l.Text = (temp - numberOfPort).ToString();
                    int.TryParse(lbl_tradeGrainHave.Text, out temp);
                    lbl_tradeGrainHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.tradeAtLeast + numberOfPort + Resources.ofResource,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradePortLumber_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            int numberOfPort = 2;
            if (cBox_tradePort.SelectedIndex == 5)
            {
                numberOfPort = 3;
            }
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= numberOfPort)
                {
                    l.Text = (temp - numberOfPort).ToString();
                    int.TryParse(lbl_tradeLumberHave.Text, out temp);
                    lbl_tradeLumberHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.tradeAtLeast + numberOfPort + Resources.ofResource,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradePortOre_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            int numberOfPort = 2;
            if (cBox_tradePort.SelectedIndex == 5)
            {
                numberOfPort = 3;
            }
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= numberOfPort)
                {
                    l.Text = (temp - numberOfPort).ToString();
                    int.TryParse(lbl_tradeOreHave.Text, out temp);
                    lbl_tradeOreHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.tradeAtLeast + numberOfPort + Resources.ofResource,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_tradePortWool_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int temp;
            int numberOfPort = 2;
            if (cBox_tradePort.SelectedIndex == 5)
            {
                numberOfPort = 3;
            }
            foreach (Label l in _labels)
            {
                int.TryParse(l.Text, out temp);
                if (temp >= numberOfPort)
                {
                    l.Text = (temp - numberOfPort).ToString();
                    int.TryParse(lbl_tradeWoolHave.Text, out temp);
                    lbl_tradeWoolHave.Text = (temp + 1).ToString();
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                MessageBox.Show(
                    Resources.tradeAtLeast + numberOfPort + Resources.ofResource,
                    Resources.insufficentTrade,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void cBox_tradePort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBox_tradePort.SelectedIndex)
            {
                case 0:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port2Brick).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                case 1:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port2Grain).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                case 2:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port2Lumber).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                case 3:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port2Ore).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                case 4:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port2Wool).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                case 5:
                    foreach (Vertex v in GameController.Board.getPortTile(TileType.Port3).Vertices)
                    {
                        if (v.Settlement != null && v.Settlement.player == GameController.CurrentPlayer)
                        {
                            return;
                        }
                    }
                    MessageBox.Show(
                    Resources.settlementAtPort,
                    Resources.noPortAccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    break;
                default:
                    break;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            UpdatePlayersResources();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_player)
            {
                int brick;
                int.TryParse(lbl_tradePlayerNumBrick.Text, out brick);
                int grain;
                int.TryParse(lbl_tradePlayerNumGrain.Text, out grain);
                int lumber;
                int.TryParse(lbl_tradePlayerNumLumber.Text, out lumber);
                int ore;
                int.TryParse(lbl_tradePlayerNumOre.Text, out ore);
                int wool;
                int.TryParse(lbl_tradePlayerNumWool.Text, out wool);
                int brickHave;
                int.TryParse(lbl_tradeBrickHave.Text, out brickHave);
                int brickOffer;
                int.TryParse(lbl_tradeBrickOffer.Text, out brickOffer);
                int grainHave;
                int.TryParse(lbl_tradeGrainHave.Text, out grainHave);
                int grainOffer;
                int.TryParse(lbl_tradeGrainOffer.Text, out grainOffer);
                int lumberHave;
                int.TryParse(lbl_tradeLumberHave.Text, out lumberHave);
                int lumberOffer;
                int.TryParse(lbl_tradeLumberOffer.Text, out lumberOffer);
                int oreHave;
                int.TryParse(lbl_tradeOreHave.Text, out oreHave);
                int oreOffer;
                int.TryParse(lbl_tradeOreOffer.Text, out oreOffer);
                int woolHave;
                int.TryParse(lbl_tradeWoolHave.Text, out woolHave);
                int woolOffer;
                int.TryParse(lbl_tradeWoolOffer.Text, out woolOffer);
                Player tradePlayer = new Player();
                string name = (string)cBox_tradePlayer.SelectedItem;
                foreach (Player p in GameController.Players)
                {
                    if (name.Equals(p.Name))
                    {
                        tradePlayer = p;
                        break;
                    }
                }
                Dictionary<CardType, int> resources = tradePlayer.GetNumberOfResources();
                if (brick > resources[CardType.Brick] || grain > resources[CardType.Grain] || lumber > resources[CardType.Lumber] || ore > resources[CardType.Ore] || wool > resources[CardType.Wool])
                {
                    MessageBox.Show(
                    Resources.playerHasInsufficientResources,
                    Resources.insufficientResources,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }

                resources[CardType.Brick] += brickOffer - brick;
                resources[CardType.Grain] += grainOffer - grain;
                resources[CardType.Lumber] += lumberOffer - lumber;
                resources[CardType.Ore] += oreOffer - ore;
                resources[CardType.Wool] += woolOffer - wool;

                tradePlayer.SetHand(resources);
                lbl_tradeBrickHave.Text = (brick + brickHave - brickOffer).ToString();
                lbl_tradeGrainHave.Text = (grain + grainHave - grainOffer).ToString();
                lbl_tradeLumberHave.Text = (lumber + lumberHave - lumberOffer).ToString();
                lbl_tradeOreHave.Text = (ore + oreHave - oreOffer).ToString();
                lbl_tradeWoolHave.Text = (wool + woolHave - woolOffer).ToString();
            }
            UpdatePlayersResources();
            this.DialogResult = DialogResult.OK;
        }

        private void UpdatePlayersResources()
        {
            int brickHave;
            int.TryParse(lbl_tradeBrickHave.Text, out brickHave);
            int brickOffer;
            int.TryParse(lbl_tradeBrickOffer.Text, out brickOffer);
            int grainHave;
            int.TryParse(lbl_tradeGrainHave.Text, out grainHave);
            int grainOffer;
            int.TryParse(lbl_tradeGrainOffer.Text, out grainOffer);
            int lumberHave;
            int.TryParse(lbl_tradeLumberHave.Text, out lumberHave);
            int lumberOffer;
            int.TryParse(lbl_tradeLumberOffer.Text, out lumberOffer);
            int oreHave;
            int.TryParse(lbl_tradeOreHave.Text, out oreHave);
            int oreOffer;
            int.TryParse(lbl_tradeOreOffer.Text, out oreOffer);
            int woolHave;
            int.TryParse(lbl_tradeWoolHave.Text, out woolHave);
            int woolOffer;
            int.TryParse(lbl_tradeWoolOffer.Text, out woolOffer);
            List<CardType> tempHand = new List<CardType>();
            for (int i = 0; i < (brickHave + brickOffer); i++)
            {
                tempHand.Add(CardType.Brick);
            }
            for (int i = 0; i < (grainHave + grainOffer); i++)
            {
                tempHand.Add(CardType.Grain);
            }
            for (int i = 0; i < (lumberHave + lumberOffer); i++)
            {
                tempHand.Add(CardType.Lumber);
            }
            for (int i = 0; i < (oreHave + oreOffer); i++)
            {
                tempHand.Add(CardType.Ore);
            }
            for (int i = 0; i < (woolHave + woolOffer); i++)
            {
                tempHand.Add(CardType.Wool);
            }
            GameController.CurrentPlayer.ResourceHand = tempHand;
        }
    }
}
