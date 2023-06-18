namespace blackjackReactBackend.GameClasses
{
    public class Card
    {
        public int value;
        public int blackjackValue;
        public string color;

        public Card(int value, int blackjackValue, string color)
        {
            this.value = value;
            this.blackjackValue = blackjackValue;
            this.color = color;
        }

        public void ChangeValue()
        {
            if (blackjackValue == 11)
            {
                blackjackValue = 1;
            }
        }
    }
}
