using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillService;
using BillService.Models;

namespace BillService
{
    public class RequestProcessor
    {
        private Repository _repo;
        private ModelBinder _modelBinder;
        
        public RequestProcessor()
        {
            _repo = new Repository();
            _modelBinder = new ModelBinder();
        }



        private int CalculatePrice()
        {

        }
            

    }
}