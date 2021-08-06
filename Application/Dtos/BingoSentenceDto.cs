namespace Application.Dtos
{
    public class BingoSentenceDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Sentence { get; set; }
        public bool IsTagedByAdmin { get; set; }
    }
}