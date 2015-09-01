namespace VehiclePark.Execution
{
    using System;

    using System.Globalization;

    using VehiclePark.Core;

    using VehiclePark.Interfaces;
    using VehiclePark.Models.Vehicles;

    public class CommandExecutor : ICommandExecutor
    {
        private VehicleParkTracker VehiclePark { get; set; }

        public string ExecuteCommand(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.Name)
            {
                case "SetupPark":
                    int sectors = int.Parse(command.Parameters["sectors"]);
                    int places = int.Parse(command.Parameters["placesPerSector"]);

                    this.VehiclePark = new VehicleParkTracker(sectors, places);
                    return "Vehicle park created";

                case "Park":
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            return
                                this.VehiclePark.InsertCar(
                                    new Car(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                        // why round trip kind??
                        case "motorbike":
                            return
                                this.VehiclePark.InsertMotorbike(
                                    new Motorbike(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])), 
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                        // stack overflow says this
                        case "truck":
                            return
                                this.VehiclePark.InsertTruck(
                                    new Truck(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])), 
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                        // I wanna know
                    }

                    break;

                case "Exit":
                    return this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"],
                        DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.Parameters["paid"]));
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "FindVehicle":
                    return this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                case "VehiclesByOwner":
                    return this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                default:
                    throw new InvalidOperationException("Invalid command.");
            }

            return string.Empty;
        }
    }
}
