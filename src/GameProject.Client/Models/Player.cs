namespace GameProject.API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 0;
        public int Score { get; set; } = 0;
    }
}
