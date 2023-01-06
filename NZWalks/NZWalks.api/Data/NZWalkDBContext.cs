using Microsoft.EntityFrameworkCore;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Data
{
   public class NZWalkDBContext:DbContext
   {
      public NZWalkDBContext(DbContextOptions<NZWalkDBContext> option):base(option) 
      {

      }
      public DbSet<Region> Regions { get; set; }
      public DbSet<Walk> Walks { get; set; }
      public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
   }
}
