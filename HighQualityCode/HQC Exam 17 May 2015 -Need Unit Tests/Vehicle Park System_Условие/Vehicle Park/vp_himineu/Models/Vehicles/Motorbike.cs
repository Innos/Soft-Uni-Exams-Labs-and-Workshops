namespace VehiclePark.Models.Vehicles
{
    public class Motorbike : Vehicle
    {
        private const decimal MotorcycleRegularRate = 1.35m;

        private const decimal MotorcycleOvertimeRate = 3.00m;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, MotorcycleRegularRate, MotorcycleOvertimeRate, reservedHours)
        {
        }
    }
}
