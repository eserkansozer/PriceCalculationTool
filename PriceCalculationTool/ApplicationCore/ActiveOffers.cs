using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore
{
    public class ActiveOffers
    {
        public List<Offer> Offers { get; }

        public ActiveOffers()
        {
            Offers = new List<Offer> { 
                new Offer(2, "Butter", 0.50f, "Bread"),
                new Offer(3, "Milk", 1.00f, "Milk")
            };
        }
    }
}
