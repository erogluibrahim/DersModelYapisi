using DersModelYapisi.Models;
using DersModelYapisi.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DersModelYapisi.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var product1 = new Product { Id = 1, Name = "Kamera", Price = 1400 };
            var product2 = new Product { Id = 2, Name = "Fotoğraf Makinesi", Price = 1500 };
            var product3 = new Product { Id = 3, Name = "Tripod", Price = 400 };

            var cartProduct1 = new CartProduct { Product = product1, Quantity = 5, Id = 1, price = 1400 };
            var cartProduct2 = new CartProduct { Product = product2, Quantity = 4, Id = 2, price = 1500 };
            var cartProduct3 = new CartProduct { Product = product3, Quantity = 3, Id = 3, price = 1700 };

            List<CartProduct> cardProducts = new List<CartProduct>();
            cardProducts.Add(cartProduct1);
            cardProducts.Add(cartProduct2);
            cardProducts.Add(cartProduct3);

            CardProductViewModel datas = new CardProductViewModel { products = cardProducts };

            decimal ToplamTutar = 0;
            decimal ToplamKDV = 0;
            foreach (var cardProduct in datas.products)
            {
                ToplamTutar += (cardProduct.price * Convert.ToDecimal(cardProduct.Quantity) * 1.20M);
                ToplamKDV += (cardProduct.price * Convert.ToDecimal(cardProduct.Quantity) * 0.20M);
            }

            ViewBag.ToplamTutar = ToplamTutar;
            ViewBag.ToplamKDV = ToplamKDV;

            return View(datas);

            //ToplamTutar ve ToplamKDV bilgilerini View'e gönderelim.
        }
    }
}
