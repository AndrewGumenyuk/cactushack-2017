using System;
using System.Linq;

namespace HealthyFood.ViewModels.Aggregates
{
    public sealed class ProductTypeAggregate
    {
        public ProductTypeAggregate(PhysicalActivity physicalActivity, Product[] products)
        {
            if (products == null || !products.Any())
                throw new ArgumentException($"{nameof(products)} can't be empty or null");

            PhysicalActivity = physicalActivity;
            Products = products;
        }

        public PhysicalActivity PhysicalActivity { get; }
        public Product[] Products { get; }
    }
}
