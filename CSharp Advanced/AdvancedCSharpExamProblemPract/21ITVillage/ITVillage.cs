using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ITVillage
{
    static void Main(string[] args)
    {
        bool NakovD = false;
        int coins = 50;
        int totalInns = 0;
        int innsOwned = 0;
        string[] tokens = Console.ReadLine().Replace(" ", "").Split(new char[]{'|'},StringSplitOptions.RemoveEmptyEntries);
        List<string> field = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            totalInns = totalInns + tokens[i].Count(letter => letter == 'I');
            field.Add(tokens[i]);
        }
        string[] position = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int row = int.Parse(position[0]) - 1;
        int col = int.Parse(position[1]) - 1;
        string direction = "";
        if (col == 0 && row > 0)
        {
            direction = "up";
        }
        else if (row == 0 && col < 3)
        {
            direction = "right";
        }
        else if (col == 3 && row < 3)
        {
            direction = "down";
        }
        else if (row == 3 && col > 0)
        {
            direction = "left";
        }

        int[] diceThrows = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        for (int i = 0; i < diceThrows.Length; i++)
        {
            coins += innsOwned * 20;
            char currentPosition = Walk(field, diceThrows[i], ref direction, ref row, ref col);
            //current position check
            if (currentPosition == 'P')
            {
                coins -= 5;
            }
            else if (currentPosition == 'I')
            {
                if (coins >= 100)
                {
                    coins -= 100;
                    innsOwned++;
                }
                else
                {
                    coins -= 10;
                }
            }
            else if (currentPosition == 'F')
            {
                coins += 20;
            }
            else if (currentPosition == 'S')
            {
                i = i + 2;
            }
            else if (currentPosition == 'V')
            {
                coins *= 10;
            }
            else if (currentPosition == 'N')
            {
                NakovD = true;
            }

            //endgame check
            if(NakovD)
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                return;
            }
            else if(innsOwned == totalInns)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>",coins);
                return;
            }
            else if(coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return;
            }
        }
        Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
    }

    static char Walk(List<string> field, int moves,ref string direction, ref int row, ref int col)
    {
        for (int i = 0; i < moves; i++)
        {
            if(direction == "right" && col == field[row].Length-1)
            {
                direction = "down";
            }
            else if (direction == "down" && row == field.Count - 1)
            {
                direction = "left";
            }
            else if (direction == "left" && col == 0)
            {
                direction = "up";
            }
            else if(direction == "up" && row == 0)
            {
                direction = "right";
            }

            switch(direction)
            {
                case "right": col++; break;
                case "down": row++; break;
                case "left": col--; break;
                case "up": row--; break;
            }
        }
        return field[row][col];
    }
}

