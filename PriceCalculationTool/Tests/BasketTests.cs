using NUnit.Framework;
using ApplicationCore.Models;

namespace Tests
{
    public class BasketTests
    {
        private AvailableProducts _availableProducts;
        private ActiveOffers _activeOffers;

        [SetUp]
        public void Setup()
        {
            _availableProducts = new AvailableProducts();
            _activeOffers = new ActiveOffers();
        }

        [Test]
        public void BasketShouldCalculateSumWithoutOffers()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Bread"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Milk"));

            var sum = basket.Sum();

            Assert.AreEqual(2.95m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithButterOfferApplied()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Bread"));
            basket.AddItem(_availableProducts.Find("Bread"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(3.10m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithButterOfferAppliedTwice()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));            
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Bread"));
            basket.AddItem(_availableProducts.Find("Bread"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(4.20m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithButterOfferAppliedOnceOnlyBecauseOfDiscountedProduct()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Bread"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(3.70m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithMilkOfferApplied()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(3.45m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithButterAndMilkOffersApplied()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Butter"));
            basket.AddItem(_availableProducts.Find("Bread"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(9.00m, sum);
        }

        [Test]
        public void BasketShouldCalculateSumWithMilkOfferCouldNotBeApplied()
        {
            var basket = new Basket();
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));
            basket.AddItem(_availableProducts.Find("Milk"));

            basket.ApplyOffers(_activeOffers.Offers);

            var sum = basket.Sum();

            Assert.AreEqual(3.45m, sum);
        }

    }
}
