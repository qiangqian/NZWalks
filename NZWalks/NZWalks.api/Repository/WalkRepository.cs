using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repository
{
   public class WalkRepository:IWalkRepository 
   {
      private readonly NZWalkDBContext nZWalkDBContext;
      public WalkRepository(NZWalkDBContext nZWalkDBContext)
      {
         this.nZWalkDBContext = nZWalkDBContext;
      }

      public async Task<Walk> AddWalkAsync(Walk walk)
      {
         walk.Id = Guid.NewGuid();
         await nZWalkDBContext.AddAsync(walk);
         await nZWalkDBContext.SaveChangesAsync();
         return walk;
      }

      public async Task<Walk> DeleteWalkAsync(Guid id)
      {
         var Walk = await nZWalkDBContext.Walks.FindAsync(id);
         if (Walk == null)
         {
            return null;
         }
         nZWalkDBContext.Walks.Remove(Walk);
         await nZWalkDBContext.SaveChangesAsync();
         return Walk;
      }

      public async Task<IEnumerable<Walk>> GetAllAsync() 
      { 
         return await nZWalkDBContext.Walks.Include(x=>x.Region).Include(x=>x.WalkDifficulty).ToListAsync();   
      }

      public async Task<Walk> GetWalkAsync(Guid Id)
      {
         return await nZWalkDBContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).FirstOrDefaultAsync(x=>x.Id ==Id);
      }

      public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
      {
         var existingWalk = await nZWalkDBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
         if (existingWalk == null) return null;
         existingWalk.Name = walk.Name;
         existingWalk.WalkDifficulty = walk.WalkDifficulty;
         existingWalk.Length = walk.Length;
         existingWalk.RegionId = walk.RegionId;
         existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
         await nZWalkDBContext.SaveChangesAsync();
         return existingWalk;

      
      }
   }
}
