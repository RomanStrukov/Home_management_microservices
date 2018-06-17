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


    }
}