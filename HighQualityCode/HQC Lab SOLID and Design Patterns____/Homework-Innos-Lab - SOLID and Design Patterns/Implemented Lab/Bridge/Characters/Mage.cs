namespace RPG.Characters
{
    using RPG.Weapons;

    public class Mage : Character
    {
        private const string MageName = "Mage";

        public Mage(Weapon weapon)
            : base(weapon)
        {
            this.Name = MageName;
        }
    }
}
