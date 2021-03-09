using System.Collections.Generic;

using DAL;
using Domain.GoodsDomain;
using Mappers;
using Services.Abstractions;
using System.Linq;

namespace Services.Services
{
    public class GoodsService:IService<GoodsModel>
    {
        private UnitOfWork Context { get; set; }
        public GoodsService(UnitOfWork context)
        {
            Context = context;
        }

        public void Add(GoodsModel item)
        {
            Context.Goods.Add(item.ToEntity());
        }

        public GoodsModel Get(int id)
        {
            return Context.Goods.GetById(id).ToModel();
        }

        public List<GoodsModel> GetAll()
        {
            return Context.Goods.GetAll()
                .Select(goods => goods.ToModel())
                .ToList();
        }

        public void Delete(GoodsModel item)
        {
            Context.Goods.Delete(item.ToEntity().Id);
        }
    }
}