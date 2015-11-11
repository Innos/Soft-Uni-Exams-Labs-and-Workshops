namespace ClashOfKings.Models.ArmyStructures
{
    using System;
    using ClashOfKings.Contracts;
    using ClashOfKings.Models.Armies;

    public abstract class Building : IArmyStructure
    {
        private decimal buildCost;
        private int capacity;

        protected Building(CityType requiredCityType, decimal buildingCost, int capacity, UnitType unitType)
        {
            this.RequiredCityType = requiredCityType;
            this.BuildCost = buildingCost;
            this.Capacity = capacity;
            this.UnitType = unitType;
        }

        public CityType RequiredCityType { get; private set; }

        public decimal BuildCost
        {
            get { return this.buildCost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Build cost","Build cost cannot be negative.");
                }
                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("capacity","A building's capacity cannot be negative.");
                }
                this.capacity = value;
            }
        }

        public UnitType UnitType { get; private set; }
    }
}
