using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace TPDataBizHackathon.Infra.Data.Context
{
    public class Model
    {
        private SqlConnection _sqlConnection { get; set; }

        public Model()
        {

            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ContextModel"].ConnectionString);

        }

        public int getNavios()
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

        public List<string[]> getFuncionarios()
        {
            _sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("EXEC retorna_funcionario", _sqlConnection);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                List<string[]> listaFuncionarios = new List<string[]>();
                int cont = 0;
                while (rdr.Read() && cont < 10)
                {
                    string[] s = new string[2];
                    s[0] = rdr[0].ToString();
                    s[1] = rdr[3].ToString();

                    listaFuncionarios.Add(s);
                    cont++;
                }
                return listaFuncionarios;
            }
        }

        public string getAcuracia()
        {

            string s = "";
            string queryStr = "SELECT * FROM [OK$]";
            using (OleDbConnection _oleDbConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["ExcelConnection"].ConnectionString))
            {
                _oleDbConnection.Open();

                OleDbCommand command = new OleDbCommand(queryStr, _oleDbConnection);
                OleDbDataReader reader = command.ExecuteReader();

                
                int cont = 0;
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader[cont].ToString()))
                    {
                        s = reader[cont].ToString();
                    }

                }

                reader.Close();
            }

            return s;

        }
    }
}
