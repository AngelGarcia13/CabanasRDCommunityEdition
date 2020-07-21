using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabanasRD.Data.Motels;
using CabanasRD.Domain.Motels;

namespace CabanasRD.UseCases.Motels
{
    public class GetAllMotels
    {
        private MotelsRepository _motelsRepository;

        public GetAllMotels(MotelsRepository motelsRepository)
        {
            _motelsRepository = motelsRepository;
        }

        public Task<IReadOnlyList<Motel>> Invoke()
        {
            return _motelsRepository.GetMotelsAsync();
        }
    }
}
