namespace SofkaUPrueba.Core.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }

        public Games Games { get; set; }
    }
}
