namespace SofkaUPrueba.Core.Entities
{
    public class OptionsQuestions : BaseEntity
    {
        public string Name { get; set; }
        public bool Iscorrect { get; set; }
        public int QuestionsId { get; set; }
        public Questions Questions { get; set; }
    }
}
