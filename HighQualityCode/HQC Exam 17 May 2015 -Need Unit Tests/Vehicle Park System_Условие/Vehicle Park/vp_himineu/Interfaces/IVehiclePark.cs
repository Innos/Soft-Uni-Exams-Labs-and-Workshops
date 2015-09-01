namespace VehiclePark.Interfaces
{
    using System;

    using VehiclePark.Models.Vehicles;

    public interface IVehiclePark
    {
        // TODO: Documentar esse método
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        // TODO: Documentar esse método
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        // TODO: Documentar esse método
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        // TODO: Documentar esse método
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        // TODO: Documentar esse método
        string GetStatus();

        // TODO: Documentar esse método
        string FindVehicle(string licensePlate);

        // TODO: Documentar esse método
        string FindVehiclesByOwner(string owner);
    }
}
