using BLD2H.Interfaces;
using Models.D2H;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLD2H.Implementations
{
    public class CityBL : ICityBL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
        public IEnumerable<City> GetCity()
        {
            List<City> cities = new List<City>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("select c.[id],c.[name] from city as c", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City c = new City();
                    c.Id = (int)reader[0];
                    c.Name = (string)reader[1];

                    cities.Add(c);
                }
                connection.Close();
            }

            return cities;
        }
    }
}
