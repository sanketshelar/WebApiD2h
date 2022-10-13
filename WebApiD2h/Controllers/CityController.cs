
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
    public class CityController : ApiController
    {


        private ICityBL businesslogic;

        public CityController(ICityBL businesslogic)
        {
            this.businesslogic = businesslogic;
        }
        public IEnumerable<City> Get()
        {

            return businesslogic.GetCity();

        }
    }
}
