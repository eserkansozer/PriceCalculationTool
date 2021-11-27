using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Models
{
    public class Basket
    {
        private List<Product> _items;
        private decimal _totalDiscount;

        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
        }

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
            return _items.Sum(i => i.Cost) - _totalDiscount;
        }
                
        public void ApplyDiscountFor(Offer offer)
        {
            if (this.EligibleFor(offer))
            {
                var productToDiscount = Items.Find(i => i.Name == offer.DiscountedProductName);
                _totalDiscount += productToDiscount.Cost * (decimal)offer.DiscountRate;
            }
        }

        private bool EligibleFor(Offer offer)
        {
            return _items.Where(i => i.Name == offer.RequiredProductName).Count() >= offer.RequiredNumber && _items.Any(i => i.Name == offer.DiscountedProductName);
        }
    }
}
