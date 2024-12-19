using System.Collections.Generic;
using GameProject.API.Models;

namespace GameProject.API.Services
{
    public class GameService
    {
        private readonly List<Cell> _board;
        private readonly List<Player> _players;
        private readonly Queue<Card> _cardDeck;

        public GameService(List<Cell> board, List<Player> players, Queue<Card> cardDeck)
        {
            _board = board;
            _players = players;
            _cardDeck = cardDeck;
        }

        public Player MovePlayer(int playerId, int steps)
        {
            var player = _players.Find(p => p.Id == playerId);
            if (player == null) throw new Exception("Player not found");

            player.Position += steps;

            if (player.Position >= _board.Count)
            {
                player.Position = _board.Count - 1;
                player.IsWinner = true; // Игрок достигает финиша
                return player;
            }

            var currentCell = _board[player.Position];

            switch (currentCell.Type)
            {
                case CellType.Fact:
                    var factCard = DrawCard(CardType.Fact);
                    player.Score += factCard.Points;
                    break;
                case CellType.Question:
                    var questionCard = DrawCard(CardType.Question);
                    player.Score += questionCard.Points; // Assume correct answer for now
                    break;
                case CellType.Black:
                    if (currentCell.ShortcutTarget.HasValue)
                        player.Position = currentCell.ShortcutTarget.Value;
                    break;
            }

            return player;
        }

        private Card DrawCard(CardType type)
        {
            foreach (var card in _cardDeck)
            {
                if (card.Type == type)
                {
                    _cardDeck.Dequeue();
                    return card;
                }
            }

            throw new Exception($"No cards of type {type} available");
        }

        public List<Player> GetPlayers() => _players;
        public List<Cell> GetBoard() => _board;

        public bool IsGameOver() => _players.Any(p => p.IsWinner);
    }
}
