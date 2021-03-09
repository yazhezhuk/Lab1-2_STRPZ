namespace Entities
{
    public class WarehouseEntity : ISaveableEntity
    {
        public int Id { get; set; }

        public int RelativeDistance { get; set; }
        public string CompanyName { get; set; }
    }
}