using NUnit.Framework;
using ApplicationCore.Models;
using ApplicationCore;
using System.Collections.Generic;

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

            foreach (var offer in _activeOffers.Offers)
            {
                offer.ApplyToBasket(basket);
            }

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

            foreach (var offer in _activeOffers.Offers)
            {
                offer.ApplyToBasket(basket);
            }

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

            foreach (var offer in _activeOffers.Offers)
            {
                offer.ApplyToBasket(basket);
            }

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

            foreach (var offer in _activeOffers.Offers)
            {
                offer.ApplyToBasket(basket);
            }

            var sum = basket.Sum();

            Assert.AreEqual(3.45m, sum);
        }

    }
}
