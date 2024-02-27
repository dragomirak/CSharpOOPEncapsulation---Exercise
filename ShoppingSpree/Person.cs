namespace ShoppingSpree;

public class Person
{
    private string name;
    private double money;

    public Person(string name, double money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public List<Product> Bag { get; set; }
    public double Money
    {
        get => money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
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
}
