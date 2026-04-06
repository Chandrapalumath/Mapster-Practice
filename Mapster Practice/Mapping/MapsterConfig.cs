using Mapster;
using Mapster_Practice.Dto;
using Mapster_Practice.Models;

namespace Mapster_Practice.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, UserDto>.NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
                .Map(dest => dest.FullAddress, src =>
                    $"{src.HomeAddress.Street}, {src.HomeAddress.City} ({src.HomeAddress.ZipCode})");
        }
    }
}
