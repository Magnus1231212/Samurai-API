namespace Samurai.DAL.Models
{
    public class SamuraiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Horse Horse { get; set; }
        public ICollection<Battle> Battles { get; set; }
    }
}