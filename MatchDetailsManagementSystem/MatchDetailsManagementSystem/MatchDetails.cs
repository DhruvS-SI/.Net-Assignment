using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class MatchDetails
    {
        public int Match_Id { get; }
       public string Sport { get; }
       public DateTime MatchDateTime { get; }
       public string Location { get; }
       public string HomeTeam { get; }   
       public string AwayTeam { get; }
       public int HomeTeamScore { get; set; }
       public int AwayTeamScore { get; set; }

        public MatchDetails() { }
        public MatchDetails(int match_Id, string sport, DateTime matchDateTime, string location, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            Match_Id = match_Id;
            Sport = sport;
            MatchDateTime = matchDateTime;
            Location = location;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }
    }

}
