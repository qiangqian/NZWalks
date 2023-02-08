using Microsoft.AspNetCore.Mvc;
using NZWalks.api.Repository;
using NZWalks.api.Models;
using AutoMapper;
using NZWalks.api.Models.Domain;
using System.Runtime.CompilerServices;
using NZWalks.api.Data;

namespace NZWalks.api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class WalkDifficultyController:Controller
   {
      private readonly IWalkDifficultyRepository walkDifficultyRepository;
      private readonly IMapper mapper;

      public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
      {
         this.walkDifficultyRepository = walkDifficultyRepository;
         this.mapper = mapper;
      }
      [HttpGet]
      public async Task<ActionResult> GetAllWalkDifficultiesAsync()
      {
         var walkDifficulties = await walkDifficultyRepository.GetAllAsync();
         var walkDifficultiesDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);
         return Ok(walkDifficultiesDTO);

      }
      [HttpGet]
      [Route("{id:guid}")]
      [ActionName("GetWalkDifficultyAsync")]
      public async Task<ActionResult> GetWalkDifficultyAsync(Guid id)
      {
         var walkDifficulty = await walkDifficultyRepository.GetWalkDifficultyAsync(id);
         if(walkDifficulty == null) return NotFound();
         var walkDifficultiesDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
         return Ok(walkDifficultiesDTO);
      }
      [HttpPost]
      public async Task<ActionResult> AddWalkDifficulty(Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
      {
         var walkDifficulty = new WalkDifficulty()
         {
            Code = addWalkDifficultyRequest.Code
         };

         walkDifficulty = await walkDifficultyRepository.AddWalkDifficultyAsync(walkDifficulty);
         var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
         return CreatedAtAction(nameof(GetWalkDifficultyAsync), new {id= walkDifficulty.Id}, walkDifficultyDTO);
      }
      [HttpPut]
      public async Task<ActionResult> UpdateWalkDifficulty(Guid id, Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
      {
         var walkDifficulty = new Models.Domain.WalkDifficulty
         {
            Code = updateWalkDifficultyRequest.Code
         };
         walkDifficulty = await walkDifficultyRepository.UpdateWalkDifficultyAsync(id, walkDifficulty);
         if(walkDifficulty== null) return NotFound();
         var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty> (walkDifficulty);
         return Ok(walkDifficultyDTO);
      }

      [HttpDelete]
      [Route("{id:guid}")]
      public async Task<ActionResult> DeleteWalkDifficulty(Guid id)
      {
         var walkDifficulty = await walkDifficultyRepository.RemoveWalkDifficultyAsync(id);
         if(walkDifficulty== null) return NotFound();
         var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
         return Ok(walkDifficultyDTO); 
      }

   }
}
