namespace ClashOfKings.Models.Commands
{
    using System.Linq;
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class CreateUnitCommand : Command
    {
        private const string NegativeAmount = "Number of units should be non-negative";

        private const string NotEnoughHousing =
            "City {0} does not have enough housing spaces to accommodate {1} units of {2}";

        private const string NotEnoughFunds = "House {0} does not have enough funds to train {1} units of {2}";

        private const string CreateSuccess = "Successfully added {0} units of {1} to city {2}";

        public CreateUnitCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            int number = int.Parse(commandParams[0]);
            string unitName = commandParams[1];
            string cityName = commandParams[2];
            if (number < 0)
            {
                throw new NegativeAmountException(NegativeAmount);
            }
            var city = this.Engine.Continent.GetCityByName(cityName);
            Utility.Validator.CheckForNull(city, "city");

            var units = this.Engine.UnitFactory.CreateUnits(unitName, number);
            var unit = units.First();
            long requiredCapacity = number * unit.HousingSpacesRequired;
            if (city.AvailableUnitCapacity(unit.Type) < requiredCapacity)
            {
                throw new InsufficientHousingSpacesException(string.Format(NotEnoughHousing, city.Name, number, unit.GetType().Name));
            }
            decimal cost = number * unit.TrainingCost;
            if (city.ControllingHouse.TreasuryAmount < cost)
            {
                throw new InsufficientFundsException(string.Format(
                    NotEnoughFunds,
                    city.ControllingHouse.Name,
                    number,
                    unit.GetType().Name));
            }
            city.ControllingHouse.TreasuryAmount -= cost;
            city.AddUnits(units);

            this.Engine.Render(CreateSuccess,number,unit.GetType().Name,city.Name);
        }
    }
}
