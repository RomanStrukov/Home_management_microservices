﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FeedbackService.Models;

namespace FeedbackService
{
    public class RequestProcessor
    {
        private FeedbackDBContext _db; 
        private Validator _validator;
        private ModelBinder _modelBinder;

        public RequestProcessor ()
        {          
            _db = new FeedbackDBContext();
            _validator = new Validator();
            _modelBinder = new ModelBinder();
        }

        public IEnumerable<FeedbackViewModel> GetFeedbacksByUserId(int userId)
        {
            List<Feedback> feedbacks = new List<Feedback>();
            foreach (Feedback fb in _db.feedbacks)
            {
                if (fb.UserId == userId)
                    feedbacks.Add(fb);
            }

            List<FeedbackViewModel> feedbackViewModels = new List<FeedbackViewModel>();
            foreach (var feedback in feedbacks)
            {
                feedbackViewModels.Add(_modelBinder.EntityToViewModel(feedback));
            }
            return feedbackViewModels.AsEnumerable<FeedbackViewModel>();
        }

        public FeedbackViewModel Get (int id)
        {
            Feedback fb = _db.feedbacks.Find(id);            
            if (fb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }
            return _modelBinder.EntityToViewModel(fb);
        }

        public bool Post(FeedbackViewModel feedbackviewmodel)
        {
            Feedback fb = _modelBinder.ViewModelToEntity(feedbackviewmodel);

            if(!_validator.Valid(fb))
            {
                return false;
            }
            _db.feedbacks.Add(fb);
            _db.SaveChanges();

            return true;
        }

        public FeedbackViewModel Delete(int id, out HttpStatusCode httpStatusCode)
        {
            Feedback fb = _db.feedbacks.Find(id);
            httpStatusCode = HttpStatusCode.OK;

            if (fb == null)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                return null;
            }

            _db.feedbacks.Remove(fb);

            try
            {
                _db.SaveChanges();
                return _modelBinder.EntityToViewModel(fb);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        private bool Validate(Feedback fb)
        {
            return _validator.Valid(fb);
        }

        public void DisposeDB()
        {
            _db.Dispose();
        }
    }
}