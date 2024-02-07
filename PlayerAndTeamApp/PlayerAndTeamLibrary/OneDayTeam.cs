using System.Collections.Generic;

namespace PlayerAndTeamLibrary
{
    public class OneDayTeam : ITeam // derived class "OneDayTeam" to implement "ITeam" interface functionalities
    {
        public int Capacity{ get; set; }
        public OneDayTeam() // constructor to set the capacity property to 11 
        {
            Capacity = 11;
        }

        public List<Player> oneDayTeam = new List<Player>();

        public void Add(Player player) // adding a player 
        {
            if (oneDayTeam.Count <= Capacity)
            {
            oneDayTeam.Add(player);
            }
            else
            {
                System.Console.WriteLine("Cannot have more than 11 players");
            }
        }
        public void Remove(int playerId) // removing the player
        {
            for (int i = 0; i < oneDayTeam.Count; i++)
            {
                if (oneDayTeam[i].PlayerId == playerId)
                {
                    oneDayTeam.RemoveAt(i);
                }
            }
        }
        public Player GetPlayerById(int playerId) // get player by passing PlayerId 
        {
            Player playerDetails = new Player(); 
            foreach (var item in oneDayTeam)
            {
                if (item.PlayerId == playerId)
                {
                    playerDetails = item;
                    break;
                }
            }
            return playerDetails;
        }
        public Player GetPlayerByName(string playerName) // get player by PlayerName
        {
            Player playerDetails = new Player();
            foreach (var item in oneDayTeam)
            {
                if (item.PlayerName == playerName)
                {
                    playerDetails = item;
                    break;
                }
            }
            return playerDetails;

        }
        public List<Player> GetAllPlayers() // get all players 
        {
            List<Player> allPlayerDetails = new List<Player>();
            foreach (var item in oneDayTeam)
            {
                allPlayerDetails.Add(item);
            }
            return allPlayerDetails;
        }
    }
}
