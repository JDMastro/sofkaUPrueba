namespace SofkaUPrueba.Core.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public Categories Categories { get; set; }
    }
}
