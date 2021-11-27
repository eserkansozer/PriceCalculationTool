using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class AvailableProducts
    {
        public List<Product> Products { get; }

        public AvailableProducts()
        {
            Products = new List<Product>
            {
                new Product("Butter", 0.80M),
                new Product("Milk", 1.15M),
                new Product("Bread", 1.00M)
            };
        }

        public Product Find(string name)
        {
            return Products.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
