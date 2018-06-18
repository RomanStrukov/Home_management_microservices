using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillService.Models;

namespace BillService
{
    public class Repository
    {
        private readonly BillDBContext _db;

        public Repository()
        {
            _db = new BillDBContext();
        }

        public void DisposeDB()
        {
            _db.Dispose();
        }
    }
}