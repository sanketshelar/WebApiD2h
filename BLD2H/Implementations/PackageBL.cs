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
    public class PackageBL : IPackageBL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
        public IEnumerable<Package> GetPackages()
        {
            List<Package> packages = new List<Package>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("select p.[id],p.[name],p.[durationinmonth],p.[price] from package as p", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Package p = new Package();
                    p.Id = (int)reader[0];
                    p.Name = (string)reader[1];
                    p.Duration = (int)reader[2];
                    p.Price = (decimal)reader[3];
                    packages.Add(p);
                }
                connection.Close();
            }
            return packages;
        }
    }
}
