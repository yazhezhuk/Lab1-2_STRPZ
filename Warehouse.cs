namespace Lab1Components
{
    public class Warehouse : ISaveableEntity, ISelectable
    {
        public int Id { get; set; }

        public bool Selected { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }

        public Warehouse(int id,string name, int distance)
        {
            Id = id;
            Name = name;
            Distance = distance;
        }
    }
}