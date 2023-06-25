namespace blackjackReactBackend.GameClasses
{
    public class Player
    {
        private static int numberOfPlayers = 0;
        public readonly int key;
        //When splitting create another hand
        //Easy way of doing it is to add starting hand as a nested part of a list
        public bool split = false;
        public bool blackjack = false;
        public bool broke = false;
        private Deck deck;

        //Add hand as an class that is a part of player?
        //So that the hand keeps count of the bools
        //On the other hand it wouldn't be much left for the player class to do then
        public List<Card> hand = new();

        public Player(Deck deck)
        {
            this.deck = deck;

            numberOfPlayers++;
            key = numberOfPlayers;
        }

        private void Take_card()
        {
            hand.Add(deck.Deal_card());
        }


    }
}
