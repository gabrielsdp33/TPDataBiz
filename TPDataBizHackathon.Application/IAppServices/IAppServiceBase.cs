using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDataBizHackathon.Application.IAppServices
{
    public interface IAppServiceBase
    {
        string[] getNavio();

        List<string[]> getFuncionarios();

        string getAcuracia();

    }
}
