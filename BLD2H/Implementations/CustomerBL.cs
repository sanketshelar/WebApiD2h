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
    public class CustomerBL:ICustomerBL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;

       

        public IEnumerable<Customer> GetCustomerByUsername(string username)
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"Execute USP_GetCustomerByName '{username}'", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer c = new Customer();
                    c.Id = (int)reader[0];
                    c.FirstName = (string)reader[1];
                    c.LastName = (string)reader[2];
                    c.Username = (string)reader[3];
                    c.Password = (string)reader[4];
                    c.PackageName = (string)reader[5];
                    c.GroupName = (string)reader[6];
                    c.CityName = (string)reader[7];
                    c.StatusName = (string)reader[8];
                    customers.Add(c);
                }
                connection.Close();
            }

            return customers;

        }
        public void AddCustomer(Customer obj)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"insert into customer values('{obj.FirstName}','{obj.PackageId}','{obj.CityId}','{obj.GroupId}','{obj.StatusId}','{obj.LastName}','{obj.Username}','{obj.Password}')", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                }
                connection.Close();
            }
        }


        public IEnumerable<Customer> GetCustomerInfo(string packageids)
        {
            List<Customer> customers = new List<Customer>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand($"EXECUTE dbo.USP_GetCustomerInfo '{packageids}'", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer c = new Customer();
                    c.Id = (int)reader[0];
                    c.FirstName = (string)reader[1];
                    c.LastName = (string)reader[2];
                    c.Username = (string)reader[3];
                    c.Password = (string)reader[4];
                    c.PackageName = (string)reader[5];
                    c.GroupName = (string)reader[6];

                    customers.Add(c);
                }
                connection.Close();
            }
            return customers;
        }
    }
}
