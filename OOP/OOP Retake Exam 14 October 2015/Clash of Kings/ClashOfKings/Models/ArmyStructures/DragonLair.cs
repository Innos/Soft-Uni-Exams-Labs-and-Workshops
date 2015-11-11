namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class DragonLair : Building
    {
        private const CityType DragonLairRequiredCityType = CityType.Capital;
        private const decimal DragonLairBuildingCost = 200000;
        private const int DragonLairCapacity = 3;
        private const UnitType DragonLairUnitType = UnitType.AirForce;

        public DragonLair()
            : base(
                  DragonLairRequiredCityType,
                  DragonLairBuildingCost,
                  DragonLairCapacity,
                  DragonLairUnitType)
        {
        }
    }
}
