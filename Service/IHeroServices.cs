using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public interface IHeroServices
    {
        Task<IEnumerable<Hero>> GetHeroes();
        Task<Hero> InsertHero(Hero hero);
        Task<Hero> UpdateHero(Hero hero);
        Task<Hero> GetHero(Guid heroId);
        Task<bool> DeleteHero(Guid heroId);
    }
}