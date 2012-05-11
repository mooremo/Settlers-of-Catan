using System;
using System.Collections.Generic;
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

        public Player(String name) : this()
        {
            Name = name;
        }

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (String) info.GetValue("Name", typeof (String));
            Color = (Colors) info.GetValue("Color", typeof (Colors));
            ResourceHand = (List<CardType>) info.GetValue("ResourceHand", typeof (List<CardType>));
            DevelopmentHand = (List<CardType>) info.GetValue("DevelopmentHand", typeof (List<CardType>));
            PlayedDevelopmentCards = (List<CardType>) info.GetValue("PlayedDevelopmentCards", typeof (List<CardType>));
            RoadsRemaining = (int) info.GetValue("RoadsRemaining", typeof (int));
            VillagesRemaining = (int) info.GetValue("VillagesRemaining", typeof (int));
            CitiesRemaining = (int) info.GetValue("CitiesRemaining", typeof (int));
            Score = (int) info.GetValue("Score", typeof (int));
        }

        public String Name { get; set; }
        public Colors Color { get; set; }
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
            info.AddValue("Color", Color);
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
    }
}