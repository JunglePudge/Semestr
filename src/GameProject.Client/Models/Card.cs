namespace GameProject.API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public CardType Type { get; set; } // Fact or Question
        public int Points { get; set; } = 1; // Default points
    }

    public enum CardType
    {
        Fact,
        Question
    }
}