using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace TPDataBizHackathon.Infra.Data.Context
{
    public class Model
    {
        private SqlConnection _sqlConnection {get; set;}

        public Model()
        {
           
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContextModel"].ConnectionString);

        }

        public int retornaNavios()
        {
            _sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("EXEC retorna_navio", _sqlConnection);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                int count = 0;
                while (rdr.Read())
                {
                    count++;
                }
                return count;
            }
        }
    }
}
