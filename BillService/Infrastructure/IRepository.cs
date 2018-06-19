using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BillService.Models;

namespace BillService.Infrastructure
{
    interface IRepository
    {
        void Add(Bill bill);
        BillViewModel Remove(int id, out HttpStatusCode httpStatusCode);
        void SaveChanges();
        void DisposeDB();
    }
}
