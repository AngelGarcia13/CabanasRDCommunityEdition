using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CabanasRD.Data.Motels;
using CabanasRD.Domain.Motels;
using CabanasRD.Framework.APIs;
using Refit;

namespace CabanasRD.Framework.DataSources
{
    public class MotelsSource : IMotelsSource
    {
        private readonly ICabanasAPI _cabanasAPI;
        private readonly IMapper _mapper;

        public MotelsSource(ICabanasAPI cabanasAPI, IMapper mapper)
        {
            _cabanasAPI = cabanasAPI;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<Motel>> GetAll()
        {
            try
            {
                var cabanasResponse = await _cabanasAPI.GetMotels(Configs.AppSettingsConstants.ApiKey);

                return _mapper.Map<List<APIs.Models.MotelResponse>, List<Domain.Motels.Motel>>(cabanasResponse);
            }
            catch (ApiException ex)
            {
                switch (ex.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        throw new SystemException(ex.Content);
                    case HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException(ex.Content);
                    default:
                        break;
                }
                throw ex;
            }
        }
    }
}
