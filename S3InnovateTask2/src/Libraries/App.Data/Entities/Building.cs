namespace App.Data.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public ICollection<Reading> Readings { get; set; }
    }
}
