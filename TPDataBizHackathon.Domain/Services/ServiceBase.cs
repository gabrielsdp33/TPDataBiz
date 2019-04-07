using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPDataBizHackathon.Domain.Interfaces.IRepositories;
using TPDataBizHackathon.Domain.Interfaces.IServices;

namespace TPDataBizHackathon.Domain.Services
{
    public class ServiceBase : IServiceBase
    {
        protected IRepositoryBase _repositoryBase;

        public ServiceBase(IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        
        public string[] getNavio()
        {
            return _repositoryBase.getNavio();
        }

        public List<string[]> getFuncionarios()
        {
            return _repositoryBase.getFuncionarios();
        }

        public string getAcuracia()
        {
            return _repositoryBase.getAcuracia();
        }
    }
}
