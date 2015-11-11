namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;

    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[0];
            var city = this.Engine.Continent.GetCityByName(cityName);

            city.ControllingHouse.UpgradeCity(city);
            this.Engine.Render("City {0} successfully upgraded to {1}",city.Name,city.CityType);
        }
    }
}
