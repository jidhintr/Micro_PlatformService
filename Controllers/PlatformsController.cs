using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTO;
using PlatformService.Models;

namespace PlatformService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("Getting platform values ----");
            var result = _repo.GetAllPlatforms();
            var value = _mapper.Map<IEnumerable<PlatformReadDto>>(result);
            return base.Ok(value);
        }

        [HttpGet("{id}", Name = "GetPlatformByIds")]
        public ActionResult<PlatformReadDto> GetPlatformByIds(int id)
        {
            Console.WriteLine("Getting platform values ----");
            var result = _repo.GetPlatformById(id);
            var value = _mapper.Map<PlatformReadDto>(result);
            return base.Ok(value);
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformDto)
        {
            var model = _mapper.Map<Platform>(platformDto);
            _repo.CreatePlatform(model);
            _repo.SaveChanges();
            var mapper = _mapper.Map<PlatformReadDto>(model);
            return CreatedAtRoute(nameof(GetPlatformByIds), new { id = mapper.Id },platformDto);
           
        }


    }

}