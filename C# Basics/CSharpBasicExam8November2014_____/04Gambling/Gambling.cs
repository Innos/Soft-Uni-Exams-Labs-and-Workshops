using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Gambling
{
    static void Main(string[] args)
    {
        int totalHands = (int)Math.Pow(52,4);
        int winningHands = 0;
        int dealerStrength = 0;
        string[] cards = new string[] { "0","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        decimal cash = decimal.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        foreach (var card in input)
        {
            dealerStrength = dealerStrength + Array.FindIndex(cards,x=> x == card.ToString());
        }
        for (int card1 = 0; card1 < 52; card1++)
        {
            for (int card2 = 0; card2 < 52; card2++)
            {
                for (int card3 = 0; card3 < 52; card3++)
                {
                    for (int card4 = 0; card4 < 52; card4++)
                    {
                        if(((card1%13+2) + (card2%13+2) +(card3%13+2) + (card4%13+2))> dealerStrength )
                        {
                            winningHands++;
                        }
                    }
                }
            }
        }
        decimal winRate = (winningHands / (decimal)totalHands);
        if(winRate < 0.5m)
        {
            Console.WriteLine("FOLD");
        }
        else
        {
            Console.WriteLine("DRAW");
        }
        Console.WriteLine("{0:F2}",(cash*2)*winRate);
    }
}

