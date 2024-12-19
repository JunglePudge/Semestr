namespace GameProject.Shared.Models
{
    public enum CellType { Start, Finish, Fact, Question, Black, Normal }

    public class Cell
    {
        public int Id { get; set; }
        public CellType Type { get; set; }
        public int? ShortcutTarget { get; set; } // Сокращенный маршрут
    }
}
