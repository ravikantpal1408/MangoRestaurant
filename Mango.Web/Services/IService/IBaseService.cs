﻿using System;
using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
    public interface IBaseService: IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
