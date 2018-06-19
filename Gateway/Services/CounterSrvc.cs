using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using CounterService.Models;

namespace Gateway.Services
{
    public class CounterSrvc
    {
        private HttpClient _apiClient = new HttpClient();

        public IEnumerable<CounterViewModel> GetCountersByUserId(int userId)
        {            
            var data = Convert.ToString(_apiClient.GetStringAsync("api/counter/" + String.Format("{0}", userId)));
            var counters = JsonConvert.DeserializeObject<CounterViewModel[]>(data);

            return counters;
        }

        public void AddCounter(CounterViewModel cntVm)
        {
            var counterContent = new StringContent(JsonConvert.SerializeObject(cntVm), System.Text.Encoding.UTF8, "application/json");

            _apiClient.PostAsync("api/counter", counterContent);
        }

        public void UpdateCounterIndicators(int id, CounterViewModel cntVm)
        {
            var counterContent = new StringContent(JsonConvert.SerializeObject(cntVm), System.Text.Encoding.UTF8, "application/json");

            _apiClient.PutAsync("api/counter", counterContent);
        }

        public void RemoveCounter(int id)
        {
            _apiClient.DeleteAsync("api/counter/" + String.Format("{0}", id));
        }

    }
}