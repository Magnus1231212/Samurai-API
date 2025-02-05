namespace DeSejeBanditter.DAL.Models
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Horse Horse { get; set; }
        public ICollection<Battle> Battles { get; set; }
    }
}
