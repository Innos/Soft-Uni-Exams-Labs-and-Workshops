using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PaintBall
{
    static void Main(string[] args)
    {
        bool shotIsBlack = true;
        int[] field = new int[10];
        for (int i = 0; i < 10; i++)
        {
            field[i] = 1023;
        }
        string command = Console.ReadLine();
        while (command != "End")
        {
            int row = int.Parse(command.Split(' ')[0]);
            int bitPosition = int.Parse(command.Split(' ')[1]);
            int splash = int.Parse(command.Split(' ')[2]);
            for (int i = row-splash; i <= row + splash; i++)
            {
                if(i >= 0 && i <= 9)
                {
                    for (int bit = bitPosition + splash; bit >= bitPosition - splash; bit--)
                    {
                        if(bit >= 0 && bit <= 9)
                        {
                            if (shotIsBlack)
                            {
                                int mask = ~(1 << bit);
                                field[i] = field[i] & mask;
                            }
                            else
                            {
                                int mask = 1 << bit;
                                field[i] = field[i] | mask;
                            }
                        }
                    }
                }
            }
            shotIsBlack = !shotIsBlack;
            command = Console.ReadLine();
        }
        Console.WriteLine(field.Sum());
    }
}

