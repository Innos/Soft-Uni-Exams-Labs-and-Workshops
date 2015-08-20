namespace RPG.Weapons
{
    public abstract class Weapon
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
