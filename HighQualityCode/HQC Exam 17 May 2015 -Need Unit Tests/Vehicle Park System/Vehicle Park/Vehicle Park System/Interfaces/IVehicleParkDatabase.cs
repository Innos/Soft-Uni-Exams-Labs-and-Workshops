namespace VehiclePark.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IVehicleParkDatabase
    {
        Dictionary<string, IVehicle> VehicleByPosition { get; }

        Dictionary<IVehicle, string> PositionByVehicle { get; }

        Dictionary<string, IVehicle> VehiclesByLicensePlate { get; }

        Dictionary<IVehicle, DateTime> EntryTimesByVehicles { get; }

        MultiDictionary<string, IVehicle> VehiclesByOwner { get; }

        int[] VehiclesInSector { get; }

        void AddVehicle(IVehicle vehicle, int sector, int place, DateTime entryTime);

        void RemoveVehicle(IVehicle vehicle);
    }
}
