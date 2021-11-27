using System.Linq;

namespace ApplicationCore.Models
{
    public class Offer
    {
        internal int RequiredNumber { get; }
        internal string RequiredProductName { get; }
        internal float DiscountRate { get; }
        internal string DiscountedProductName { get; }

        public Offer(int requiredNumber, string requiredProduct, float discountRate, string discountedProduct)
        {
            RequiredNumber = requiredNumber;
            RequiredProductName = requiredProduct;
            DiscountRate = discountRate;
            DiscountedProductName = discountedProduct;
        }

        public int HowManyTimesApplicableTo(Basket basket)
        {
            if (IsApplicableTo(basket))
            {
                if (RequiredProductName == DiscountedProductName)
                {
                    var applicableForRequiredProducts = HowManyMatchesForRequiredProduct(basket) / RequiredNumber;
                    var applicableForDiscountedProducts = HowManyMatchesForDiscountedProduct(basket) - applicableForRequiredProducts * RequiredNumber;
                    return applicableForRequiredProducts <= applicableForDiscountedProducts ? applicableForRequiredProducts : applicableForDiscountedProducts;
                }
                else
                {
                    var applicableForRequiredProducts = HowManyMatchesForRequiredProduct(basket) / RequiredNumber;
                    var applicableForDiscountedProducts = HowManyMatchesForDiscountedProduct(basket);
                    return applicableForRequiredProducts <= applicableForDiscountedProducts ? applicableForRequiredProducts : applicableForDiscountedProducts;
                }
            }
            return 0;
        }

        public bool IsApplicableTo(Basket basket)
        {
            return HowManyMatchesForRequiredProduct(basket) >= RequiredNumber && HowManyMatchesForDiscountedProduct(basket) >= 1;
        }

        private int HowManyMatchesForRequiredProduct(Basket basket)
        {
            return basket.Items.Count(i => i.Name == RequiredProductName);
        }

        private int HowManyMatchesForDiscountedProduct(Basket basket)
        {
            return basket.Items.Count(i => i.Name == DiscountedProductName);
        }
    }
}
