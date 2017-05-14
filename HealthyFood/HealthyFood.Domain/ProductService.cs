using System.Collections.Generic;
using System.Linq;
using HealthyFood.ViewModels;
using HealthyFood.ViewModels.Aggregates;

namespace HealthyFood.Services
{
    public class ProductService
    {
        public IEnumerable<Product> GeTypeAggregatesByCalories(int calories)
        {
            var res = new []
            {
                new ProductTypeAggregate(PhysicalActivity.Low,
                    new[]
                    {
                        new Product("Каша Геркулес", amount: 100, proteins: 65, carbonHydrates: 65.7, fat: 6.2,
                            calories: 355),
                        new Product("Зелень", amount: 100, proteins: 2.5, carbonHydrates: 5.2, fat: 0.4, calories: 36),
                        new Product("Капуста брокколи варёная", amount: 100, proteins: 3, carbonHydrates: 4, fat: 0.4,
                            calories: 27),
                        new Product("Горох Пассим колотый", amount: 100, proteins: 23, carbonHydrates: 48.1, fat: 1.6,
                            calories: 299),
                        new Product("Кабачок", amount: 100, proteins: 0.6, carbonHydrates: 4.6, fat: 0.3, calories: 24),
                        new Product("Бананы сушёные", amount: 100, proteins: 3.9, carbonHydrates: 80.5, fat: 1.8,
                            calories: 390)
                    })
            };

            return res.SelectMany(r => r.Products.Where(pr => pr.Calories <= calories));
        }
    }
}
