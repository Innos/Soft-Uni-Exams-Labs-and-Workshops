using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PokerStraight
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int weight = 0;
        //string[] cards = new string[] { "x", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        //char[] suit = new char[] { 'x', '♣', '♦', '♥', '♠' };
        int magicWeight = int.Parse(Console.ReadLine());
        for (int card1 = 1; card1 <= 10; card1++)
        {
            for (int suit1 = 1; suit1 <= 4; suit1++)
            {
                for (int card2 = card1 + 1; card2 <= card1 + 1; card2++)
                {
                    for (int suit2 = 1; suit2 <= 4; suit2++)
                    {
                        for (int card3 = card2 + 1; card3 <= card2 + 1; card3++)
                        {
                            for (int suit3 = 1; suit3 <= 4; suit3++)
                            {
                                for (int card4 = card3 + 1; card4 <= card3 + 1; card4++)
                                {
                                    for (int suit4 = 1; suit4 <= 4; suit4++)
                                    {
                                        for (int card5 = card4 + 1; card5 <= card4 + 1; card5++)
                                        {
                                            for (int suit5 = 1; suit5 <= 4; suit5++)
                                            {
                                                weight = (10 * card1 + suit1) + (20 * card2 + suit2) + (30 * card3 + suit3) + (40 * card4 + suit4) + (50 * card5 + suit5);
                                                if (weight == magicWeight)
                                                {
                                                    solutions++;
                                                    //Console.WriteLine("{0}{1} {2}{3} {4}{5} {6}{7} {8}{9} = {10}",
                                                    //    cards[card1], suit[suit1],
                                                    //    cards[card2], suit[suit2],
                                                    //    cards[card3], suit[suit3],
                                                    //    cards[card4], suit[suit4],
                                                    //    cards[card5], suit[suit5],
                                                    //     weight);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }

                }
            }
        }
        Console.WriteLine(solutions);
    }
}

