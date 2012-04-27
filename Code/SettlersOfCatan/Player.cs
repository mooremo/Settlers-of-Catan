using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        public String Name { get; set; }
        public int Color { get; set; }
        public ArrayList ResourceHand { get; set; }
        public ArrayList DevelopmentHand { get; set; }
        public ArrayList PlayedDevelopmentCards { get; set; }
        public int RoadsRemaining { get; set; }
        public int VillagesRemaining { get; set; }
        public int CitiesRemaining { get; set; }
        public int Score { get; set; }

        public Player(SerializationInfo info, StreamingContext ctxt)
       {
            this.Name = (String)info.GetValue("Name", typeof(String));
            this.Color = (int)info.GetValue("Color", typeof(int));
            this.ResourceHand = (ArrayList)info.GetValue("ResourceHand", typeof(ArrayList));
            this.DevelopmentHand = (ArrayList)info.GetValue("DevelopmentHand", typeof(ArrayList));
            this.PlayedDevelopmentCards = (ArrayList)info.GetValue("PlayedDevelopmentCards", typeof(ArrayList));
            this.RoadsRemaining = (int)info.GetValue("RoadsRemaining", typeof(int));
            this.VillagesRemaining = (int)info.GetValue("VillagesRemaining", typeof(int));
            this.CitiesRemaining = (int)info.GetValue("CitiesRemaining", typeof(int));
            this.Score = (int)info.GetValue("Score", typeof(int));

       }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Color", this.Color);
            info.AddValue("ResourceHand", this.ResourceHand);
            info.AddValue("DevelopmentHand", this.DevelopmentHand);
            info.AddValue("PlayedDevelopmentCards", this.PlayedDevelopmentCards);
            info.AddValue("RoadsRemaining", this.RoadsRemaining);
            info.AddValue("VillagesRemaining", this.VillagesRemaining);
            info.AddValue("CitiesRemaining", this.CitiesRemaining);
            info.AddValue("Score", this.Score);
        }

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