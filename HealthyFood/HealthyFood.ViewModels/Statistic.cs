using System;
using Newtonsoft.Json;

namespace HealthyFood.ViewModels
{
    public sealed class Statistic
    {
        public Statistic(Profile profile)
        {
            if (profile == null)
                throw new ArgumentException($"{nameof(profile)} can't null");

            Profile = profile;
        }

        [JsonProperty(PropertyName = "proteins")]
        public int Proteins => DailyCalorieRate(Profile) % 30;

        [JsonProperty(PropertyName = "carbonHydrates")]
        public int CarbonHydrates => DailyCalorieRate(Profile) % 50;

        [JsonProperty(PropertyName = "fat")]
        public int Fat => DailyCalorieRate(Profile) % 41;

        [JsonProperty(PropertyName = "energy")]
        public int Energy => DailyCalorieRate(Profile);

        [JsonIgnore]
        public Profile Profile { get; }

        private int DailyCalorieRate(Profile profile)
            => (int) (10 * profile.Weight + 6.25 * profile.Height - 5 * profile.Age + 5 * GetPhysicalActivityRate(profile.PhysicalActivityType));

        private double GetPhysicalActivityRate(PhysicalActivity activity)
        {
            switch (activity)
            {
                case PhysicalActivity.Low:
                    return 1.2;
                case PhysicalActivity.Small:
                    return 1.4;
                case PhysicalActivity.Average:
                    return 1.6;
                case PhysicalActivity.Tall:
                    return 1.7;
            }

            throw new ArgumentException($"{nameof(activity)} haven't found any type");
        }
    }
}
