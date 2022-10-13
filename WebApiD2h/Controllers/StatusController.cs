
using BLD2H.Interfaces;
using Models.D2H;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiD2h.Controllers
{
    public class StatusController : ApiController
    {
        //private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=d2hoperator;Integrated Security=True";
        //private static CustomerOperations _customerOperations = new CustomerOperations(_connectionString);

        private IStatusBL businesslogic;

        public StatusController(IStatusBL businesslogic)
        {
            this.businesslogic = businesslogic;
        }
        public IEnumerable<Status> Get()
        {

            return businesslogic.GetStatus();

        }
    }
}
