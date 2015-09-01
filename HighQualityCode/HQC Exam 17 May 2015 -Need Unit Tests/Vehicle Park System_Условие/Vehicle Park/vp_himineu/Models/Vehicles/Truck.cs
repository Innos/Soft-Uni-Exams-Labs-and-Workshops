namespace VehiclePark.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal TruckRegularRate = 4.75m;

        private const decimal TruckOvertimeRate = 6.20m;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, TruckRegularRate, TruckOvertimeRate, reservedHours)
        {
        }

    }
}
