using System.Collections.Generic;
using Entities;

namespace DAL.Repositories.Abstractions
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        List<GoodsEntity> GetOrderGoods(int id);
    }
}