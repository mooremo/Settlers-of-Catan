namespace SettlersOfCatan
{
    public class Settlement
    {
        public Settlement(Player player, SettlementType settlementType)
        {
            // TODO: Complete member initialization
            this.player = player;
            type = settlementType;
        }

        public SettlementType type { get; set; }
        public Player player { get; set; }
    }
}