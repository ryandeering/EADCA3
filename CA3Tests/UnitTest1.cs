using Bunit;
using EADCA3;
using EADCA3.Pages;
using EADCA3.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CA3Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IndexComponentDoesntRenderCorrectly()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<EADCA3.Pages.Index>();

            cut.MarkupMatches("<p>Calling the API has run into a problem.</p> <p>A reminder that the API can only make 10 requests per minute.</p>");
        }


        [Fact]
        public void MatchesTodayComponentDoesntRenderCorrectly()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<MatchesToday>();

            cut.MarkupMatches("<p>Calling the API has run into a problem.</p> <p>A reminder that the API can only make 10 requests per minute.</p>");
        }

        [Fact]
        public async Task TestParse()
        {
            var Http = new HttpClient();

            string teststring = "{\"count\":1,\"filters\":{},\"competition\":{\"id\":2021,\"area\":{\"id\":2072,\"name\":\"England\"},\"name\":\"Premier League\",\"code\":\"PL\",\"plan\":\"TIER_ONE\",\"lastUpdated\":\"2020-12-12T19:56:23Z\"},\"matches\":[{\"id\":303874,\"season\":{\"id\":619,\"startDate\":\"2020-09-12\",\"endDate\":\"2021-05-23\",\"currentMatchday\":12},\"utcDate\":\"2020-12-11T20:00:00Z\",\"status\":\"FINISHED\",\"matchday\":12,\"stage\":\"REGULAR_SEASON\",\"group\":\"Regular Season\",\"lastUpdated\":\"2020-12-12T00:55:18Z\",\"odds\":{\"msg\":\"Activate Odds-Package in User-Panel to retrieve odds.\"},\"score\":{\"winner\":\"AWAY_TEAM\",\"duration\":\"REGULAR\",\"fullTime\":{\"homeTeam\":1,\"awayTeam\":2},\"halfTime\":{\"homeTeam\":1,\"awayTeam\":1},\"extraTime\":{\"homeTeam\":null,\"awayTeam\":null},\"penalties\":{\"homeTeam\":null,\"awayTeam\":null}},\"homeTeam\":{\"id\":341,\"name\":\"Leeds United FC\"},\"awayTeam\":{\"id\":563,\"name\":\"West Ham United FC\"},\"referees\":[{\"id\":11605,\"name\":\"Michael Oliver\",\"role\":\"MAIN_REFEREE\",\"nationality\":\"England\"},{\"id\":11564,\"name\":\"Stuart Burt\",\"role\":\"ASSISTANT_N1\",\"nationality\":\"England\"},{\"id\":11488,\"name\":\"Simon Bennett\",\"role\":\"ASSISTANT_N2\",\"nationality\":\"England\"},{\"id\":11469,\"name\":\"Darren England\",\"role\":\"FOURTH_OFFICIAL\",\"nationality\":\"England\"}]}]}";
            Root test = JsonSerializer.Deserialize<Root>(teststring);
            Root test2;
            DateTime date = DateTime.Parse("2020-12-11");
            String dateParsed = date.ToString("yyyy-MM-dd");

            string uri = "https://api.football-data.org/v2/competitions/" + "PL" + "/matches?dateFrom=" + dateParsed + "&dateTo=" + dateParsed;

            test2 = await Http.GetJsonAsync<Root>(uri);

            await Task.Delay(2000);


            Assert.Equal(test.matches[0].homeTeam.name,test2.matches[0].homeTeam.name);
            //It is a guarantee Leeds played on the 11th of December, 2020, at home. 

        }




    }
}
