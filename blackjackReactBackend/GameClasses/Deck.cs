namespace blackjackReactBackend.GameClasses
{
    public class Deck
    {
        List<Card> deck = new List<Card>();

        public Deck(int amount)
        {
            deck = DeckBuilder(amount);
        }

        private List<Card> DeckBuilder(int amount)
        {
            List<Card> temp = new List<Card>();
            string[] colors = { "Hearts", "Diamonds", "Spades", "Clubs" };
            for (int i = 0; i < amount; i++)
            {
                foreach (string color in colors)
                {
                    temp.Add(new Card(1, 11, color));
                    for (int j = 2; j <= 13; j++)
                    {
                        if (j > 10)
                        {
                            temp.Add(new Card(j, 10, color));
                        }

                        temp.Add(new Card(j, j, color));
                    }
                }
            }

            return temp;
        }
    }
}
