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

            hands = new() { new Hand(removeMoney(10)) }; //Have to fix so that it in someway always removes from money
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
        /*public void Split_hand()
        {
            Card temp = hand[0][1];
        }*/

        public class Hand
        {
            public bool blackjack = false;
            public bool broke = false;
            public bool wants = true;
            public int bet;
            public List<Card> hand = new();

            public Hand(int bet)
            {
                this.bet = bet;
            }

            public void Take_card()//Should be private or not?
            {
                hand.Add(Deck.Deal_card());
            }

            public void Stand()
            {
                wants = false;
            }

            public void Double()
            {
                bet *= 2;
                wants = false;
                Take_card();
            }

            public Card Split()
            {
                Card temp = hand[0];
                hand.RemoveAt(0);
                return temp;
            }
        }

    }
}
