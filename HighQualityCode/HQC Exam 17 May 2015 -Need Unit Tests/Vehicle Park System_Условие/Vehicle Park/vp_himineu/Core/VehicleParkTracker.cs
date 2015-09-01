namespace VehiclePark.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VehiclePark.Data;
    using VehiclePark.Interfaces;
    using VehiclePark.Models;
    using VehiclePark.Models.Vehicles;

    public class VehicleParkTracker : IVehiclePark
    {
        private readonly Layout layout;

        private readonly VehicleParkDatabase database;

        public VehicleParkTracker(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.database = new VehicleParkDatabase(numberOfSectors);
        }

        public string ExitVehicle(string licensePlate, DateTime exitTime, decimal paidAmount)
        {
            var vehicle = this.database.VehiclesByLicensePlate.ContainsKey(licensePlate) ? this.database.VehiclesByLicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var entryTime = this.database.EntryTimesByVehicles[vehicle];
            int totalHours = (int)Math.Round((exitTime - entryTime).TotalHours);
            var ticket = new StringBuilder();
            var regularSum = vehicle.ReservedHours * vehicle.RegularRate;
            var overtimeSum = totalHours > vehicle.ReservedHours ? (totalHours - vehicle.ReservedHours) * vehicle.OvertimeRate : 0;
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine()
                .AppendFormat("at place {0}", this.database.PositionByVehicle[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", regularSum)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overtimeSum)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", regularSum + overtimeSum)
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", paidAmount)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", paidAmount - (regularSum + overtimeSum))
                .AppendLine()
                .Append(new string('*', 20));

            this.database.RemoveVehicle(vehicle);
            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places =
                this.database.VehiclesInSector.Select(
                    (amount, index) =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)",
                        index + 1,
                        amount,
                        this.layout.Places,
                        Math.Round((double)amount / this.layout.Places * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.database.VehiclesByLicensePlate.ContainsKey(licensePlate) ? this.database.VehiclesByLicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.GetVehicleInformation(vehicle);
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.database.VehiclesByOwner[owner].Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }

            // PERFORMANCE: Unneeded mulitple enumerations of the database dictionaries, introduced a new dictionary to remove needless iteration and searching
            var found = this.database.VehiclesByOwner[owner].OrderBy(v => this.database.EntryTimesByVehicles[v]).ThenBy(v => v.LicensePlate).ToArray();

            return string.Join(Environment.NewLine, this.GetVehicleInformation(found));
        }

        public string InsertCar(Car car, int sector, int place, DateTime entrytime)
        {
            return this.InsertVehicle(car, sector, place, entrytime);
        }

        public string InsertMotorbike(Motorbike motorcycle, int sector, int place, DateTime entrytime)
        {
            return this.InsertVehicle(motorcycle, sector, place, entrytime);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime entrytime)
        {
            return this.InsertVehicle(truck, sector, place, entrytime);
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime entrytime)
        {
            if (sector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.Places)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.database.VehicleByPosition.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.database.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    vehicle.LicensePlate);
            }

            this.database.AddVehicle(vehicle, sector, place, entrytime);
            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }

        private string GetVehicleInformation(params IVehicle[] vehicles)
        {
            return string.Join(
                Environment.NewLine,
                vehicles.Select(
                    vehicle =>
                    string.Format(
                        "{0}{1}Parked at {2}",
                        vehicle.ToString(),
                        Environment.NewLine,
                        this.database.PositionByVehicle[vehicle])));
        }
    }
}