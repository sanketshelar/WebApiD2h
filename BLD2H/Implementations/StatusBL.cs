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
    public class StatusBL : IStatusBL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
        public IEnumerable<Status> GetStatus()
        {
            List<Status> statuses = new List<Status>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("select s.[id],s.[status] from status as s", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Status s = new Status();
                    s.Id = (int)reader[0];
                    s.StatusName = (string)reader[1];

                    statuses.Add(s);
                }
                connection.Close();
            }
            return statuses;
        }
    }
}
