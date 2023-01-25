using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repository
{
   public class RegionRepository:IRegionRepository 
   {
      private readonly NZWalkDBContext nZWalkDBContext;
      public RegionRepository(NZWalkDBContext nZWalkDBContext)
      {
         this.nZWalkDBContext = nZWalkDBContext;
      }

      public async Task<Region> AddRegionAsync(Region region)
      {
         region.Id = Guid.NewGuid();
         await nZWalkDBContext.AddAsync(region);
         await nZWalkDBContext.SaveChangesAsync();
         return region;
      }

      public async Task<Region> DeleteRegionAsync(Guid id)
      {
         var region = await nZWalkDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
         if (region == null)
         {
            return null;
         }
         nZWalkDBContext.Regions.Remove(region);
         await nZWalkDBContext.SaveChangesAsync();
         return region;
      }

      public async Task<IEnumerable<Region>> GetAllAsync() 
      { 
         return await nZWalkDBContext.Regions.ToListAsync();   
      }

      public async Task<Region> GetRegion(Guid Id)
      {
         return await nZWalkDBContext.Regions.FirstOrDefaultAsync(x=>x.Id ==Id);
      }

      public async Task<Region> UpdateRegionAsync(Guid id, Region region)
      {
         var existingRegion = await nZWalkDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
         if (existingRegion == null) return null;
         existingRegion.Code = region.Code;
         existingRegion.Name = region.Name;
         existingRegion.Area = region.Area;
         existingRegion.Lat = region.Lat;
         existingRegion.Long = region.Long;
         existingRegion.Population = region.Population;
         await nZWalkDBContext.SaveChangesAsync();
         return existingRegion;

      
      }
   }
}
