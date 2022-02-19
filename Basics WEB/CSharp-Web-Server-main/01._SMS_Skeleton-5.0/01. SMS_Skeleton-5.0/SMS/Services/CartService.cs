using Microsoft.EntityFrameworkCore;
using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private IRepository repo;

        public CartService(IRepository _repo)
        {
            repo = _repo;
        }
        public IEnumerable<CartViewModel> AddProduct(string productId, string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Produsts)
                .FirstOrDefault();

            var product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Produsts.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            { }

            return user
                .Cart
                .Produsts
                .Select(p => new CartViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        public void BuyProducts(string userId)
        {
            var user = repo.All<User>()
           .Where(u => u.Id == userId)
           .Include(u => u.Cart)
           .ThenInclude(c => c.Produsts)
           .FirstOrDefault();

            user.Cart.Produsts.Clear();

            repo.SaveChanges();
        }

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            var user = repo.All<User>()
                           .Where(u => u.Id == userId)
                           .Include(u => u.Cart)
                           .ThenInclude(c => c.Produsts)
                           .FirstOrDefault();

            return user
             .Cart
             .Produsts
             .Select(p => new CartViewModel
             {
                 ProductName = p.Name,
                 ProductPrice = p.Price.ToString("F2")
             });

        }
    }
}
