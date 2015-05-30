using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

class Parachute
{
    static void Main(string[] args)
    {

        Position jumper = new Position(0, 0);
        int row = 0;
        int offset = 0;
        bool jumperFound = false;

        string input;
        while((input = Console.ReadLine()) != "END")
        {    
            //Reading the line
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '<')
                {
                    offset -= 1;
                }
                else if(input[i] == '>')
                {
                    offset += 1;
                }
            }

            //Moving the jumper if he was already found and checking if he splatted :D
            if (jumperFound)
            {
                jumper.X = jumper.X + 1;
                jumper.Y += offset;
                if (Landed(input, jumper.X, jumper.Y))
                {
                    return;
                }
            }

            //Checking if the jumper was on this line(the check is done here so as to not execute wind directions on the line he was found)
            if (input.Contains('o'))
            {
                jumperFound = true;
                jumper = new Position(row, input.IndexOf('o'));
            }

            //reseting the wind offset each line
            offset = 0;
            //counting the rows, to know where the jumper starts
            row++;
        }
    }
    static bool Landed(string input,int x, int y)
    {
        char[] cliff = { '|', '/', '\\' };
        if (cliff.Contains(input[y]))
        {
            Console.WriteLine("Got smacked on the rock like a dog!");
            Console.WriteLine("{0} {1}", x, y);
            return true;
        }
        else if (input[y] == '~')
        {
            Console.WriteLine("Drowned in the water like a cat!");
            Console.WriteLine("{0} {1}", x, y);
            return true;
        }
        else if (input[y] == '_')
        {
            Console.WriteLine("Landed on the ground like a boss!");
            Console.WriteLine("{0} {1}", x, y);
            return true;
        }
        return false;
    }
}

