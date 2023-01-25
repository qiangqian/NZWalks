using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;
using NZWalks.api.Repository;

namespace NZWalks.api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class RegionController : Controller
   {
      private readonly IRegionRepository regionRepository;
      private readonly IMapper mapper;

      public RegionController(IRegionRepository regionRepository, IMapper mapper)
      {
         this.regionRepository = regionRepository;
         this.mapper = mapper;
      }


      [HttpGet]
      public async Task<IActionResult> GetAllRegionsAsync()
      {
         var regions = await regionRepository.GetAllAsync();
         //var regionsDTO = new List<Models.DTO.Region>();
         //regions.ToList().ForEach(region => 
         //{ 
         //   var regionDTO =new Models.DTO.Region()
         //   {
         //      Id=region.Id,
         //      Code=region.Code,
         //      Name = region.Code,
         //      Area = region.Area,
         //      Lat = region.Lat,
         //      Long = region.Long,
         //      Population = region.Population
         //   };
         //   regionsDTO.Add(regionDTO);
         //});
         var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
         return Ok(regionsDTO);
      }

      [HttpGet]
      [Route("{id:guid}")]
      [ActionName("GetRegionAsync")]
      public async Task<IActionResult> GetRegionAsync(Guid id)
      {
         var region = await regionRepository.GetRegion(id);
         if (region == null)
         {
            return NotFound();
         }
         var regionDTO = mapper.Map<Models.DTO.Region>(region);
         return Ok(regionDTO);
      }
      [HttpPost]
      public async Task<IActionResult> AddRegionRegionAsync(Models.DTO.AddRegionRequest addRegionRequest) { 
         var region = new Models.Domain.Region() { 
            Code= addRegionRequest.Code,
            Area= addRegionRequest.Area,
            Lat= addRegionRequest.Lat,
            Long= addRegionRequest.Long,
            Name= addRegionRequest.Name,
            Population= addRegionRequest.Population
            
         };
         region = await regionRepository.AddRegionAsync(region);
         var regionDTO = new Models.DTO.Region()
         {
            Id= region.Id,
            Code = region.Code,
            Area = region.Area,
            Lat = region.Lat,
            Long = region.Long,
            Name = region.Name,
            Population = region.Population

         };

         return CreatedAtAction(nameof(GetRegionAsync), new {id= regionDTO.Id }, regionDTO);
      }
      [HttpDelete]
      public async Task<IActionResult> DeleteRegionAsync(Guid id)
      {
         var region =await regionRepository.DeleteRegionAsync(id);
         if(region==null) return NotFound();
         var regionDTO = new Models.DTO.Region
         {
            Id = region.Id,
            Code = region.Code,
            Area = region.Area,
            Lat = region.Lat,
            Long = region.Long,
            Name = region.Name,
            Population = region.Population
         };
         return Ok(regionDTO);

      }
      [HttpPut]
      public async Task<IActionResult> UpdateRegionAsync(Guid id, Models.DTO.UpdateRegionRequest updateReguestedRegion) 
      {
         var region = new Models.Domain.Region
         {
            Code = updateReguestedRegion.Code,
            Area = updateReguestedRegion.Area,
            Lat = updateReguestedRegion.Lat,
            Long = updateReguestedRegion.Long,
            Name = updateReguestedRegion.Name,
            Population = updateReguestedRegion.Population
         };
         var updatedRegion = await regionRepository.UpdateRegionAsync(id, region);
         var regionDTO = new Models.DTO.UpdateRegionRequest()
         {
            Code = region.Code,
            Area = region.Area,
            Lat = region.Lat,
            Long = region.Long,
            Name = region.Name,
            Population = region.Population
         };
         return Ok(regionDTO);

      }
   }
}
