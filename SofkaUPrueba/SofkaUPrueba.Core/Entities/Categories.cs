namespace SofkaUPrueba.Core.Entities
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }

        //public Games Games { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
