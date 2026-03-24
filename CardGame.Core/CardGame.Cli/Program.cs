class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of players (2-4): ");
        int players = int.Parse(Console.ReadLine());

        if (players < 2 || players > 4)
        {
            Console.WriteLine("Invalid player count.");
            return;
        }

        WarEngine game = new WarEngine(players);
        game.Play();
    }
}