using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LabyrinthDash
{
    const string ObstacleCharacters = "*#@";
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        char[][] field = new char[length][];
        for (int i = 0; i < length; i++)
        {
            string input = Console.ReadLine();
            field[i] = input.ToCharArray();
        }
        string directions = Console.ReadLine();
        int lives = 3;
        int moves = 0;
        int row = 0;
        int col = 0;
        foreach(var direction in directions)
        {
            int previousRow = row;
            int previousCol = col;
            switch (direction)
            {
                case '<': col--; break;
                case 'v': row++; break;
                case '^': row--; break;
                case '>': col++; break;
            }

            if (IsOutside(field, row, col))
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                moves++;
                break;
            }
            if (ObstacleCharacters.Contains(field[row][col]))
            {
                lives--;
                moves++;
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                if (lives <= 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (field[row][col] == '_' || field[row][col] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                row = previousRow;
                col = previousCol;
            }
            else if (field[row][col] == '$')
            {
                lives++;
                moves++;
                field[row][col] = '.';
                Console.WriteLine("Awesome! Lives left: {0}", lives);
            }
            else
            {
                Console.WriteLine("Made a move!");
                moves++;
            }
        }
        Console.WriteLine("Total moves made: {0}", moves);

    }

    static bool IsOutside(char[][] field, int row, int col)
    {
          if(row<0 || row >= field.Length ||
              col < 0 || col >= field[row].Length ||
              field[row][col] == ' ')
          {
              return true;
          }
          return false;
    }  
}

