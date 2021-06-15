using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.Interfaces
{
    public interface IShoppingCartService
    {
        void Add(ShoppingCart shoppingCart);
        void Delete(int id);
        void DeleteByProductId(int productId);

        ShoppingCart GetShoppingCartById(int id);

        IEnumerable<ShoppingCart> GetAllItemsInCart();
        IEnumerable<ShoppingCart> GetAllItemsInCartByUserId(int userId);
        ShoppingCart GetShoppingCartByProductId(int productId);
    }
}
