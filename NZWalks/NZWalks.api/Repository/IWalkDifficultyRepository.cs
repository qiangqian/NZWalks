using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repository
{
   public interface IWalkDifficultyRepository
   {
      Task<IEnumerable<WalkDifficulty>>GetAllAsync();
      Task<WalkDifficulty>GetWalkDifficultyAsync(Guid id);
      Task<WalkDifficulty>AddWalkDifficultyAsync(WalkDifficulty walkDifficulty);
      Task<WalkDifficulty>UpdateWalkDifficultyAsync(Guid id, WalkDifficulty walkDifficulty);
      Task<WalkDifficulty>RemoveWalkDifficultyAsync(Guid Id);
   }
}
