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

            Assert.AreEqual(sum, 2.95m);
        }

    }
}
