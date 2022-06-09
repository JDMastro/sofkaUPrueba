namespace SofkaUPrueba.Core.Entities
{
    public class Options : BaseEntity
    {
        public string Name { get; set; }
        public bool Iscorrect { get; set; }
        public int QuestionsId { get; set; }
        public Questions Questions { get; set; }
    }
}
