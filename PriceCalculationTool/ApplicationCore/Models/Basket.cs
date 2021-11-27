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

        public void ApplyOffers(List<Offer> offers)
        {
            foreach (var offer in offers)
            {
                if (offer.IsApplicableTo(this))
                {
                    ApplyOfferDiscount(offer);
                }
            }
        }

        private void ApplyOfferDiscount(Offer offer)
        {
            var applyTimes = offer.HowManyTimesApplicableTo(this);
            for (int i = 0; i < applyTimes; i++)
            {
                var productToDiscount = Items.Find(it => it.Name == offer.DiscountedProductName);
                _totalDiscount += productToDiscount.Cost * (decimal)offer.DiscountRate;
            }
        }
    }
}
