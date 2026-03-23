using System.Collections.Generic;

public class PlayerHands
{
    public Dictionary<string, Hand> Hands { get; } = new Dictionary<string, Hand>();

    public void AddPlayer(string name)
    {
        Hands[name] = new Hand();
    }
}