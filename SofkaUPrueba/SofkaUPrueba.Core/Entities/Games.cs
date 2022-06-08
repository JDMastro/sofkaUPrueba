namespace SofkaUPrueba.Core.Entities
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Players Players { get; set; }
    }
}
