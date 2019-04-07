using BulkCopyCSV.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPDataBizHackathon.Application.IAppServices;
using TPDataBizHackathon.Infra.Data.Context;
using TPDataBizHackathon.Infra.IoC;

namespace teste
{
    class Program
    {
        //private RepositoryBase<string> repo = new RepositoryBase<string>();

        static private IAppServiceBase _appServiceBase;

        static void Main(string[] args)
        {
            //using (SqlConnection conn = new SqlConnection("data source=tcp:mlssql.database.windows.net,1433;initial catalog=tpdatabiz;user id=tpdatabiz_usr;Password=St$6WuyU;MultipleActiveResultSets=True;App=EntityFramework"))
            //{
            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand("EXEC retorna_navio", conn);

            //    using (SqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        // iterate through results, printing each to console
            //        int count = 0;
            //        while (rdr.Read())
            //        {
            //            Console.WriteLine(rdr[0]);
            //            count++;
            //        }
            //        Console.WriteLine(count);
            //    }
            //    ////OleDbDataReader navios = context.Database.ExecuteSqlCommand(commandText);
            //    //context.Database.ExecuteSqlCommand("EXEC retorna_navio");
            //    //context.Database.Connection.Close();
            //}
            BootStrapper.Start();
            _appServiceBase = BootStrapper.container.GetInstance<IAppServiceBase>();
            int i = _appServiceBase.TesteScript();

            Console.WriteLine(i);
        }
    }
}
