using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZdravaHranaNinaData;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.Interfaces;

namespace ZdravaHranaNinaRepositories
{
    public class ShoppingCartRepository : IShoppingCartRepository 
    {
        private readonly DataContext _dataContext;

        public ShoppingCartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _dataContext.ShoppingCarts.Add(shoppingCart);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var shoppingCart = GetShoppingCartById(id);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();
        }

        public void DeleteByProductId(int productID)
        {
            var shoppingCart = GetShoppingCartByProductId(productID);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(int userId)
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.ProductId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            return result;
        }
        public ShoppingCart GetShoppingCartByProductId(int productId)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.ProductId == productId);
            return result;
        }
    }
}
