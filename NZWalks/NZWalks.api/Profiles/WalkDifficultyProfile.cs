using AutoMapper;
namespace NZWalks.api.Profiles
{
   public class WalkDifficultyProfile:Profile
   {
      public WalkDifficultyProfile()
      {
         CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
            .ReverseMap();
      }
   }
}
