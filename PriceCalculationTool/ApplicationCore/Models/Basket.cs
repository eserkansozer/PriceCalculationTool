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
                var applyTimes = HowManyTimesEligibleFor(offer);
                for (int i = 0; i < applyTimes; i++)
                {
                    var productToDiscount = Items.Find(it => it.Name == offer.DiscountedProductName);
                    _totalDiscount += productToDiscount.Cost * (decimal)offer.DiscountRate;
                }
            }
        }

        public int HowManyTimesEligibleFor(Offer offer)
        {
            if (EligibleFor(offer))
            {
                var eligibleForRequiredProducts = HowManyMatchesForRequiredProduct(offer) / offer.RequiredNumber;
                var eligibleForDiscountedProducts = HowManyMatchesForDiscountedProduct(offer);
                return eligibleForRequiredProducts <= eligibleForDiscountedProducts ? eligibleForRequiredProducts : eligibleForDiscountedProducts;
            }
            return 0;
        }

        private bool EligibleFor(Offer offer)
        {
            return HowManyMatchesForRequiredProduct(offer) >= offer.RequiredNumber && HowManyMatchesForDiscountedProduct(offer) >= 1;
        }

        private int HowManyMatchesForRequiredProduct(Offer offer)
        {
            return _items.Count(i => i.Name == offer.RequiredProductName);
        }

        private int HowManyMatchesForDiscountedProduct(Offer offer)
        {
            return _items.Count(i => i.Name == offer.DiscountedProductName);
        }
    }
}
