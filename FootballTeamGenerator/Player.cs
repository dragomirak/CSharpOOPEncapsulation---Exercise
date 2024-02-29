namespace FootballTeamGenerator;

public class Player
{
	private static int MinValue = 0;
	private static int MaxValue = 100;
	private string name;
    private int endurance;
	private int sprint;
	private int dribble;
	private int passing;
    private int shooting;
    

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
	{
		get => name;
		private set 
		{ 
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException("A name should not be empty.");
			}
			name = value; 
		}
	}
	
	public int Endurance
	{
		get => endurance;
		private set 
		{ 
			if (value < MinValue || value > MaxValue)
			{
				throw new ArgumentException("Endurance should be between 0 and 100.");
			}
			endurance = value; 
		}
	}
    public int Sprint
    {
        get => sprint;
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }
    public int Dribble
    {
        get => dribble;
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }
    public int Passing
    {
        get => passing;
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }
    public int Shooting
    {
        get => shooting;
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }
    public double SkillLevel
    {
        get => CalculateSkillLevel();
    }
    private double CalculateSkillLevel()
    {
        double skillCount = 5;
        return (Endurance + Sprint + Dribble + Passing + Shooting) / skillCount;
    }


}
