namespace blackjackReactBackend.GameClasses
{
    public class Player
    {
        private static int numberOfPlayers = 0;
        public readonly int key;
        public int money;

        public void addMoney(int amount)
        {
            money += amount;
        }

        private int removeMoney(int amount)
        {
            if (amount > money)
            {
                throw new InvalidOperationException("Not enough money");
            }

            money -= amount;

            return amount;
        }
        //Add hand as an class that is a part of player?
        //So that the hand keeps count of the bools
        //On the other hand it wouldn't be much left for the player class to do then
        public List<Hand> hands;

        public Player(int money)
        {
            this.money = money;

            numberOfPlayers++;
            key = numberOfPlayers;

            hands = new() { new Hand(removeMoney(10), this) };
        }

        public void Print_hand()
        {
            int x = 0;
            foreach (Hand i in hands)
            {
                x++;
                Console.WriteLine("Hand " + x);
                foreach (Card j in i.hand)
                {
                    Console.WriteLine(j.color);
                    Console.WriteLine(j.value);
                }
                Console.WriteLine("");
            }

        }
        // Has to be reworked
        public void Split_hand()
        {
            hands.Add(new Hand(hands[0].bet, this, hands[0].Split()));
            hands[1].Take_card();
        }

        public class Hand
        {
            public bool blackjack = false;
            public bool wants = true;
            public int bet;
            public List<Card> hand = new();
            private Player player;

            public Hand(int bet, Player player, Card card = null)
            {
                this.bet = bet;
                this.player = player;
                if (card != null)
                {
                    hand.Add(card);
                }
            }

            public void Take_card()
            {
                hand.Add(Deck.Deal_card());
                CheckAce();
            }

            public void Stand()
            {
                wants = false;
            }

            public void Double()
            {
                bet += player.removeMoney(bet);
                wants = false;
                Take_card();
                CheckAce();
            }

            public Card Split()
            {
                Card temp = hand[0];
                hand.RemoveAt(0);
                return temp;
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
}
