using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BasketBattle
{
    static void Main(string[] args)
    {
        int round = 1;
        bool gameOver = false;
        int NakovPoints = 0;
        int SimeonPoints = 0;
        bool NakovShoots = Console.ReadLine() == "Nakov";
        int rounds = int.Parse(Console.ReadLine());
        for (int i = 1; i <= rounds*2; i++)
        {
            int points = int.Parse(Console.ReadLine());
            string shot = Console.ReadLine();
            if (shot == "success" && NakovShoots)
            {
                NakovPoints += points;
                if (NakovPoints == 500)
                {
                    Console.WriteLine("Nakov");
                    Console.WriteLine(round);
                    Console.WriteLine(SimeonPoints);
                    gameOver = true;
                    break;
                }
                else if(NakovPoints > 500)
                {
                    NakovPoints = NakovPoints - points;
                }
            }
            else if (shot == "success" && NakovShoots == false)
            {
                SimeonPoints += points;
                if (SimeonPoints == 500)
                {
                    Console.WriteLine("Simeon");
                    Console.WriteLine(round);
                    Console.WriteLine(NakovPoints);
                    gameOver = true;
                    break;
                }
                else if(SimeonPoints > 500)
                {
                    SimeonPoints = SimeonPoints - points;
                }
            }
            if (i % 2 == 0)
            {
                round++;
            }
            else
            {
                NakovShoots = !NakovShoots;
            }
        }
        if(gameOver == false)
        {
            if (NakovPoints == SimeonPoints)
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(NakovPoints);
            }
            else if (NakovPoints > SimeonPoints)
            {
                Console.WriteLine("Nakov");
                Console.WriteLine(NakovPoints - SimeonPoints);
            }
            else
            {
                Console.WriteLine("Simeon");
                Console.WriteLine(SimeonPoints - NakovPoints);
            }
        }
    }
}

