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
    public class GroupBL : IGroupBL
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
        public IEnumerable<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("select g.[id],g.[nameofgroup] from [GROUP] as g", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Group g = new Group();
                    g.Id = (int)reader[0];
                    g.NameOfGroup = (string)reader[1];

                    groups.Add(g);
                }
                connection.Close();
            }
            return groups;
        }
    }
}
