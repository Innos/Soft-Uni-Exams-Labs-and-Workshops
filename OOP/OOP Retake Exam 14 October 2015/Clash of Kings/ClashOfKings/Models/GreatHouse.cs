using System;
using System.Text;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;

namespace ClashOfKings.Models
{
    public class GreatHouse : House
    {
        private const string CityNotFoundErrorMessage = "Specified city does not exist or is not controlled by house {0}";

        public GreatHouse(string name, decimal initialTreasuryAmount) : base(name, initialTreasuryAmount)
        {
        }

        public override decimal TreasuryAmount { get; set; }

        public override void UpgradeCity(ICity city)
        {
            Utility.Validator.CheckForNull(city,"string",string.Format(CityNotFoundErrorMessage,this.Name));

            this.TreasuryAmount -= city.UpgradeCost;
            city.Upgrade();
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Great ");
            result.Append(base.Print());
            return result.ToString();
        }
    }
}
