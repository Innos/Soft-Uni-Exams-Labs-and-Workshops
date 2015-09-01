namespace VehiclePark.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const decimal CarRegularRate = 2m;

        private const decimal CarOvertimeRate = 3.5m;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, CarRegularRate, CarOvertimeRate, reservedHours)
        {
        }
    }
}
