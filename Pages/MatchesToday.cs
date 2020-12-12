using EADCA3.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EADCA3.Pages
{
    public partial class MatchesToday
    {

        private Root Main;
        private DateTime Date = DateTime.Now;
        private string ErrorMessage;
        private string League = "PL";
        private string dateFormatString = "yyyy-MM-dd";
        [Parameter]
        public EventCallback<DateTime?> DateChanged { get; set; }
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

        public async Task OnDateChanged(ChangeEventArgs e)
        {
            var date = (string)e.Value;
            var newDate = DateTime.Parse(date);
            Date = newDate;
            await DateChanged.InvokeAsync(Date);
            await GetDataAsync();
        }


    }
}
