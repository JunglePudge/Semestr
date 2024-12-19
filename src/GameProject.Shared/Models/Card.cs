namespace GameProject.Shared.Models
{
    public enum CardType { Fact, Question }

    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public CardType Type { get; set; }
        public int Points { get; set; }
    }
}
