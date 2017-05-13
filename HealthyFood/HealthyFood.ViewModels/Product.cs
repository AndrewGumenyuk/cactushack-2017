using Newtonsoft.Json;

namespace HealthyFood.ViewModels
{
    public sealed class Product
    {
        public Product(
            string name,
            double amount, 
            double proteins,
            double carbonHydrates,
            double fat,
            double calories)
        {
            Name = name;
            Amount = amount;
            Proteins = proteins;
            CarbonHydrates = carbonHydrates;
            Fat = fat;
            Calories = calories;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; }

        [JsonProperty(PropertyName = "proteins")]
        public double Proteins { get; }

        [JsonProperty(PropertyName = "carbonHydrates")]
        public double CarbonHydrates { get; }

        [JsonProperty(PropertyName = "fat")]
        public double Fat { get; }

        [JsonProperty(PropertyName = "сalories")]
        public double Calories { get; }
    }
}
