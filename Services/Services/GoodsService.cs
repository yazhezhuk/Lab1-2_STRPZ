using System.Collections.Generic;

using DAL;
using Domain.GoodsDomain;
using Mappers;
using Services.Abstractions;
using System.Linq;

namespace Services.Services
{
    public class GoodsService: IGoodsService
    {
        private IUnitOfWork Context { get; set; }
        private GoodsMapper Mapper { get; }
        public GoodsService(IUnitOfWork context)
        {
            Context = context;
            Mapper = new GoodsMapper();
        }

        public void Add(GoodsModel item)
        {
            Context.Goods.AddOrUpdate(Mapper.ToEntity(item));
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