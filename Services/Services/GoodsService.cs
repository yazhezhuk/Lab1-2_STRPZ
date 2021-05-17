using System.Collections.Generic;

using DAL;
using Domain.GoodsDomain;
using Mappers;
using Services.Abstractions;
using System.Linq;
using DAL.UnitOfWork;

namespace Services.Services
{
    public class GoodsService: IGoodsService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private GoodsMapper Mapper { get; }
        public GoodsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Mapper = new GoodsMapper();
        }

        public void Add(GoodsModel item)
        {
            UnitOfWork.Goods.AddOrUpdate(Mapper.ToEntity(item));
        }

        public GoodsModel Get(int id)
        {
            return Mapper.ToModel(UnitOfWork.Goods.GetById(id));
        }

        public List<GoodsModel> GetAll()
        {
            return UnitOfWork.Goods.GetAll()
                .Select(goods => Mapper.ToModel(goods))
                .ToList();
        }

        public void Delete(GoodsModel item)
        {
            UnitOfWork.Goods.Delete(Mapper.ToEntity(item));
        }

        public void Update(GoodsModel item)
        {
	        throw new System.NotImplementedException();
        }
    }
}