using System;
using System.Collections.Generic;
namespace EADCA3.Shared
{
    public class Root
    {
        public int count { get; set; }
        public Filters filters { get; set; }
        public Competition competition { get; set; }
        public List<Match> matches { get; set; }
        public Season season { get; set; }
        public List<Standing> standings { get; set; }
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
        public object winner { get; set; }
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
    
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string crestUrl { get; set; }
    }

    public class Table
    {
        public int position { get; set; }
        public Team team { get; set; }
        public int playedGames { get; set; }
        public string form { get; set; }
        public int won { get; set; }
        public int draw { get; set; }
        public int lost { get; set; }
        public int points { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
        public int goalDifference { get; set; }
    }

    public class Standing
    {
        public string stage { get; set; }
        public string type { get; set; }
        public object group { get; set; }
        public List<Table> table { get; set; }
    }

    public class Filters
    {
    }
}
