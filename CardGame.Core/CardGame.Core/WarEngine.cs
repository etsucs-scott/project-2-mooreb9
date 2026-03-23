using System;
using System.Collections.Generic;
using System.Linq;

public class WarGame
{
    private Dictionary<string, Hand> playerHands = new();
    private const int ROUND_LIMIT = 10000;

    public WarGame(int playerCount)
    {
        for (int i = 1; i <= playerCount; i++)
            playerHands.Add($"Player {i}", new Hand());

        DealCards();
    }

    private void DealCards()
    {
        Deck deck = new Deck();
        var players = playerHands.Keys.ToList();
        int index = 0;

        while (deck.HasCards)
        {
            playerHands[players[index]].AddCard(deck.Draw());
            index = (index + 1) % players.Count;
        }
    }

    public void Play()
    {
        int round = 1;

        while (round <= ROUND_LIMIT)
        {
            RemoveEliminatedPlayers();

            if (playerHands.Count == 1)
            {
                Console.WriteLine($"Winner: {playerHands.Keys.First()}");
                return;
            }

            Console.WriteLine($"\nRound {round}");

            List<Card> pot = new();
            var playedCards = new Dictionary<string, Card>();

            foreach (var player in playerHands.Keys.ToList())
            {
                if (playerHands[player].Count > 0)
                {
                    var card = playerHands[player].PlayCard();
                    playedCards[player] = card;
                    pot.Add(card);

                    Console.WriteLine($"{player}: {card}");
                }
            }

            ResolveRound(playedCards, pot);

            PrintCounts();

            round++;
        }

        EndByRoundLimit();
    }

    private void ResolveRound(Dictionary<string, Card> playedCards, List<Card> pot)
    {
        var highest = playedCards.Max(x => x.Value.Rank);

        var winners = playedCards
            .Where(x => x.Value.Rank == highest)
            .Select(x => x.Key)
            .ToList();

        if (winners.Count == 1)
        {
            var winner = winners.First();
            playerHands[winner].AddCards(pot);

            Console.WriteLine($"Winner: {winner}");
        }
        else
        {
            Console.WriteLine($"Tie between {string.Join(" and ", winners)}!");
            Console.WriteLine($"Pot includes: {string.Join(", ", pot)}");

            TieBreaker(winners, pot);
        }
    }

    private void TieBreaker(List<string> tiedPlayers, List<Card> pot)
    {
        var played = new Dictionary<string, Card>();

        foreach (var player in tiedPlayers)
        {
            if (playerHands[player].Count == 0)
            {
                Console.WriteLine($"{player} eliminated (no card for tiebreaker)");
                playerHands.Remove(player);
                continue;
            }

            var card = playerHands[player].PlayCard();
            played[player] = card;
            pot.Add(card);
        }

        Console.WriteLine("Tiebreaker: " +
            string.Join(" | ", played.Select(p => $"{p.Key}: {p.Value}")));

        ResolveRound(played, pot);
    }

    private void RemoveEliminatedPlayers()
    {
        var eliminated = playerHands
            .Where(p => p.Value.Count == 0)
            .Select(p => p.Key)
            .ToList();

        foreach (var player in eliminated)
        {
            Console.WriteLine($"{player} eliminated!");
            playerHands.Remove(player);
        }
    }

    private void PrintCounts()
    {
        Console.WriteLine("Card counts: " +
            string.Join(", ", playerHands.Select(p => $"{p.Key}={p.Value.Count}")));
    }

    private void EndByRoundLimit()
    {
        var max = playerHands.Max(p => p.Value.Count);
        var winners = playerHands.Where(p => p.Value.Count == max).ToList();

        if (winners.Count == 1)
            Console.WriteLine($"Winner by card count: {winners[0].Key}");
        else
            Console.WriteLine("Game ends in a draw.");
    }
}