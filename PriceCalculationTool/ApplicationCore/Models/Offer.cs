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

        public void ApplyToBasket(Basket basket)
        {
            if (basket.EligibleFor(this))
            {
                basket.ApplyDiscountFor(this);
            }
        }
    }
}
