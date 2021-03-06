namespace English.BusinessLogic
{
    public class GetWordDefinitionsQuery
    {
        public GetWordDefinitionsQuery(int wordId)
        {
            this.WordId = wordId;
        }

        public int WordId { get; set; }
    }
}
