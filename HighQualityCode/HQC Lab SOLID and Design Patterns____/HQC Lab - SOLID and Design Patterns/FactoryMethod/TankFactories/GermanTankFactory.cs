namespace FactoryMethod.TankFactories
{
    using FactoryMethod.Units;

    public class GermanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            this.Tank = new Tank("Tiger", 4.5d, 120);
            return this.Tank;
        }
    }
}
