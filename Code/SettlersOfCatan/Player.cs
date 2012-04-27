using System;
using System.Collections;
using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    [Serializable]
    public class Player : ISerializable
    {
        public Player()
        {
            PlayedDevelopmentCards = new ArrayList();
            ResourceHand = new ArrayList();
        }

        public Player(String name)
        {
            Name = name;
        }

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (String) info.GetValue("Name", typeof (String));
            Color = (int) info.GetValue("Color", typeof (int));
            ResourceHand = (ArrayList) info.GetValue("ResourceHand", typeof (ArrayList));
            DevelopmentHand = (ArrayList) info.GetValue("DevelopmentHand", typeof (ArrayList));
            PlayedDevelopmentCards = (ArrayList) info.GetValue("PlayedDevelopmentCards", typeof (ArrayList));
            RoadsRemaining = (int) info.GetValue("RoadsRemaining", typeof (int));
            VillagesRemaining = (int) info.GetValue("VillagesRemaining", typeof (int));
            CitiesRemaining = (int) info.GetValue("CitiesRemaining", typeof (int));
            Score = (int) info.GetValue("Score", typeof (int));
        }

        public String Name { get; set; }
        public int Color { get; set; }
        public ArrayList ResourceHand { get; set; }
        public ArrayList DevelopmentHand { get; set; }
        public ArrayList PlayedDevelopmentCards { get; set; }
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

        //Player calls this to end thier turn
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