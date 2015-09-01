namespace VehiclePark.Data
{
    using System;
    using System.Collections.Generic;

    using VehiclePark.Interfaces;

    using Wintellect.PowerCollections;

    public class VehicleParkDatabase : IVehicleParkDatabase
    {
        public VehicleParkDatabase(int numberOfSectors)
        {
            this.VehicleByPosition = new Dictionary<string, IVehicle>();
            this.PositionByVehicle = new Dictionary<IVehicle, string>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.EntryTimesByVehicles = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.VehiclesInSector = new int[numberOfSectors];
        }

        public Dictionary<string, IVehicle> VehicleByPosition { get; private set; }

        public Dictionary<IVehicle, string> PositionByVehicle { get; private set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; private set; }

        public Dictionary<IVehicle, DateTime> EntryTimesByVehicles { get; private set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; private set; }

        public int[] VehiclesInSector { get; private set; }

        public void AddVehicle(IVehicle vehicle, int sector, int place, DateTime entryTime)
        {
            this.PositionByVehicle[vehicle] = string.Format("({0},{1})", sector, place);

            this.VehicleByPosition[string.Format("({0},{1})", sector, place)] = vehicle;
            this.VehiclesByLicensePlate[vehicle.LicensePlate] = vehicle;
            this.EntryTimesByVehicles[vehicle] = entryTime;
            this.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            this.VehiclesInSector[sector - 1]++;
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            int sector =
                int.Parse(
                    this.PositionByVehicle[vehicle].Split(
                        new[] { "(", ",", ")" },
                        StringSplitOptions.RemoveEmptyEntries)[0]);
            var position = this.PositionByVehicle[vehicle];
            this.VehicleByPosition.Remove(position);
            this.PositionByVehicle.Remove(vehicle);
            this.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.EntryTimesByVehicles.Remove(vehicle);
            this.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            this.VehiclesInSector[sector - 1]--;
        }
    }

}
