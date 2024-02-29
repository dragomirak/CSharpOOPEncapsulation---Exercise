namespace PizzaCalories;

public class Program
{
    static void Main(string[] args)
    {
        string[] pizzaTokens = Console.ReadLine().Split(" ");
        string pizzaName = pizzaTokens[1];
        string[] doughTokens = Console.ReadLine().Split(" ");
        string flourType = doughTokens[1];
        string baking = doughTokens[2];
        int weight = int.Parse(doughTokens[3]);

        try
        {
            Dough dough = new(flourType, baking, weight);
            Pizza pizza = new(pizzaName, dough);
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingTokens = input.Split(" ");
                string toppingName = toppingTokens[1];
                int toppingWeight = int.Parse(toppingTokens[2]);
                Topping topping = new(toppingName, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza.ToString());
        }
        catch (Exception ex)
             when (ex is ArgumentException || ex is InvalidOperationException)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
