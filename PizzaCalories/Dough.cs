namespace PizzaCalories;

public class Dough
{
    private const int MinWeight = 1;
    private const int MaxWeight = 200;
	private int weight;
	private string flourType;
	private string bakingTechnique;
    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
		BakingTechnique = bakingTechnique;
		Weight = weight;
    }

    public string BakingTechnique 
	{
		get => bakingTechnique;
		private set 
		{ 
			string valueAsLower = value.ToLower();
			if (valueAsLower != "crispy"
				&& valueAsLower != "chewy"
				&& valueAsLower != "homemade")
			{
				throw new ArgumentException("Invalid type of dough.");
			}
			bakingTechnique  = value; 
		}
	}


	public string FlourType
	{
		get => flourType;
		private set 
		{ 
			string valueAsLower = value.ToLower();
			if(valueAsLower != "white" && valueAsLower != "wholegrain")
			{
				throw new ArgumentException("Invalid type of dough.");
			}
			flourType = value; 
		}
	}


	public int Weight
	{
		get => weight;
		private set 
		{ 
			if (value < MinWeight || value > MaxWeight)
			{
				throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
			}
			weight = value; 
		}
	}
    public double GetCalories()
    {
		double flourTypeModifier = GetFlourTypeModifier();
		double bakingTechniqueModifier = GetBakingTechniqueModifier();

		return Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
    }

    private double GetBakingTechniqueModifier()
    {
        string bakingTechniqueAsLower = BakingTechnique.ToLower();
		if (bakingTechniqueAsLower == "crispy")
		{
			return 0.9;
		}

		if (bakingTechniqueAsLower == "chewy")
		{
			return 1.1;
		}

		return 1;
    }

    private double GetFlourTypeModifier()
    {
        string flourTypeAsLower = FlourType.ToLower();
		if (flourTypeAsLower == "white")
		{
			return 1.5;
		}

		return 1;
    }



}
