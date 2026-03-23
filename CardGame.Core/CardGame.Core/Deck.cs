using System;
using System.Collections.Generic;

public class Deck
{
    private Stack<Card> cards;
    private static Random rng = new Random();

    public Deck()
    {
        var list = new List<Card>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                list.Add(new Card(suit, rank));
            }
        }

        Shuffle(list);
        cards = new Stack<Card>(list);
    }

    private void Shuffle(List<Card> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    public bool HasCards => cards.Count > 0;

    public Card Draw()
    {
        return cards.Pop();
    }
}