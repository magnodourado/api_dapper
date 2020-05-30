using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IHeroRepository 
    {
        Task<IEnumerable<Hero>> GetHeroes();
        Task<Hero> InsertHero(Hero hero);
        Task<Hero> UpdateHero(Hero hero);
        Task<Hero> GetHero(Guid heroId);
        Task<bool> DeleteHero(Guid heroId);
    }
}