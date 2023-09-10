using LanguageExt.ClassInstances.Pred;

namespace MatchDetailsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int choice = 0;
            MatchManagement matchManagement = new MatchManagement();
            do
            {
                Console.WriteLine("******* WELCOME TO MATCH DETAILS MANAGEMENT SYSTEM *******");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" Enter 1 to Display the Match Details ");
                Console.WriteLine(" Enter 2 to Display the Match Details By ID ");
                Console.WriteLine(" Enter 3 to Update the Scores of the Match ");
                Console.WriteLine(" Enter 4 to Remove a particular Match By ID ");
                Console.WriteLine(" Enter 5 to Sort Date & Time in Ascending or Decending ");
                Console.WriteLine(" Enter 6 to Sort Location in Ascending or Decending ");
                Console.WriteLine(" Enter 7 to Sort Sport in Ascending or Decending ");
                Console.WriteLine(" Enter 8 to Display Match Filtered by Sport ");
                Console.WriteLine(" Enter 9 to Display Match Filtered by Location ");
                Console.WriteLine(" Enter 10 to Display Match Filtered by DateTime ");
                Console.WriteLine(" Enter 11 to Display Team Statistics ");
                Console.WriteLine(" Enter 12 to Display Sport Statistics ");
                Console.WriteLine(" Enter 13 to Display the Matches by entering Keywords related to Sport,TeamNames or Location ");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(" Enter a Value:",choice);
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    matchManagement.Display(matchManagement.matches);
                    break;
                    case 2:
                    matchManagement.MatchDetails();
                    break;
                    case 3:
                    matchManagement.UpdateScore();
                    break; 
                    case 4:
                    matchManagement.RemoveMatch();
                    break;
                    case 5:
                    matchManagement.SortDateTime();
                    break; 
                    case 6:
                    matchManagement.SortLocation();
                    break;
                    case 7:
                    matchManagement.SortSport();
                    break;
                    case 8:
                    matchManagement.FilterBySport();
                    break;
                    case 9:
                    matchManagement.FilterByLocation();
                    break;
                    case 10:
                    matchManagement.FilterByDateTime();
                    break;
                    case 11:
                    matchManagement.Statistics();
                    break;
                    case 12:
                    matchManagement.Statistics();
                    break;
                    case 13:
                    matchManagement.SearchMatches();
                    break;
                }
            }while(choice!=0);
        }
    }
}