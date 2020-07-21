using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabanasRD.Domain.Motels;

namespace CabanasRD.Data.Motels
{
    public interface IMotelsSource
    {
        Task<IReadOnlyList<Motel>> GetAll();
    }
}
