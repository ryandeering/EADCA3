﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace EADCA3.Pages
{
    public partial class Index : ComponentBase
    {
        private Root main;
        private Boolean found;
        private int count;
        private string errormessage;
        private string League = "2021";

        private async Task GetDataAsync()
        {
            try
            {
                string uri = "https://api.football-data.org/v2/competitions/" + League + "/standings?standingType=TOTAL";
                main = await Http.GetJsonAsync<Root>(uri);
                found = true;
                errormessage = String.Empty;
                main = null;
            }
            catch (Exception e)
            {
                found = false;
                errormessage = e.Message;
            }
        }


        protected override async Task OnInitializedAsync()
        {
            await GetDataAsync();
        }


        public class Filters
        {
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

        public class Root
        {
            public Filters filters { get; set; }
            public Competition competition { get; set; }
            public Season season { get; set; }
            public List<Standing> standings { get; set; }
        }

    }
}
