using NZWalks.api.Models.Domain;
namespace NZWalks.api.Repository
{
   public interface IRegionRepository
   {
      Task<IEnumerable<Region>>GetAllAsync();
      Task<Region> GetRegion(Guid Id);
      Task<Region> AddRegionAsync(Region region);
      Task<Region> DeleteRegionAsync(Guid Id);
      Task<Region> UpdateRegionAsync(Guid Id, Region region);
   }
}
