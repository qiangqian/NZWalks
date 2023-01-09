using AutoMapper;
using NZWalks.api;

namespace NZWalks.api.Profiles
{
   public class RegionProfile:Profile
   {
      public RegionProfile()
      {
         CreateMap<Models.Domain.Region, Models.DTO.Region>();
          //.ForMember(dest => dest.id, options=>options.MapFrom(src => src.RegionId));
      }
   }
}
