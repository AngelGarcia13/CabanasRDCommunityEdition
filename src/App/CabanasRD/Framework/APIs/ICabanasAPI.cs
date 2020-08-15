using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabanasRD.Framework.APIs.Models;
using Refit;

namespace CabanasRD.Framework.APIs
{
    public interface ICabanasAPI
    {
        [Get("/api/cabanas?code={key}")]
        Task<List<MotelResponse>> GetMotels(string key);
    }
}
