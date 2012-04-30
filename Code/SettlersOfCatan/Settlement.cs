using System.Runtime.Serialization;

namespace SettlersOfCatan
{
    public class Settlement
    {
        public Settlement(Player player1, SettlementType settlementType)
        {
            // TODO: Complete member initialization
            player = player1;
            type = settlementType;
        }

        public SettlementType type { get; set; }
        public Player player { get; set; }

         #region ISerializable Members

        public Settlement(SerializationInfo info, StreamingContext ctxt)
        {
            player = (Player) info.GetValue("player", typeof (Player));
            type = (SettlementType)info.GetValue("type", typeof(SettlementType));
        }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("player", player);
            info.AddValue("type", type);
        }

        #endregion
    }
}