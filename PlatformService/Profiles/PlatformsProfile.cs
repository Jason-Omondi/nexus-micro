using AutoMapper;

namespace PlatformService.Profiles {
    public class PlatformsProfile : Profile {
        public PlatformsProfile() {
            //Source to target
            CreateMap<Models.Platform, DTOs.PlatformReadDto>();

            //target to source
            CreateMap<DTOs.PlatformCreateDto, Models.Platform>();
        }

    }
}