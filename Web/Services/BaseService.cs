﻿using OnlineApp.Web.UI.IServices;
using OnlineApp.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineApp.Web.UI.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
