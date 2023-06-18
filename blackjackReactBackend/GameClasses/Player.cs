namespace blackjackReactBackend.GameClasses
{
    public class Player
    {
        public string name;
        public Player(string name)
        {
            //Maybe add static so that each player gets its own key
            //And thus it is easier to loop through them?
            this.name = name;
        }


    }
}
