using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabanasRD.Domain.Motels;

namespace CabanasRD.Data.Motels
{
    public class MotelsRepository
    {
        private IMotelsSource _motelsSource;

        public MotelsRepository(IMotelsSource motelsSource)
        {
            _motelsSource = motelsSource;
        }
        public async Task<IReadOnlyList<Motel>> GetMotelsAsync()
        {
            return await _motelsSource.GetAll();
        }
    }
}
