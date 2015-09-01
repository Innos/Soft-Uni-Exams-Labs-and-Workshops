namespace VehicleParkSystem1
{
    using System.Globalization;

    using System.Threading;

    using VehiclePark.Execution;

    public static class VehicleParkProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}