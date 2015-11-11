namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;

    [Command]
    class AddNeighborsToCityCommand : Command
    {
        private const string NonExistantNeighbour = "Specified neighbor does not exist";
        private const string NegativeDistance = "The distance between cities cannot be negative";
        private const string AddSuccess = "All valid neighbor records added for city {0}";

        public AddNeighborsToCityCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[0];

            var city = this.Engine.Continent.GetCityByName(cityName);
            Utility.Validator.CheckForNull(city,"city");
            for (int i = 1; i < commandParams.Length; i=i+2)
            {
                string neighbour = commandParams[i];
                double distance = double.Parse(commandParams[i + 1]);

                var neighbourCity = this.Engine.Continent.GetCityByName(neighbour);

                if (neighbourCity == null)
                {
                    this.Engine.Render(NonExistantNeighbour);
                }
                else if (distance < 0)
                {
                    this.Engine.Render(NegativeDistance);
                }
                else
                {
                    this.Engine.Continent.CityNeighborsAndDistances[city].Add(neighbourCity, distance);
                    this.Engine.Continent.CityNeighborsAndDistances[neighbourCity].Add(city,distance);
                }
            }
            this.Engine.Render(AddSuccess,city.Name);
        }
    }
}
