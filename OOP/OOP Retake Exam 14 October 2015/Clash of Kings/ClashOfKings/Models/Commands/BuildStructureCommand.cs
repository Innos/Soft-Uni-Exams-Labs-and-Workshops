namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class BuildStructureCommand : Command
    {
        private const string BuildSuccess = "Successfully built {0} in {1}";
        private const string NotAdvancedEnough = "Structure requires a more advanced city";
        private const string NotEnoughFunds = "House {0} doesn't have sufficient funds to build {1}";

        public BuildStructureCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string buildingName = commandParams[0];
            string cityName = commandParams[1];
            var city = this.Engine.Continent.GetCityByName(cityName);
            Utility.Validator.CheckForNull(city,"city");

            var building = this.Engine.ArmyStructureFactory.CreateStructure(buildingName);

            if (building.RequiredCityType > city.CityType)
            {
                throw new InsufficientCitySizeException(NotAdvancedEnough);
            }
            if (city.ControllingHouse.TreasuryAmount < building.BuildCost)
            {
                throw new InsufficientFundsException(string.Format(NotEnoughFunds,city.ControllingHouse.Name,building.GetType().Name));
            }
            city.ControllingHouse.TreasuryAmount -= building.BuildCost;
            city.AddArmyStructure(building);
            this.Engine.Render(BuildSuccess,building.GetType().Name,city.Name);
        }
    }
}
