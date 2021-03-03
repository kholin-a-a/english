namespace English.BusinessLogic
{
    public class MarkWordAsCompletedCommand
    {
        public int WordId { get; set; }

        public int LessonId { get; set; }

        public string Text { get; set; }
    }
}
