﻿namespace NZWalks.api.Models.DTO
{
   public class UpdateWalkRequest
   {
      public string Name { get; set; }
      public string Length { get; set; }
      public Guid RegionId { get; set; }
      public Guid WalkDifficultyId { get; set; }



   }
}