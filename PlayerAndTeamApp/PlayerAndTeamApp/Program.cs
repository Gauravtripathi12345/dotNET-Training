using PlayerAndTeamLibrary;
using System;
using System.Collections.Generic;

namespace PlayerAndTeamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam oneDayTeam = new OneDayTeam();
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("Enter your choice:\n 1:To Add Player \n 2:To Remove Player by Id \n 3.Get Player By Id \n 4.Get Player by Name \n 5.Get All Players:");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var playerToBeAdded = EnterPlayerDetails();
                        oneDayTeam.Add(playerToBeAdded);
                        Console.WriteLine("Player is added successfully");
                        isContinue = Confirmation();
                        break;

                    case 2:
                        int idOfPlayerToBeRemoved = RemovePlayerById();
                        oneDayTeam.Remove(idOfPlayerToBeRemoved);
                        Console.WriteLine("Player is removed successfully");
                        isContinue = Confirmation();
                        break;

                    case 3:
                        GetPlayerById(oneDayTeam);
                        isContinue = Confirmation();
                        break;


                    case 4:
                        GetPlayerByName(oneDayTeam);
                        isContinue = Confirmation();
                        break;

                    case 5:
                        var playerList = oneDayTeam.GetAllPlayers();
                        ShowAllPlayers(playerList);
                        isContinue = Confirmation();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        isContinue = Confirmation();
                        break;
                }
            }

        }
        public static Player EnterPlayerDetails()
        {
            Player player = new Player();
            Console.Write("Enter Player ID: ");
            player.PlayerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Player Name: ");
            player.PlayerName = Console.ReadLine();

            Console.Write("Enter Player Age: ");
            player.PlayerAge = Convert.ToInt32(Console.ReadLine());

            return player;
        }

        public static int RemovePlayerById()
        {
            Console.WriteLine("Enter the player ID");
            int playerId = Convert.ToInt32(Console.ReadLine());
            return playerId;
        }

        public static void GetPlayerById(OneDayTeam oneDayTeam)
        {
            Console.WriteLine("Enter the player ID");
            int playerId = Convert.ToInt32(Console.ReadLine());
            Player player = oneDayTeam.GetPlayerById(playerId);
            if(player.PlayerId==0 && player.PlayerName == null && player.PlayerAge == 0)
            {
                Console.WriteLine("Player does not exist");
            }
            else
            {
            Console.WriteLine(player.PlayerId + " " + player.PlayerName + " " + player.PlayerAge);
            }
        }

        public static void GetPlayerByName(OneDayTeam oneDayTeam)
        {
            Console.WriteLine("Enter the player name");
            string playerName = Console.ReadLine();
            // OneDayTeam oneDayTeam = new OneDayTeam();
            Player player = oneDayTeam.GetPlayerByName(playerName);
            if (player.PlayerId == 0 && player.PlayerName == null && player.PlayerAge == 0)
            {
                Console.WriteLine("Player does not exist");
            }
            else
            {
            Console.WriteLine(player.PlayerId + " " + player.PlayerName + " " + player.PlayerAge);
            }
        }

        public static void ShowAllPlayers(List<Player> playerList)
        {
            foreach (var item in playerList)
            {
                Console.WriteLine(item.PlayerId + " " + item.PlayerName + " " + item.PlayerAge);
            }
        }

        public static bool Confirmation()
        {
            Console.WriteLine("Do you want to Continue (yes/no)?:");
            string confirmationResult = Console.ReadLine();

            if (confirmationResult == "yes" || confirmationResult == "y" || confirmationResult == "YES" || confirmationResult == "Yes" || confirmationResult == "Y")
            {
                return true;
            }
            else if(confirmationResult == "no" || confirmationResult == "n" || confirmationResult == "NO" || confirmationResult == "N" || confirmationResult == "No")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter valid input");
                return Confirmation();
            }
        }

    }
}
