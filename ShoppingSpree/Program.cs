namespace ShoppingSpree;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] delims = new string[] { "=", ";" };


        string[] peopleTokens = Console.ReadLine()
                .Split(delims, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < peopleTokens.Length; i += 2)
        {
            try
            {
                Person person = new Person(peopleTokens[i], double.Parse(peopleTokens[i + 1]));
                people.Add(person);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        string[] productTokens = Console.ReadLine()
                .Split(delims, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < productTokens.Length; i += 2)
        {
            try
            {
                Product product = new(productTokens[i], double.Parse(productTokens[i + 1]));
                products.Add(product);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] purchase = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string currentPerson = purchase[0];
            string currentProduct = purchase[1];
            Person neededPerson = people.FirstOrDefault(p => p.Name == currentPerson);
            Product neededProduct = products.FirstOrDefault(p => p.Name == currentProduct);

            if (neededPerson.Money >= neededProduct.Cost)
            {
                neededPerson.Bag.Add(neededProduct);
                neededPerson.Money -= neededProduct.Cost;
                Console.WriteLine($"{neededPerson.Name} bought {neededProduct.Name}");
            }
            else
            {
                Console.WriteLine($"{neededPerson.Name} can't afford {neededProduct.Name}");
            }

        }

        foreach (Person person in people)
        {
            if (person.Bag.Count == 0)
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
            else
            {
                Console.Write($"{person.Name} - ");
                Console.WriteLine(string.Join(", ", person.Bag));
            }
        }
    }
}
