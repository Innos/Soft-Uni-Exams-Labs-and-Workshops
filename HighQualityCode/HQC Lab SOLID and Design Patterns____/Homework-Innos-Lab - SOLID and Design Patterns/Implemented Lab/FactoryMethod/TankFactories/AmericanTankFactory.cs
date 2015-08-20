namespace FactoryMethod.TankFactories
{
    using FactoryMethod.Units;

    public class AmericanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            this.Tank = new Tank("M1 Abrams ", 5.4d, 120);
            return this.Tank;
        }
    }
}
