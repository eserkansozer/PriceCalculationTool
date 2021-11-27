namespace ApplicationCore.Models
{
    public class Offer
    {
        private int RequiredNumber { get; }
        private string RequiredProductName { get; }
        private float DiscountRate { get; }
        private string DiscountedProductName { get; }

        public Offer(int requiredNumber, string requiredProduct, float discountRate, string discountedProduct)
        {
            RequiredNumber = requiredNumber;
            RequiredProductName = requiredProduct;
            DiscountRate = discountRate;
            DiscountedProductName = discountedProduct;
        }
    }
}
