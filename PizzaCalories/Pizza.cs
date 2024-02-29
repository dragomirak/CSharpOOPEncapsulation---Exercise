﻿namespace PizzaCalories
{
    public class Pizza
    {
		private const int NameMinLength = 1;
		private const int NameMaxLength = 15;
        private const int MaxToppingCount = 10;
		private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>(); 

        }

        public string Name
		{
			get => name;
			private set 
			{
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
					throw new ArgumentException($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }
                name = value; 
			}
		}
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MaxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingCount}].");
            }
            toppings.Add(topping);
        }
        public double GetCalories()
        {
            return dough.GetCalories() + toppings.Sum(t => t.GetCalories());
        }
        public override string ToString()
        {
            return $"{Name} - {GetCalories():f2} Calories.";
        }

    }
}
