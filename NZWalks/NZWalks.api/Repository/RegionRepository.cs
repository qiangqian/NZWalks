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
      public async Task<IEnumerable<Region>> GetAllAsync() 
      { 
         return await nZWalkDBContext.Regions.ToListAsync();   
      }
   }
}
