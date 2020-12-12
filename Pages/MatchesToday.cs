using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EADCA3.Pages
{
    public partial class MatchesToday
    {

        private Root Main;
        private DateTime Date = DateTime.Now;
        private string ErrorMessage;
        private string League = "PL";

        private async Task GetDataAsync()
        {
            try
            {
                String dateParsed = Date.ToString("yyyy-MM-dd");
                string uri = "https://api.football-data.org/v2/competitions/" + League + "/matches?dateFrom=" + dateParsed + "&dateTo=" + dateParsed;
                Main = await Http.GetJsonAsync<Root>(uri);
                ErrorMessage = String.Empty;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }


        protected override async Task OnInitializedAsync()
        {
            await GetDataAsync();
        }


        public class Root
        {
            public int count { get; set; }
            public Filters filters { get; set; }
            public Competition competition { get; set; }
            public List<Match> matches { get; set; }
        }

   

        public class Area
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Competition
        {
            public int id { get; set; }
            public Area area { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string plan { get; set; }
            public DateTime lastUpdated { get; set; }
        }

        public class Season
        {
            public int id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int currentMatchday { get; set; }
        }

        public class Odds
        {
            public string msg { get; set; }
        }

        public class FullTime
        {
            public object homeTeam { get; set; }
            public object awayTeam { get; set; }
        }

        public class HalfTime
        {
            public object homeTeam { get; set; }
            public object awayTeam { get; set; }
        }

        public class ExtraTime
        {
            public object homeTeam { get; set; }
            public object awayTeam { get; set; }
        }

        public class Penalties
        {
            public object homeTeam { get; set; }
            public object awayTeam { get; set; }
        }

        public class Score
        {
            public object winner { get; set; }
            public string duration { get; set; }
            public FullTime fullTime { get; set; }
            public HalfTime halfTime { get; set; }
            public ExtraTime extraTime { get; set; }
            public Penalties penalties { get; set; }
        }

        public class HomeTeam
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class AwayTeam
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Match
        {
            public int id { get; set; }
            public Season season { get; set; }
            public DateTime utcDate { get; set; }
            public string status { get; set; }
            public int matchday { get; set; }
            public string stage { get; set; }
            public string group { get; set; }
            public DateTime lastUpdated { get; set; }
            public Odds odds { get; set; }
            public Score score { get; set; }
            public HomeTeam homeTeam { get; set; }
            public AwayTeam awayTeam { get; set; }
            public List<object> referees { get; set; }
        }
       
        public class Filters
        {
        }
    }
}
