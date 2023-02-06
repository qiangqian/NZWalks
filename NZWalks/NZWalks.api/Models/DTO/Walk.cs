﻿namespace NZWalks.api.Models.DTO
{
   public class Walk
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public string Length { get; set; }
      public Guid RegionId { get; set; }
      public Guid WalkDifficultyId { get; set; }
      //Navigation proper ty

      public Region Region { get; set; }
      public WalkDifficulty WalkDifficulty { get; set; }


   }
}
