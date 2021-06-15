using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNinaRepositories.Interfaces
{
    public interface IWishListRepository
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
