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
            if (this.IsEligibleFor(offer))
            {
                var applyTimes = HowManyTimesEligibleFor(offer);
                for (int i = 0; i < applyTimes; i++)
                {
                    var productToDiscount = Items.Find(it => it.Name == offer.DiscountedProductName);
                    _totalDiscount += productToDiscount.Cost * (decimal)offer.DiscountRate;
                }
            }
        }

        private int HowManyTimesEligibleFor(Offer offer)
        {
            if (IsEligibleFor(offer))
            {
                if (offer.RequiredProductName == offer.DiscountedProductName)
                {
                    var applicableForRequiredProducts = HowManyMatchesForRequiredProduct(offer) / offer.RequiredNumber;
                    var applicableForDiscountedProducts = HowManyMatchesForDiscountedProduct(offer) - applicableForRequiredProducts * offer.RequiredNumber;
                    return applicableForRequiredProducts <= applicableForDiscountedProducts ? applicableForRequiredProducts : applicableForDiscountedProducts;
                }
                else
                {
                    var applicableForRequiredProducts = HowManyMatchesForRequiredProduct(offer) / offer.RequiredNumber;
                    var applicableForDiscountedProducts = HowManyMatchesForDiscountedProduct(offer);
                    return applicableForRequiredProducts <= applicableForDiscountedProducts ? applicableForRequiredProducts : applicableForDiscountedProducts;
                }
            }
            return 0;
        }

        private bool IsEligibleFor(Offer offer)
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
