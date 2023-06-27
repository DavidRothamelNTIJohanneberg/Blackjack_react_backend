namespace blackjackReactBackend.GameClasses
{
    public class GameLoop
    {
        List<Player> players = new();

        Dealer dealer;

        public GameLoop()
        {
            dealer = new();
            for (int i = 0; i < 2; i++)
            {
                players.Add(new(100));
            }
        }


    }
}
