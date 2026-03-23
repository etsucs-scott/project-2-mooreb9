using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

public class PlayedCards
{
    public Dictionary<string, Card> Cards { get; } = new Dictionary<string, Card>();

    public void Clear()
    {
        Cards.Clear();
    }
}