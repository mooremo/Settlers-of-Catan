namespace SettlersOfCatan
{
    public enum SettlementType
    {
        Village,
        City,
    }

    public enum TileType
    {
        Port2Wool,
        Port2Brick,
        Port2Lumber,
        Port2Grain,
        Port2Ore,
        Port3,
        Hills,
        Mountains,
        Fields,
        Woods,
        Pasture,
        Desert,
        Sea
    }

    public enum CardType
    {
        Brick,
        Wool,
        Lumber,
        Grain,
        Ore,
        Soldier,
        RoadBuilding,
        YearOfPlenty,
        Monopoly,
        VictoryPoint,
    }

    public enum Context
    {
        None,
        PlaceVillageSetup,
        PlaceRoadSetup,
        PlaceVillage,
        PlaceCity,
        PlaceRoadFirstVertex,
        PlaceRoadSecondVertex,
        PickUpRobber,
        PlaceRobber,
        Trade,
    }

    public enum Colors
    {
        Red,
        Blue,
        White,
        Orange,
    }

    public enum Language
    {
        English,
        Deutsch,
    }
}