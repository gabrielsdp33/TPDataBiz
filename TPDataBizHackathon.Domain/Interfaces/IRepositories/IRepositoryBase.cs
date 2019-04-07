using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TPDataBizHackathon.Domain.Interfaces.IRepositories
{
    public interface IRepositoryBase
    {
        string[] getNavio();
        List<string[]> getFuncionarios();
        string getAcuracia();
    }
}
