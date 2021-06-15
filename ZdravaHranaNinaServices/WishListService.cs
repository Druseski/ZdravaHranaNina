using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaEntities;
using ZdravaHranaNinaRepositories.Interfaces;
using ZdravaHranaNinaServices.Interfaces;

namespace ZdravaHranaNinaServices
{
    public class WishListService : IWishListService 
    {
        private readonly IWishListRepository _wishListRepository;

        public WishListService(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public void Add(WishList wishList)
        {
            _wishListRepository.Add(wishList);
        }

        public void Delete(int id)
        {
            _wishListRepository.Delete(id);
        }

        public void DeleteByProductId(int productId)
        {
            _wishListRepository.DeleteByProductId(productId);
        }

        public void Edit(WishList wishList)
        {
            _wishListRepository.Edit(wishList);
        }

        public IEnumerable<WishList> GetAllWishlistByUserId(int userId)
        {
            var result = _wishListRepository.GetAllWishlistByUserId(userId);
            return result;
        }

        public IEnumerable<WishList> GetAllWishLists()
        {
            var result = _wishListRepository.GetAllWishLists();
            return result;
        }

        public WishList GetWishListByBProductId(int productId)
        {
            var result = _wishListRepository.GetWishListByBProductId(productId);
            return result;
        }

        public WishList GetWishListById(int id)
        {
            var result = _wishListRepository.GetWishListById(id);
            return result;
        }
    }
}
