using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CounterService.Models;

namespace CounterService
{
    public class RequestProcessor
    {
        private CounterDBContext _db;
        private Validator _validator;
        private ModelBinder _modelBinder;

        public RequestProcessor()
        {
            _db = new CounterDBContext();
            _validator = new Validator();
            _modelBinder = new ModelBinder();
        }

        public IEnumerable<CounterViewModel> GetCountersByUserId(int userId)
        {
            List<Counter> feedbacks = new List<Counter>();
            foreach (Counter cnt in _db.Counters)
            {
                if (cnt.UserId == userId)
                    feedbacks.Add(cnt);
            }

            List<CounterViewModel> feedbackViewModels = new List<CounterViewModel>();
            foreach (var feedback in feedbacks)
            {
                feedbackViewModels.Add(_modelBinder.EntityToViewModel(feedback));
            }
            return feedbackViewModels.AsEnumerable<CounterViewModel>();
        }

        public CounterViewModel Get(int id)
        {
            Counter cnt = _db.Counters.Find(id);
            if (cnt == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return _modelBinder.EntityToViewModel(cnt);
        }

        public bool Post(CounterViewModel counterviewmodel)
        {
            Counter cnt = _modelBinder.ViewModelToEntity(counterviewmodel);

            if (!_validator.Valid(cnt))
            {
                return false;
            }
            _db.Counters.Add(cnt);
            _db.SaveChanges();

            return true;
        }

        public CounterViewModel Delete(int id, out HttpStatusCode httpStatusCode)
        {
            Counter cnt = _db.Counters.Find(id);
            httpStatusCode = HttpStatusCode.OK;

            if (cnt == null)
            {
                httpStatusCode = HttpStatusCode.NotFound;
                return null;
            }

            _db.Counters.Remove(cnt);

            try
            {
                _db.SaveChanges();
                return _modelBinder.EntityToViewModel(cnt);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        private bool Validate(Counter cnt)
        {
            return _validator.Valid(cnt);
        }

        public void DisposeDB()
        {
            _db.Dispose();
        }

    }
}