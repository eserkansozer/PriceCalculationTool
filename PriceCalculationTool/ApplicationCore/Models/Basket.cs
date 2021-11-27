using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class Basket
    {
        private List<Product> _items;

        public Basket()
        {
            _items = new List<Product>();
        }

        public List<Product> Items
        {
            get { return _items; }
        }

    }
}
