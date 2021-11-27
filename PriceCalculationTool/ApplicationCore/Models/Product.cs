namespace ApplicationCore.Models
{
    public class Product
    {
        public string Name { get; }
        public decimal Cost { get; }
        public static Product Where { get; internal set; }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

    }
}
