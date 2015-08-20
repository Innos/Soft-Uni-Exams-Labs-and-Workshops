namespace TankManufacturer
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using FactoryMethod.TankFactories;
    using FactoryMethod.Units;

    public class Program
    {
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        public static void Main()
        {
            TankFactory russianFactory = new RussianTankFactory();
            TankFactory germanFactory = new GermanTankFactory();
            TankFactory americanFactory = new AmericanTankFactory();

            var tiger = germanFactory.CreateTank();
            var t34 = russianFactory.CreateTank();
            var m1Abrams = americanFactory.CreateTank();

            Console.WriteLine(tiger);
            Console.WriteLine(t34);
            Console.WriteLine(m1Abrams);
        }
    }
}
