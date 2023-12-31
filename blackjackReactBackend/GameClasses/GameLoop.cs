﻿namespace blackjackReactBackend.GameClasses
{
    public static class GameLoop
    {
        static List<Player> players = new();

        static Dealer dealer = new();

        public static void Build(int amount_of_players)
        {
            Start(amount_of_players);
            Mid();
            End();
        }

        private static void Start(int amount_of_players)
        {
            Deck.DeckBuilder(6);
            Deck.Shuffle();

            for (int i = 0; i < amount_of_players; i++)
            {
                players.Add(new(100));
            }

            for (int i = 0; i < 2; i++)
            {
                dealer.TakeCard();
                foreach (Player j in players)
                {
                    j.hands[0].Take_card();
                }
            }

            //Some sort of sending data to Frontend here, so that it can see the hands
        }

        private static void Mid()
        {
            //Send data of the players hand after every action
            foreach (Player i in players)
            {
                //The while-loop should probably be some sort of method
                //But I do not know where to keep it
                while (i.hands[0].wants)
                {
                    //Probably should add some sort of restraints for what actions you really can take
                    //And which you cannot
                    //Get input from Front
                    switch ("s")//Gets input from react
                    {
                        case "s":
                            i.hands[0].Stand();
                            break;
                        case "h":
                            i.hands[0].Take_card();
                            break;
                        case "d":
                            i.hands[0].Double();
                            break;
                        case "/":
                            i.Split_hand();
                            break;
                    }
                }

                if (1 != i.hands.Count)
                {
                    while (i.hands[1].wants)
                    {
                        switch ("s")
                        {
                            case "s":
                                i.hands[0].Stand();
                                break;
                            case "h":
                                i.hands[0].Take_card();
                                break;
                            case "d":
                                i.hands[0].Double();
                                break;
                            case "/":
                                i.Split_hand();
                                break;
                        }
                    }
                }
            }
            while (dealer.wants)
            {
                dealer.Decision();
            }
        }

        private static void End()
        {
            int dealer_sum = dealer.Sum();
            if (!dealer.bust)
            {
                foreach (Player i in players)
                {
                    foreach (Player.Hand j in i.hands)
                    {
                        if (j.Sum() > dealer_sum)
                        {
                            i.money += j.bet;
                            j.bet = 0;
                        }
                        else
                        {
                            j.bet = 0;
                        }
                    }
                }
            }
            else
            {
                foreach (Player i in players)
                {
                    foreach (Player.Hand j in i.hands)
                    {
                        if (j.Sum() < 22)
                        {
                            i.money += j.bet;
                            j.bet = 0;
                        }
                        else
                        {
                            j.bet = 0;
                        }
                    }
                }
            }
        }
    }
}
