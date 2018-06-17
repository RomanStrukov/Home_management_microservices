using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using FeedbackService.Models;

namespace Gateway.Services
{
    public class FeedbackSrvc
    {
        private readonly HttpClient _apiClient = new HttpClient();
   
        public IEnumerable<FeedbackViewModel> GetFeedbacksByUserId(int userId)
        {
            //test string type
            var data = Convert.ToString(_apiClient.GetStringAsync("api/Feedback/" + String.Format("{0}", userId)));
            var feedbacks = JsonConvert.DeserializeObject<FeedbackViewModel[]>(data);

            return feedbacks;
        }
        
        public void SaveNewFeedback(FeedbackViewModel fbVm)
        {
            //test string type
            var feedbackContent = new StringContent(JsonConvert.SerializeObject(fbVm), System.Text.Encoding.UTF8, "application/json");

            _apiClient.PostAsync("api/Feedback", feedbackContent);
        }

         public void RemoveFeedback(int id)
        {
            _apiClient.DeleteAsync("api/Feedback/" + String.Format("{0}", id));
        }

    }
}