using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackService.Models;

namespace FeedbackService
{
    public class Validator
    {
        private const int FEEDBACK_CONTENT_MAX_LENGTH = 100;
        public bool Valid(Feedback feedback)
        {
            return feedback.Content.Length <= FEEDBACK_CONTENT_MAX_LENGTH;
        }
    }
}