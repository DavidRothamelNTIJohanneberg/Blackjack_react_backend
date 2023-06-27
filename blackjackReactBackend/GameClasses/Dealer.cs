namespace blackjackReactBackend.GameClasses
{
    public class Dealer
    {
        List<Card> hand = new();
        public bool wants = true;

        public void PrintHand(bool show)
        {
            if (show)
            {
                foreach (Card i in hand)
                {
                    Console.WriteLine(i.value);
                }
            }
            else
            {
                Console.WriteLine(hand[0].value);
                Console.WriteLine("?");
            }
        }

        public void TakeCard()
        {
            hand.Add(Deck.Deal_card());
        }

        public int Sum()
        {
            int sum = 0;
            foreach (Card i in hand)
            {
                sum += i.blackjackValue;
            }

            return sum;
        }

        private bool SoftAce()
        {
            if (hand.Count == 2)
            {
                if (((hand[0].value == 1) && (hand[1].value != 1)) || ((hand[1].value == 1) && (hand[0].value != 1)))
                {
                    return true;
                }
            }

            return false;
        }

        public void Decision()
        {
            if (Sum() < 17)
            {
                TakeCard();
            }
            else if (Sum() == 17 && SoftAce())
            {
                TakeCard();
            }
            else
            {
                wants = false;
            }
        }
    }
}
