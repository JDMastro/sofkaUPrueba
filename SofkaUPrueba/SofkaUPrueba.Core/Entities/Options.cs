namespace SofkaUPrueba.Core.Entities
{
    public class Options
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Iscorrect { get; set; }

        public Questions Questions { get; set; }
    }
}
