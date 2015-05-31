using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
    public string Color { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public List<string> Opponents { get; set; }
    public decimal Wins { get; set; }
    public decimal Losses { get; set; }
    public decimal Rank { get; set; }

    public Player()
    {
        this.Age = null;
        this.Opponents = new List<string>();
    }
}

class VladkosNotebook
{
    static void Main(string[] args)
    {
        List<Player> players = new List<Player>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string color = tokens[0];
            Player player;
            if (players.Any(pl => pl.Color == color))
            {
                player = players.First(pl => pl.Color == color);
            }
            else
            {       
                player = new Player();
                player.Color = color;
                players.Add(player);
            }
            if (tokens[1] == "age")
            {
                player.Age = int.Parse(tokens[2]);
            }
            else if (tokens[1] == "win")
            {
                player.Wins = player.Wins + 1;
                player.Opponents.Add(tokens[2]);
            }
            else if (tokens[1] == "loss")
            {
                player.Losses = player.Losses + 1;
                player.Opponents.Add(tokens[2]);
            }
            else if (tokens[1] == "name")
            {
                player.Name = tokens[2];
            }
            
        }

        var result = players
            .Where(pl => pl.Name != null && pl.Age != null)
            .OrderBy(pl => pl.Color);

        StringComparer ordCom = StringComparer.Ordinal;
        foreach (var entry in result)
        {
            entry.Opponents.Sort(ordCom);
        }
            

        foreach (var player in result)
        {
            player.Rank = (player.Wins + 1) / (player.Losses + 1);
            Console.WriteLine("Color: {0}", player.Color);
            Console.WriteLine("-age: {0}", player.Age);
            Console.WriteLine("-name: {0}", player.Name);
            Console.WriteLine("-opponents: {0}", player.Opponents.Count == 0 ? "(empty)" : string.Join(", ", player.Opponents));
            Console.WriteLine("-rank: {0:F2}", player.Rank);
        }
        if (result.Count() == 0)
        {
            Console.WriteLine("No data recovered.");
        }
    }
}


