namespace PizzaCalories;

public class Topping
{
	private const int MinWeight = 1;
	private const int MaxWeight = 50;
	private string name;
	private int weight;

    public Topping(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    public int Weight
	{
		get => weight;
		set 
		{ 
			if (value < MinWeight || value > MaxWeight)
			{
				throw new ArgumentException($"{Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
			}
			weight = value; 
		}
	}


	public string Name
	{
		get => name;
		private set 
		{ 
			string valueAsLower = value.ToLower();	
			if (valueAsLower != "meat"
				&& valueAsLower != "veggies"
				&& valueAsLower != "cheese"
				&& valueAsLower != "sauce")
			{
				throw new ArgumentException($"Cannot place {value} on top of your pizza.");
			}
			name = value; 
		}
	}
	public double GetCalories()
	{
		double modifier = GetModifier();

		return weight * 2 * modifier;
	}

    private double GetModifier()
    {
        string nameAsLower = Name.ToLower();
		if (nameAsLower == "meat")
		{
			return 1.2;
		}

		if (nameAsLower == "veggies")
		{
			return 0.8;
		}

		if (nameAsLower == "cheese")
		{
			return 1.1;
		}

		return 0.9;
    }
}
