using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddItem(Product item)
        {
            _items.Add(item);
        }

        public decimal Sum()
        {
            return _items.Sum(i => i.Cost);
        }
    }
}
