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
    public class WishListRepository : IWishListRepository
    {
        private readonly DataContext _dataContext;

        public WishListRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(WishList wishList)
        {
            _dataContext.WishLists.Add(wishList);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var wishlist = GetWishListById(id);
            _dataContext.WishLists.Remove(wishlist);
            _dataContext.SaveChanges();
        }

        public void DeleteByProductId(int productId)
        {
            var wishList = GetWishListByBProductId(productId);
            _dataContext.WishLists.Remove(wishList);
            _dataContext.SaveChanges();
        }

        public void Edit(WishList wishList)
        {
            _dataContext.WishLists.Update(wishList);
            _dataContext.SaveChanges();
        }

        public IEnumerable<WishList> GetAllWishlistByUserId(int userId)
        {
            var result = _dataContext.WishLists.AsEnumerable().Where(x => x.UserId == userId).DistinctBy(x => x.ProductId);
            return result;
        }

        public IEnumerable<WishList> GetAllWishLists()
        {
            var result = _dataContext.WishLists.AsEnumerable();
            return result;
        }

        public WishList GetWishListByBProductId(int productId)
        {
            var result = _dataContext.WishLists.FirstOrDefault(x => x.ProductId == productId);
            return result;
        }

        public WishList GetWishListById(int id)
        {
            var result = _dataContext.WishLists.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
