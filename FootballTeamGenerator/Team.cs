namespace FootballTeamGenerator;
public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    public double Rating
    {
        get => CalculateTeamRating();
    }
    private double CalculateTeamRating()
    {
        if (players.Count == 0)
        {
            return 0;
        }
        return Math.Round(players.Average(p => p.SkillLevel));
    }
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
    public void RemovePlayer(string name)
    {
        Player playerToRemove = players.FirstOrDefault(p => p.Name == name);
        if (playerToRemove != null)
        {
            players.Remove(playerToRemove);
        }
        else
        {
            Console.WriteLine($"Player {name} is not in {Name} team.");
        }

    }
    public override string ToString()
    {
        return $"{Name} - {Rating}";
    }

}
