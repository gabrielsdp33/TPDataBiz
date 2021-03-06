﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPDataBizHackathon.Application.IAppServices;
using TPDataBizHackathon.Domain.Interfaces.IServices;

namespace TPDataBizHackathon.Application.AppServices
{
    public class AppServiceBase : IAppServiceBase
    {
        protected IServiceBase _serviceBase;

        public AppServiceBase(IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public string[] getNavio()
        {
            return _serviceBase.getNavio();
        }

        public List<string[]> getFuncionarios()
        {
            return _serviceBase.getFuncionarios();
        }

        public string getAcuracia()
        {
            return _serviceBase.getAcuracia();
        }
    }
}
