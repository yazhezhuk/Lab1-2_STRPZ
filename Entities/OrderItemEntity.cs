namespace Entities
{
    public class OrderItemEntity : IEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int GoodsId { get; set; }
    }
}