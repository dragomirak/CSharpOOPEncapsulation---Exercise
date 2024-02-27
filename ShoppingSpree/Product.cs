namespace ShoppingSpree;

public class Product
{
    private string name;
    private double cost;
    public Product(string name, double cost)
    {
        Name = name;
        Cost = cost;
    }
    public double Cost
    {
        get => cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public override string ToString()
    {
        return Name;
    }
}
