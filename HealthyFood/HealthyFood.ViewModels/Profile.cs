using System;
using Newtonsoft.Json;

namespace HealthyFood.ViewModels
{
    public sealed class Profile
    {
        public Profile(
            int age,
            int weight,
            int height,
            byte sex,
            PhysicalActivity physicalActivityType)
        {
            if (age <= 0)
                throw new ArgumentException($"{nameof(age)} can't be lass than 0");
            if (weight <= 0)
                throw new ArgumentException($"{nameof(weight)} can't be lass than 0");
            if (height <= 0)
                throw new ArgumentException($"{nameof(height)} can't be lass than 0");

            Age = age;
            Weight = weight;
            Height = height;
            Sex = sex;
            PhysicalActivityType = physicalActivityType;
        }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; }

        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; }

        [JsonProperty(PropertyName = "sex")]
        public byte Sex { get; set; }

        [JsonProperty(PropertyName = "physicalActivityType")]
        public PhysicalActivity PhysicalActivityType { get; }
    }
}
