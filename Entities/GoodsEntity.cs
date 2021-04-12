using Types;

namespace Entities
{
    public class GoodsEntity : IEntity
    {
        public int Id { get; set; }

        public int Price { get; set; }
        public string Name { get; set; }
        public GoodsType Type { get; set; }
    }
}