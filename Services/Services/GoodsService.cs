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
        private GoodsMapper Mapper { get; }
        public GoodsService(UnitOfWork context)
        {
            Context = context;
            Mapper = new GoodsMapper();
        }

        public void Add(GoodsModel item)
        {
            Context.Goods.Add(Mapper.ToEntity(item));
        }

        public GoodsModel Get(int id)
        {
            return Mapper.ToModel(Context.Goods.GetById(id));
        }

        public List<GoodsModel> GetAll()
        {
            return Context.Goods.GetAll()
                .Select(goods => Mapper.ToModel(goods))
                .ToList();
        }

        public void Delete(GoodsModel item)
        {
            Context.Goods.Delete(Mapper.ToEntity(item).Id);
        }
    }
}