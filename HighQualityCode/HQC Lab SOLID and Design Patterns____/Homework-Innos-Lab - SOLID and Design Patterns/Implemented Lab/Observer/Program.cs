namespace Skyrim
{
    using System;
    using System.Collections.Generic;

    using Skyrim.Items;
    using Skyrim.Units;

    public class Program
    {
        public static void Main()
        {
            // Dragon with 100 HP
            var dragon = new Dragon("Alduin", 300, 100);
            
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Warrior("Ulfric Stormcloak", 80, 80));
            warriors.Add(new Warrior("Cicero", 15, 50));
            warriors.Add(new Warrior("Jarl Balgruuf", 40, 30));

            dragon.OnDragonDeath += (sender, args) =>
                {
                    foreach (var warrior in warriors)
                    {
                        warrior.Update(new Weapon(10, 10));
                    }
                };

            foreach (var warrior in warriors)
            {
                dragon.Attach(warrior);
            }

            // Nothing happens
            dragon.HealthPoints -= 20;
            // Nothing happens
            dragon.HealthPoints -= 10;
            // Dragon dies
            dragon.HealthPoints -= 90;

            Console.WriteLine(warriors[0].AttackPoints);
            Console.WriteLine(warriors[0].HealthPoints);
            Console.WriteLine(warriors[1].AttackPoints);
            Console.WriteLine(warriors[1].HealthPoints);
            Console.WriteLine(warriors[2].AttackPoints);
            Console.WriteLine(warriors[2].HealthPoints);
        }
    }
}
