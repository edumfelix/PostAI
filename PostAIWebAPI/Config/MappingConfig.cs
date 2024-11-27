using PostAIWebAPI.Controllers.Data.ValueObject;
using PostAIWebAPI.Models;
using AutoMapper;

namespace PostAIWebAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<DadosClienteVO, DadosCliente>();
                config.CreateMap<DadosCliente, DadosClienteVO>();
            });
            return mappingConfig;
        }
    }
}
