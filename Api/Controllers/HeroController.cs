using System;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private readonly IHeroServices _heroService;
        private readonly IMapper _mapper;

        public HeroController(IHeroServices heroService, IMapper mapper)
        {
            _heroService = heroService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAllHeroes")]
        public async Task<IActionResult> GetHeroes()
        {
            return Ok(await _heroService.GetHeroes());
        }

        [HttpGet]
        [Route("getHero")]
        public async Task<IActionResult> GetHero(string heroId)
        {
            if (string.IsNullOrEmpty(heroId))
            {
                return BadRequest("HeroId is invalid");
            }

            return Ok(await _heroService.GetHero(Guid.Parse(heroId)));
        }

        [HttpPost]
        [Route("HeroApi")]
        public async Task<IActionResult> Hero([FromBody] HeroDto heroDto)
        {
            if (string.IsNullOrEmpty(heroDto.Name) || string.IsNullOrEmpty(heroDto.Power))
                return BadRequest("Invalid Hero");

            var hero = _mapper.Map<Hero>(heroDto);

            return Ok(await _heroService.InsertHero(hero));
        }

        [HttpPut]
        [Route("updateHero")]
        public async Task<IActionResult> UpdateHero([FromBody] HeroDto heroDto)
        {
            if (string.IsNullOrEmpty(heroDto.HeroId.ToString()))
            {
                return BadRequest("Hero Id is invalid.");
            }

            if (string.IsNullOrEmpty(heroDto.Name) || string.IsNullOrEmpty(heroDto.Power))
            {
                return BadRequest("Hero Name or Hero Power are invalid.");
            }

            return Ok(await _heroService.UpdateHero(new Hero(Guid.Parse(heroDto.HeroId), heroDto.Name, heroDto.Power)));
        }

        [HttpDelete]
        [Route("deleteHero")]
        public async Task<IActionResult> Delete(string heroId)
        {
            if (string.IsNullOrEmpty(heroId))
            {
                return BadRequest("HeroId is invalid");
            }

            return Ok(await _heroService.DeleteHero(Guid.Parse(heroId)));
        }
    }
}