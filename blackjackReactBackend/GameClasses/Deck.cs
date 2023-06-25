namespace blackjackReactBackend.GameClasses
{
    public static class Deck
    {
        private static Random rand = new();
        static List<Card> deck = new List<Card>();

        public static void DeckBuilder(int amount)
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

            deck = temp;
        }

        public static void Shuffle()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = deck.Count - 1; j > 0; j--)
                {
                    int k = rand.Next(j + 1);
                    Card temp = deck[j];
                    deck[j] = deck[k];
                    deck[k] = temp;
                }
            }
        }

        public static Card Deal_card()
        {
            Card temp = deck[0];
            deck.RemoveAt(0);
            return temp;
        }
    }
}
