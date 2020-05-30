using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    public class HeroService : IHeroServices
    {
        private readonly IHeroRepository repository;
        
        public HeroService(IHeroRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Hero>> GetHeroes()
        {
            return await repository.GetHeroes();
        }
        public async Task<Hero> GetHero(Guid heroId)
        {
            return await repository.GetHero(heroId);
        }
        public async Task<Hero> InsertHero(Hero hero)
        {
            if(hero.Name.Equals("Iron Man"))
            {
                var friends = new List<string> {"Iron Man 1","Iron Man 2"};

                foreach (var friend in friends)
                {
                    hero.AddHeroFriend(friend);
                }
            }

            return await repository.InsertHero(hero);
        }
        public async Task<Hero> UpdateHero(Hero hero)
        {
            return await repository.UpdateHero(hero);
        }

        public async Task<bool> DeleteHero(Guid heroId)
        {
            return await repository.DeleteHero(heroId);
        }

    }
}