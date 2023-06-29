namespace blackjackReactBackend.GameClasses
{
    public class Dealer
    {
        List<Card> hand = new();
        public bool wants = true;
        public bool bust = false;

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

            if (sum > 21)
            {
                bust = true;
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
                CheckAce();
            }
            else if (Sum() == 17 && SoftAce())
            {
                TakeCard();
                CheckAce();
            }
            else
            {
                wants = false;
            }
        }

        private void CheckAce()
        {
            if (Sum() > 21)
            {
                foreach (Card i in hand)
                {
                    if (i.blackjackValue == 11)
                    {
                        i.ChangeValue();
                        break;
                    }
                }
            }
        }
    }
}
