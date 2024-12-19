using System.Collections.Generic;
using GameProject.API.Models;

namespace GameProject.API.Services
{
    public class GameInitializationService
    {
        public List<Cell> InitializeBoard(int size)
        {
            var board = new List<Cell>();

            // ������� ��������� ������
            board.Add(new Cell { Id = 0, Type = CellType.Start });

            // ������� ������������� ������
            for (int i = 1; i < size - 1; i++)
            {
                var cellType = GetRandomCellType();
                board.Add(new Cell { Id = i, Type = cellType });

                // ��� ������ ������ ��������� ����������� �������
                if (cellType == CellType.Black)
                {
                    var shortcutTarget = i + 2; // ������: ������ �� 2 ������ ������
                    if (shortcutTarget < size - 1)
                    {
                        board[i].ShortcutTarget = shortcutTarget;
                    }
                }
            }

            // ������� �������� ������
            board.Add(new Cell { Id = size - 1, Type = CellType.Finish });

            return board;
        }

        public Queue<Card> InitializeCardDeck()
        {
            var deck = new Queue<Card>();

            // ��������� ����� ������
            for (int i = 0; i < 10; i++)
            {
                deck.Enqueue(new Card
                {
                    Id = i,
                    Content = $"Fact #{i + 1}: This is an interesting fact.",
                    Type = CardType.Fact,
                    Points = 1
                });
            }

            // ��������� ����� ��������
            for (int i = 10; i < 20; i++)
            {
                deck.Enqueue(new Card
                {
                    Id = i,
                    Content = $"Question #{i - 9}: What is 2 + 2?",
                    Type = CardType.Question,
                    Points = 2 // ��������� ���������� �����
                });
            }

            return deck;
        }

        private CellType GetRandomCellType()
        {
            var random = new Random();
            int value = random.Next(0, 100);

            return value switch
            {
                < 50 => CellType.Normal,
                < 70 => CellType.Fact,
                < 90 => CellType.Question,
                _ => CellType.Black,
            };
        }
    }
}
