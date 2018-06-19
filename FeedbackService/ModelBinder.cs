using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackService.Models;

namespace FeedbackService
{
    public class ModelBinder
    {

        public Feedback ViewModelToEntity(FeedbackViewModel fbVm)
        {
            Feedback fb = new Feedback();

            fb.Id = fbVm.Id;
            fb.Content = fbVm.Content;
            fb.UserId = fbVm.UserId;

            return fb;
        }

        public FeedbackViewModel EntityToViewModel(Feedback fb)
        {
            FeedbackViewModel fbVm = new FeedbackViewModel();

            fbVm.Id = fb.Id;
            fbVm.Content = fb.Content;
            fbVm.UserId = fb.UserId;

            return fbVm;
        }
    }
}