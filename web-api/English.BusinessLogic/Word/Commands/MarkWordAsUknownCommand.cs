namespace English.BusinessLogic
{
    public class MarkWordAsUknownCommand
    {
        public MarkWordAsUknownCommand(int wordId, int lessonId)
        {
            this.WordId = wordId;
            this.LessonId = lessonId;
        }

        public int WordId { get; set; }

        public int LessonId { get; set; }
    }
}
