using LanguageExt.ClassInstances;
using LanguageExt.ClassInstances.Pred;
using LanguageExt.Pipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class MatchManagement
    {
        public List<MatchDetails> matches = new List<MatchDetails>();
        public MatchManagement()
        {
            matches.Add(new MatchDetails(1,"Cricket",new DateTime(2023,06,22,22,05,27),"Mumbai","Mumbai Indians","Chennai Super Kings",200,195));
            matches.Add(new MatchDetails(2, "FootBall", new DateTime(2022, 12, 18, 20, 30, 00), "Qatar", "Argentina", "France", 3, 3));
            matches.Add(new MatchDetails(3, "Table-Tennis", new DateTime(2021, 12, 18, 20, 34, 00), "Portugal", "Brazil", "Spain", 19, 21));
            matches.Add(new MatchDetails(4, "Badminton", new DateTime(2023, 08, 05, 22, 40, 00), "Bharat", "USA", "Canada", 21,22));
            matches.Add(new MatchDetails(5, "IceHockey", new DateTime(2023, 11, 13, 05, 35, 00), "Canada", "Argentina", "France", 21, 21));
            matches.Add(new MatchDetails(6, "hockey", new DateTime(2023, 07, 11, 13, 30, 00), "England", "Bharat", "Pakistan", 21, 3));
        }
       public void Display(List<MatchDetails> ms)
        {
            foreach (MatchDetails m in ms)
            {
               Console.WriteLine($"Match Id: { m.Match_Id},Sport Name: {m.Sport},Match Date & Time: {m.MatchDateTime},Match Location: {m.Location}, The HomeTeam: {m.HomeTeam},The AwayTeam: {m.AwayTeam},HomeTeam Score: {m.HomeTeamScore},AwayTeamScore: {m.AwayTeamScore}");
            }
        }
        public void MatchDetails()
        {
            Console.WriteLine("Enter the Match Id to get the match details you want:");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id == 0 || id <=0 ) 
            {
                Console.WriteLine("Please Enter a Positive Number to Display the ID");
            }
            else
            {
                foreach (MatchDetails m in matches)
                {
                    if (id == m.Match_Id)
                    {
                        Console.WriteLine($"Sport Name: {m.Sport},Match Date & Time: {m.MatchDateTime},Match Location: {m.Location}, The HomeTeam: {m.HomeTeam},The AwayTeam: {m.AwayTeam},HomeTeam Score: {m.HomeTeamScore},AwayTeamScore: {m.AwayTeamScore}");
                        return;
                    }
                }
                Console.WriteLine("Please Enter the appropriate Match Id!!");
            }
        }
        public void UpdateScore()
        {
            int UHomeTeamScore, UAwayTeamScore;
            Console.WriteLine("Enter the match id to update the scores of that match:");
            int updt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Updated Scores of HomeTeam: ");
            UHomeTeamScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Updated Scores of AwayTeam: ");
            UAwayTeamScore = Convert.ToInt32(Console.ReadLine());
            if(UHomeTeamScore <=0 || UAwayTeamScore <=0) 
            {
                Console.WriteLine("Please Enter a Positive Value To Update the Scores!");
            }
            else
            {
                foreach (MatchDetails m in matches)
                {
                    if (updt == m.Match_Id)
                    {
                        m.HomeTeamScore = UHomeTeamScore;
                        m.AwayTeamScore = UAwayTeamScore;
                        Console.WriteLine($"The Updated Scores of the HomeTeam & AwayTeam are: {m.HomeTeamScore},{m.AwayTeamScore}");
                       
                        return;
                    }
                }
                Console.WriteLine("Please Enter the appropriate Match Id!!");
            }
        }
        public void RemoveMatch()
        {
            Console.WriteLine("Enter the Match Id to remove the match you want");
            int rid = Convert.ToInt32(Console.ReadLine());
            if(rid == 0 || rid <=0 ) 
            {
                Console.WriteLine("Please Enter a match ID whose value is greater than 0!");
            }
            else
            {
                foreach (MatchDetails m in matches)
                {
                    if (rid == m.Match_Id)
                    {
                        matches.Remove(m);
                        Console.WriteLine($"The Match with {m.Match_Id} has been removed from: ");
                        Display(matches);
                        return;
                    }
                }
                Console.WriteLine("Enter the appropriate Match ID");
            } 
        }
        public void SortDateTime()
        {
            Console.WriteLine("Enter the sorting order (asc/desc) for DateTime of the Matches: ");
            string sortOrder = Console.ReadLine();
            List<MatchDetails> SortMatches = null;
            if (sortOrder == "desc")
            {
                SortMatches = (from m in matches orderby m.MatchDateTime descending select m).ToList();
            }
            else if (sortOrder == "asc")
            {
                SortMatches = (from m in matches orderby m.MatchDateTime ascending select m).ToList();
            }
            else
            {
                Console.WriteLine("Enter appropriate Option!");
                return;
            }
            Display(SortMatches);
        }
        public void SortLocation()
        {
            Console.WriteLine("Enter the sorting order (asc/desc) for Location of the Matches: ");
            string sortOrder = Console.ReadLine();
            List<MatchDetails> SortLocation = null;
            if (sortOrder == "desc")
            {
                SortLocation = (from m in matches orderby m.Location descending select m).ToList();
            }
            else if (sortOrder == "asc")
            {
                SortLocation = (from m in matches orderby m.Location ascending select m).ToList();
            }
            else
            {
                Console.WriteLine("Enter appropriate Option!");
                return;
            }
            Display(SortLocation);
        }
        public void SortSport()
        {
            Console.WriteLine("Enter the sorting order (asc/desc) for Sports of the Matches: ");
            string sortOrder = Console.ReadLine();
            List<MatchDetails> SortSport = null;
            if (sortOrder == "desc")
            {
                SortSport = (from m in matches orderby m.Sport descending select m).ToList();
            }
            else if (sortOrder == "asc")
            {
                SortSport = (from m in matches orderby m.Sport ascending select m).ToList();
            }
            else
            {
                Console.WriteLine("Enter appropriate Option!");
                return;
            }
            Display(SortSport);
        }
        public void FilterBySport()
        {
            Console.WriteLine("Enter the Sport Name");
            string fS = Console.ReadLine().ToUpper();
            if (fS == "")
            {
                Console.WriteLine("Please enter a Sport name!");
            }
            else
            {
                var Sp = from matches in matches where (matches.Sport).ToUpper().Equals(fS) select matches;
                Display(Sp.ToList());
            }
        }
        public void FilterByLocation()
        {
            Console.WriteLine("Enter the Location");
            string fs = Console.ReadLine().ToUpper();
            if (fs == "")
            {
                Console.WriteLine("Please Enter a Location!");
            }
            else
            {
                var Lp = from matches in matches where (matches.Location).ToUpper().Equals(fs) select matches;
                Display(Lp.ToList());
            }
        }
        public void FilterByDateTime()
        {
            Console.Write("Enter the start date (yyyy-MM-dd HH:mm:ss): ");
            string startDateString = Console.ReadLine();

            Console.Write("Enter the end date (yyyy-MM-dd HH:mm:ss): ");
            string endDateString = Console.ReadLine();

            if (DateTime.TryParse(startDateString, out DateTime startDate) && DateTime.TryParse(endDateString, out DateTime endDate))
            {
                var fD = matches.Where(match => match.MatchDateTime >= startDate && match.MatchDateTime <= endDate).ToList();

                if (fD.Count > 0)
                {
                    Console.WriteLine("Filtered Matches by Date Range:");
                    Display(fD);
                }
                else
                {
                    Console.WriteLine("No matches found for the specified date range.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter valid date and time.");
            }
        }
         public void Statistics()
        {
            Console.WriteLine("Select a Team Statistics");
            Console.WriteLine("1. Team Statistics");
            Console.WriteLine("2. Sport Statistics");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ShowTeamStatistics();
                    break;
                case 2:
                    ShowSportStatistics();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
        public void ShowTeamStatistics()
        {
            Console.WriteLine("Enter the Team Name");
            string team = Console.ReadLine().ToUpper();
            // var tm = from matches in matches where (match => (match.HomeTeam.Equals(team)) || (match.AwayTeam.Equals(team)) select matches;
            var tm = from match in matches where match.HomeTeam.ToUpper().Equals(team) || match.AwayTeam.Equals(team) select match;
            if (!matches.Any(match => match.HomeTeam.ToUpper().Equals(team) || match.AwayTeam.ToUpper().Equals(team)))
            {
                Console.WriteLine($"The Team Name {team}  does not exist");
            }
            int totalgoalsScored = tm.Sum(match => match.HomeTeamScore + match.AwayTeamScore);
            int highestScore = tm.Max(match => Math.Max(match.HomeTeamScore, match.AwayTeamScore));
            Console.WriteLine($"The highest Score is:{highestScore}");
            int LowestScore = tm.Min(match => Math.Min(match.HomeTeamScore, match.AwayTeamScore));
            Console.WriteLine($"The Lowest Score is:{LowestScore}");
            double AverageScore = (double)totalgoalsScored / tm.Count();
            Console.WriteLine($"The Average Score is{AverageScore}");
        }
        public void ShowSportStatistics()
        {
            Console.WriteLine("Enter Sport Name");
            string sport = Console.ReadLine().ToUpper();
            var tn = from match in matches where match.Sport.ToUpper().Equals(sport) select match;
            if(!matches.Any(match => match.Sport.ToUpper().Equals(sport)))
            {
                Console.WriteLine($"The Sport Name {sport}  does not exist");
            }
            int totalgoalsScored1 = tn.Sum(match => match.HomeTeamScore + match.AwayTeamScore);
            int highestScore1 = tn.Max(match => Math.Max(match.HomeTeamScore, match.AwayTeamScore));
            Console.WriteLine($"The highest Score is:{highestScore1}");
            int LowestScore1 = tn.Min(match => Math.Min(match.HomeTeamScore, match.AwayTeamScore));
            Console.WriteLine($"The Lowest Score is:{LowestScore1}");
            //    double AverageScore1 = (double)totalgoalsScored1 / tn.Count();
            int matchCount = tn.Count();
            double AverageScore1 = (double)totalgoalsScored1 / matchCount; 
            Console.WriteLine($"The Average Score is{AverageScore1}");
        }
        public void SearchMatches()
        {
            Console.WriteLine("Enter Search Keywords");
            string Searchwords = Console.ReadLine().ToLower();

            var searchResults = matches.Where(Match => Match.Sport.ToLower().Contains(Searchwords) || 
            Match.HomeTeam.ToLower().Contains(Searchwords) || 
            Match.AwayTeam.ToLower().Contains(Searchwords) ||
            Match.Location.ToLower().Contains(Searchwords)).ToList();
            if(searchResults.Any())
            {
                Console.WriteLine($"Search Results for {Searchwords} are: ");
                Display(searchResults);
            }
        }
    }
}

