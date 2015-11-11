namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class Barracks : Building
    {
        private const CityType BarracksRequiredCityType = CityType.Keep;
        private const decimal BarracksBuildingCost = 15000;
        private const int BarracksCapacity = 5000;
        private const UnitType BarracksUnitType = UnitType.Infantry;

        public Barracks() 
            : base(
                  BarracksRequiredCityType,
                  BarracksBuildingCost,
                  BarracksCapacity, 
                  BarracksUnitType)
        {
        }
    }
}
