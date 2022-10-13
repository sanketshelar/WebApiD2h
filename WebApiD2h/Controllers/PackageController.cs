using BLD2H.Interfaces;
using Models.D2H;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiD2h.Models;

namespace WebApiD2h.Controllers
{
    public class PackageController : ApiController
    {
        //private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=d2hoperator;Integrated Security=True";
        //private static CustomerOperations _customerOperations = new CustomerOperations(_connectionString);

        private IPackageBL businesslogic;

        public PackageController(IPackageBL businesslogic)
        {
            this.businesslogic = businesslogic;
        }
        public IEnumerable<Package> Get()
        {

            return businesslogic.GetPackages();

        }
    }
}
