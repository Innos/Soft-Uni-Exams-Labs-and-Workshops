namespace FactoryMethod.TankFactories
{
    using FactoryMethod.Units;

    public class RussianTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            this.Tank = new Tank("T 34", 3.3d, 75);
            return this.Tank;
        }
    }
}
