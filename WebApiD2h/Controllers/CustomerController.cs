
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
    
    public class CustomerController : ApiController
    {

        // GET api/Customer
        private ICustomerBL businesslogic;
        public CustomerController(ICustomerBL businesslogic)
        {
            this.businesslogic = businesslogic;
        }
        public IEnumerable<Customer> Get(string username)
        {

            return businesslogic.GetCustomerByUsername(username);

        }

        public void Post(Customer obj)
        {
            businesslogic.AddCustomer(obj);
        }
        
      
    }
}
