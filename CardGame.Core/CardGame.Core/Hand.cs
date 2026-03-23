using System.Collections.Generic;

public class Hand
{
    private Queue<Card> cards = new Queue<Card>();

    public int Count => cards.Count;

    public void AddCard(Card card)
    {
        cards.Enqueue(card);
    }

    public void AddCards(IEnumerable<Card> wonCards)
    {
        foreach (var c in wonCards)
            cards.Enqueue(c);
    }

    public Card PlayCard()
    {
        return cards.Dequeue();
    }
}