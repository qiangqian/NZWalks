using NZWalks.api.Models.Domain;
namespace NZWalks.api.Repository
{
   public interface IWalkRepository
   {
      Task<IEnumerable<Walk>>GetAllAsync();
      Task<Walk> GetWalkAsync(Guid Id);
      Task<Walk> AddWalkAsync(Walk walk);
      Task<Walk> DeleteWalkAsync(Guid Id);
      Task<Walk> UpdateWalkAsync(Guid Id, Walk walk);
   }
}
