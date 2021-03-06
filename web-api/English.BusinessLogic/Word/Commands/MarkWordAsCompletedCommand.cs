namespace English.BusinessLogic
{
    public class MarkWordAsCompletedCommand
    {
        public MarkWordAsCompletedCommand(int wordId, int lessonId, string text)
        {
            this.WordId = wordId;
            this.LessonId = lessonId;
            this.Text = text;
        }

        public int WordId { get; set; }

        public int LessonId { get; set; }

        public string Text { get; set; }
    }
}
