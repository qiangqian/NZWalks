using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.Models;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repository
{
   public class WalkDifficultyRepository : IWalkDifficultyRepository
   {
      private readonly NZWalkDBContext nZWalkDBContext;

      public WalkDifficultyRepository(NZWalkDBContext nZWalkDBContext)
      {
         this.nZWalkDBContext = nZWalkDBContext;
      }
      public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
      {
         walkDifficulty.Id= Guid.NewGuid();
         nZWalkDBContext.Add(walkDifficulty);
         await nZWalkDBContext.SaveChangesAsync();
         return walkDifficulty;
      }

      public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
      {
         return await nZWalkDBContext.WalkDifficulty.ToListAsync();
      }

      public async Task<WalkDifficulty> GetWalkDifficultyAsync(Guid id)
      {
         var walkDifficulty = await nZWalkDBContext.WalkDifficulty.FirstOrDefaultAsync(x=>x.Id==id);
         return walkDifficulty;
      }

      public async Task<WalkDifficulty> RemoveWalkDifficultyAsync(Guid Id)
      {
         var walkDifficulty = await nZWalkDBContext.WalkDifficulty.FindAsync(Id);
         if(walkDifficulty == null) return null;
         nZWalkDBContext.Remove(walkDifficulty);
         await nZWalkDBContext.SaveChangesAsync();
         return walkDifficulty;
      }

      public async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid id, WalkDifficulty walkDifficulty)
      {
         var existingWalkDifficulty = nZWalkDBContext.WalkDifficulty.Find(id);
         if(existingWalkDifficulty == null) return null;
         existingWalkDifficulty.Code = walkDifficulty.Code;
         await nZWalkDBContext.SaveChangesAsync();
         return existingWalkDifficulty;
      }

      
   }
}
