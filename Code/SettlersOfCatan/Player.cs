using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    [Serializable]
    public class Player : ISerializable
    {
        public Player()
        {
            DevelopmentHand = new List<CardType>();
            PlayedDevelopmentCards = new List<CardType>();
            ResourceHand = new List<CardType>();
        }

        public Player(String name)
            : this()
        {
            Name = name;
        }

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (String) info.GetValue("Name", typeof (String));
            PlayerColor = (Colors) info.GetValue("PlayerColor", typeof (Colors));
            ResourceHand = (List<CardType>) info.GetValue("ResourceHand", typeof (List<CardType>));
            DevelopmentHand = (List<CardType>) info.GetValue("DevelopmentHand", typeof (List<CardType>));
            PlayedDevelopmentCards = (List<CardType>) info.GetValue("PlayedDevelopmentCards", typeof (List<CardType>));
            RoadsRemaining = (int) info.GetValue("RoadsRemaining", typeof (int));
            VillagesRemaining = (int) info.GetValue("VillagesRemaining", typeof (int));
            CitiesRemaining = (int) info.GetValue("CitiesRemaining", typeof (int));
            Score = (int) info.GetValue("Score", typeof (int));
        }

        public String Name { get; set; }
        public Colors PlayerColor { get; set; }
        public List<CardType> ResourceHand { get; set; }
        public List<CardType> DevelopmentHand { get; set; }
        public List<CardType> PlayedDevelopmentCards { get; set; }
        public int RoadsRemaining { get; set; }
        public int VillagesRemaining { get; set; }
        public int CitiesRemaining { get; set; }
        public int Score { get; set; }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", Name);
            info.AddValue("PlayerColor", PlayerColor);
            info.AddValue("ResourceHand", ResourceHand);
            info.AddValue("DevelopmentHand", DevelopmentHand);
            info.AddValue("PlayedDevelopmentCards", PlayedDevelopmentCards);
            info.AddValue("RoadsRemaining", RoadsRemaining);
            info.AddValue("VillagesRemaining", VillagesRemaining);
            info.AddValue("CitiesRemaining", CitiesRemaining);
            info.AddValue("Score", Score);
        }

        #endregion

        //player calls this to end thier turn
        public void EndTurn()
        {
        }

        public void Discard(int index)
        {
            Shuffler.Shuffle(ResourceHand);
            ResourceHand.RemoveAt(index);
        }

        public bool CanBuildRoad()
        {
            return ResourceHand.Contains(CardType.Brick) && ResourceHand.Contains(CardType.Lumber) && RoadsRemaining > 0;
        }

        public bool CanBuildVillage()
        {
            var brickCount = 0;
            var woodCount = 0;
            var wheatCount = 0;
            var sheepCount = 0;

            foreach (var card in ResourceHand)
            {
                if (card == CardType.Brick) brickCount++;
                if (card == CardType.Lumber) woodCount++;
                if (card == CardType.Grain) wheatCount++;
                if (card == CardType.Wool) sheepCount++;
            }

            return brickCount > 0 && woodCount > 0 && wheatCount > 0 && sheepCount > 0 && VillagesRemaining > 0;
        }

        public bool CanBuildCity()
        {
            var wheatCount = 0;
            var oreCount = 0;

            foreach (var card in ResourceHand)
            {
                if (card == CardType.Grain) wheatCount++;
                if (card == CardType.Ore) oreCount++;
            }

            return wheatCount > 1 && oreCount > 2 && CitiesRemaining > 0;
        }

        public bool CanBuyDevelopmentCard()
        {
            return ResourceHand.Contains(CardType.Wool) && ResourceHand.Contains(CardType.Grain) &&
                   ResourceHand.Contains(CardType.Ore);
        }

        public Color GetDrawColor()
        {
            switch (PlayerColor)
            {
                case Colors.Blue:
                    return Color.Blue;
                case Colors.Red:
                    return Color.Red;
                case Colors.Orange:
                    return Color.Orange;
                case Colors.White:
                    return Color.White;
                default:
                    throw new Exception("What");
            }
        }

        public void Buy(object toBuy)
        {
            if (toBuy is Settlement)
            {
                var settlement = toBuy as Settlement;
                if (settlement.type == SettlementType.Village)
                {
                    ResourceHand.Remove(CardType.Brick);
                    ResourceHand.Remove(CardType.Lumber);
                    ResourceHand.Remove(CardType.Grain);
                    ResourceHand.Remove(CardType.Wool);
                }
                else
                {
                    ResourceHand.Remove(CardType.Grain);
                    ResourceHand.Remove(CardType.Grain);
                    ResourceHand.Remove(CardType.Ore);
                    ResourceHand.Remove(CardType.Ore);
                    ResourceHand.Remove(CardType.Ore);
                }
            }
            else if (toBuy is Road)
            {
                ResourceHand.Remove(CardType.Brick);
                ResourceHand.Remove(CardType.Lumber);
            }
            else if (toBuy is CardType)
            {
                ResourceHand.Remove(CardType.Wool);
                ResourceHand.Remove(CardType.Grain);
                ResourceHand.Remove(CardType.Ore);
            }
            else
            {
                throw new Exception("Unable to buy type given");
            }
        }

        public Dictionary<CardType, int> GetNumberOfResources()
        {
            int wool = 0;
            int brick = 0;
            int wood = 0;
            int ore = 0;
            int grain = 0;
            foreach (CardType t in ResourceHand)
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
            Dictionary<CardType, int> temp = new Dictionary<CardType, int>

                                                 {
                                                     {CardType.Brick, brick},
                                                     {CardType.Ore, ore},
                                                     {CardType.Grain, grain},
                                                     {CardType.Lumber, wood},
                                                     {CardType.Wool, wool}
                                                 };
            return temp;
        }

        public void SetHand(Dictionary<CardType, int> resources)
        {
            var tempHand = new List<CardType>();

            foreach (var type in resources.Keys)
            {
                for (var i=0; i<resources[type]; i++)
                {
                    tempHand.Add(type);
                }
            }
            ResourceHand = tempHand;
        }
    }
}