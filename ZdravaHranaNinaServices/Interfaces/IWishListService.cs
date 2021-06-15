using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaServices.Interfaces
{
    public interface IWishListService
    {
        void Add(WishList wishList);
        void Edit(WishList wishList);
        void Delete(int id);
        IEnumerable<WishList> GetAllWishLists();
        WishList GetWishListById(int id);

        WishList GetWishListByBProductId(int productId);
        void DeleteByProductId(int productId);

        IEnumerable<WishList> GetAllWishlistByUserId(int userId);
    }
}
