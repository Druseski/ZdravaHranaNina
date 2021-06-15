using System;
using System.Collections.Generic;
using System.Text;
using ZdravaHranaNinaRepositories.Interfaces;
using ZdravaHranaNinaServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZdravaHranaNinaServices
{
    public class OrderService : IOrderService 
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
    }
}
