using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ChessboardGame
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char[] board = Console.ReadLine().ToCharArray();
        Array.Resize(ref board, n * n);
        long whiteTeam = 0;
        long blackTeam = 0;
        bool blacksTurn = true;
        foreach (var symbol in board)
        {
            if (symbol >= 'A' && symbol <= 'Z')
            {
                if (blacksTurn) whiteTeam += symbol;
                else blackTeam += symbol;
            }
            else if (symbol >= 'a' && symbol <= 'z')
            {
                if (blacksTurn) blackTeam += symbol;
                else whiteTeam += symbol;
            }
            else if (Char.IsDigit(symbol))
            {
                if (blacksTurn) blackTeam += symbol;
                else whiteTeam += symbol;

            }
            blacksTurn = !blacksTurn;
        }
        if (blackTeam == whiteTeam)
        {
            Console.WriteLine("Equal result: {0}", blackTeam);
        }
        else
        {
            Console.WriteLine("The winner is: {0} team", (blackTeam > whiteTeam) ? "black" : "white");
            Console.WriteLine((blackTeam > whiteTeam) ? (blackTeam - whiteTeam) : (whiteTeam - blackTeam));
        }
    }
}

