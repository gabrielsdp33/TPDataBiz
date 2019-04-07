using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TPDataBizHackathon.Domain.Interfaces.IRepositories;
using TPDataBizHackathon.Infra.Data.Context;

namespace BulkCopyCSV.Infra.Data.Repository
{
    public class RepositoryBase : IRepositoryBase
    {
        private Model _model;

        public RepositoryBase()
        {
            _model = new Model();
        }

       
        public int TesteScript()
        {
           return _model.getNavios();   
        }

        public List<string[]> getFuncionarios()
        {
            return _model.getFuncionarios();
        } 
        public string getAcuracia()
        {
            return _model.getAcuracia();
        }
    }
}
