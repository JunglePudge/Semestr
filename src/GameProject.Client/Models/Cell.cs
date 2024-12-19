namespace GameProject.API.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public CellType Type { get; set; } = CellType.Normal;
        public int? ShortcutTarget { get; set; } // For black cells leading to another route
    }

    public enum CellType
    {
        Start,
        Finish,
        Normal,
        Fact,
        Question,
        Black
    }
}