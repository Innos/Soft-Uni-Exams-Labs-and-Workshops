namespace RPG
{
    using System;

    using RPG.Characters;
    using RPG.Weapons;

    public class Program
    {
        public static void Main()
        {
            Character axeWarrior = new Warrior(new Axe());
            Warrior swordWarrior = new Warrior(new Sword());
            Mage axeMage = new Mage(new Axe());
            Mage swordMage = new Mage(new Sword());

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordWarrior);
            Console.WriteLine(axeMage);
            Console.WriteLine(swordMage);
        }
    }
}
