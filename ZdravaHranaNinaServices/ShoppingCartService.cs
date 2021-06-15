using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.Interfaces;
using ZdravaHranaNinaServices.Interfaces;

namespace ZdravaHranaNinaServices
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);
        }

        public void Delete(int id)
        {
            _shoppingCartRepository.Delete(id);
        }

        public void DeleteByProductId(int productId)
        {
            _shoppingCartRepository.DeleteByProductId(productId);
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _shoppingCartRepository.GetAllItemsInCart();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(int userId)
        {
            var result = _shoppingCartRepository.GetAllItemsInCartByUserId(userId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            var result = _shoppingCartRepository.GetShoppingCartById(id);
            return result;
        }

        public ShoppingCart GetShoppingCartByProductId(int productId)
        {
            var result = _shoppingCartRepository.GetShoppingCartByProductId(productId);
            return result;
        }
    }
}
