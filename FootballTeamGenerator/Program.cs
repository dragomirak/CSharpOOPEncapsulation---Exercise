using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace FootballTeamGenerator;

public class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(";");
            string command = tokens[0];
            
            try
            {
                if (tokens[0] == "Team")
                {
                    Team team = new(tokens[1]);
                    teams.Add(team);
                }
                else if (tokens[0] == "Add")
                {
                    string teamName = tokens[1];
                    Team team = teams.FirstOrDefault(t => t.Name == teamName);
                    if (team != null)
                    {
                        string playerName = tokens[2];
                        Player player = new(playerName, int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                        team.AddPlayer(player);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    Team team = teams.FirstOrDefault(t => t.Name == teamName);
                    team.RemovePlayer(playerName);
                }
                else if (tokens[0] == "Rating")
                {
                    string teamName = tokens[1];
                    Team teamToShow = teams.FirstOrDefault(t => t.Name == teamName);
                    if (teamToShow != null)
                    {
                        Console.WriteLine(teamToShow);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
            }
            catch (ArgumentException ae)
            { 
                Console.WriteLine(ae.Message);
            }
        }

    }
}
