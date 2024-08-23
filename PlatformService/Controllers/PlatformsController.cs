using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers {

    [Route("api/[controller]")]
    [ApiController]// allows functionalities related to passing through data via actions
    public class PlatformsController : ControllerBase 
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repository = repo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms() {
            Console.WriteLine("--> Getting Platforms from PlatformService....");
            //pull platfoms from repository
            var platformItems = _repository.GetAllPlatforms(); //returns the list of all platform objects via repo

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));//http 200
        }

        [HttpGet("{id}", Name ="GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id) {
            var platformItem = _repository.GetPlatformById(id);

            if (platformItem != null) {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
    }

        //TRIGGERING MESSGAING TO OTHER SERVICES
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto) 
        {
            //map dto to temporary repository
            var platformModel = _mapper.Map<Platform>(platformCreateDto);

            _repository.CreatePlatForm(platformModel);

            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            //TRIGGERING MESSGAING TO OTHER SERVICES
            //send sync message
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            //return Ok(platformReadDto);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto}, platformReadDto);
        }
}}
