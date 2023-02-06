using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;
using NZWalks.api.Repository;

namespace NZWalks.api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class WalkController : Controller
   {
      private readonly IWalkRepository walkRepository;
      private readonly IMapper mapper;

      public WalkController(IWalkRepository walkRepository, IMapper mapper)
      {
         this.walkRepository = walkRepository;
         this.mapper = mapper;
      }


      [HttpGet]
      public async Task<IActionResult> GetAllWalksAsync()
      {
         var walks = await walkRepository.GetAllAsync();
         //var walksDTO = new List<Models.DTO.Walk>();
         //walks.ToList().ForEach(walk => 
         //{ 
         //   var walkDTO =new Models.DTO.Walk()
         //   {
         //      Id=walk.Id,
         //      Code=walk.Code,
         //      Name = walk.Code,
         //      Area = walk.Area,
         //      Lat = walk.Lat,
         //      Long = walk.Long,
         //      Population = walk.Population
         //   };
         //   walksDTO.Add(walkDTO);
         //});
         var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walks);
         return Ok(walksDTO);
      }

      [HttpGet]
      [Route("{id:guid}")]
      [ActionName("GetWalkAsync")]
      public async Task<IActionResult> GetWalkAsync(Guid id)
      {
         var walk = await walkRepository.GetWalkAsync(id);
         if (walk == null)
         {
            return NotFound();
         }
         var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
         return Ok(walkDTO);
      }
      [HttpPost]
      public async Task<IActionResult> AddWalkWalkAsync([FromBody]Models.DTO.AddWalkRequest addWalkRequest)
      {
         var walk = new Models.Domain.Walk()
         {
            Length = addWalkRequest.Length,
            Name = addWalkRequest.Name,
            RegionId = addWalkRequest.RegionId,
            WalkDifficultyId = addWalkRequest.WalkDifficultyId
         };
         walk = await walkRepository.AddWalkAsync(walk);
         var walkDTO = new Models.DTO.Walk()
         {
            Id = walk.Id,
            Length = walk.Length,
            Name = walk.Name,
            RegionId = walk.RegionId,
            WalkDifficultyId = walk.WalkDifficultyId

         };

         return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
      }
      [HttpDelete]
      [Route("{id:guid}")]
      public async Task<IActionResult> DeleteWalkAsync(Guid id)
      {
         var walk = await walkRepository.DeleteWalkAsync(id);
         if (walk == null) return NotFound();
         var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
         return Ok(walkDTO);

      }
      [HttpPut]
      [Route("{id:guid}")]
      public async Task<IActionResult> UpdateWalkAsync([FromRoute]Guid id, [FromBody]Models.DTO.UpdateWalkRequest updateReguestedWalk)
      {
         var walk = new Models.Domain.Walk
         {
            Id = id,
            Length = updateReguestedWalk.Length,
            Name = updateReguestedWalk.Name,
            RegionId = updateReguestedWalk.RegionId,
            WalkDifficultyId = updateReguestedWalk.WalkDifficultyId
         };
         var updatedWalk = await walkRepository.UpdateWalkAsync(id, walk);
         if (updatedWalk == null) 
         { 
            return NotFound();
         }
         var walkDTO = new Models.DTO.UpdateWalkRequest()
         {
            Length = updatedWalk.Length,
            Name = updatedWalk.Name,
            RegionId = updatedWalk.RegionId,
            WalkDifficultyId = updatedWalk.WalkDifficultyId
         };
         return Ok(walkDTO);

      }
   }
}
