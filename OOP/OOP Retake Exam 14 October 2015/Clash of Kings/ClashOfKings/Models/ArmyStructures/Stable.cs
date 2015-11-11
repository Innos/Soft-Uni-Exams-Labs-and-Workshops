namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Models.Armies;

    [ArmyStructure]
    public class Stable : Building
    {
        private const CityType StableRequiredCityType = CityType.FortifiedCity;
        private const decimal StableBuildingCost = 75000;
        private const int StableCapacity = 2500;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable()
            : base(
                  StableRequiredCityType,
                  StableBuildingCost,
                  StableCapacity,
                  StableUnitType)
        {
        }
    }
}
