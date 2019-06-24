using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroesApi.services;
using HeroesApi;
using System.Collections.Generic;
using System.Linq;

namespace HeroesServiceTest
{
    [TestClass]
    public class HeroesServiceTest
    {
        [TestMethod]
        public void HeroesService_ShouldIntializeNewHeroesList()
        {
            HeroesService heroesService = new HeroesService();

            Assert.IsNotNull(heroesService.GetHeroes());
        }

        // Do not move this method from it's place
        [TestMethod]
        public void Add_AddANewHero_WhenHeroPassed()
        {
            HeroesService heroesService = new HeroesService();

            Hero hero = new Hero()
            {
                Name = "kyle",
                Pic = "https://images2.minutemediacdn.com/image/upload/c_crop,h_1180,w_2100,x_0,y_94/f_auto,q_auto,w_1100/v1555001162/shape/mentalfloss/504106-wikipedia.jpg",
                Power = 1.5
            };

            int id = heroesService.GenerateId();
            hero.Id = id;
            heroesService.Add(hero);

            Assert.AreEqual(id, heroesService.GetHeroes().Last().Id);
        }

        [TestMethod]
        public void GenerateId_ShouldReturnNextId()
        {
            HeroesService heroesService = new HeroesService();

            int id = heroesService.GenerateId();

            Assert.AreEqual(id, heroesService.GetHeroes().Last().Id + 1);
        }

        [TestMethod]
        public void GetById_ShouldReturnSpecifiedHero_WhenExisitingIdPassed()
        {
            HeroesService heroesService = new HeroesService();

            Hero hero = heroesService.GetById(1);

            Assert.AreEqual("Pasha", hero.Name);
        }

        [TestMethod]
        public void GetById_ShouldReturnNull_WhenUnknownIdPassed()
        {
            HeroesService heroesService = new HeroesService();

            Hero hero = heroesService.GetById(5000);

            Assert.IsNull(hero);
        }

        [TestMethod]
        public void GetHeroes_ShouldReturnAllHeroes()
        {
            HeroesService heroesService = new HeroesService();

            IEnumerable<Hero> heroes = heroesService.GetHeroes();

            Assert.AreEqual(5, heroes.Count());
        }

        // Do not move this method from it's place
        [TestMethod]
        public void Update_ShouldReplaceSpecifiedHero_WhenHeroPassed()
        {
            HeroesService heroesService = new HeroesService();

            Hero hero = new Hero()
            {
                Id = 5,
                Name = "kyle",
                Pic = "https://images2.minutemediacdn.com/image/upload/c_crop,h_1180,w_2100,x_0,y_94/f_auto,q_auto,w_1100/v1555001162/shape/mentalfloss/504106-wikipedia.jpg",
                Power = 0.7
            };

            heroesService.Update(hero);

            Assert.AreEqual(0.7, heroesService.GetHeroes().Last().Power);
        }

        [TestMethod]
        public void SearchHeroes_ShouldReturnHeroesWithCorrectName_WhenKnownNameIsPassed()
        {
            HeroesService heroesService = new HeroesService();
            string name = "ky";

            IEnumerable<Hero> filtered = heroesService.SearchHeroes(name);

            Assert.AreEqual(1, filtered.Count());
        }

        [TestMethod]
        public void SearchHeroes_ShouldReturnEmpty_WhenUnknownNameIsPassed()
        {
            HeroesService heroesService = new HeroesService();

            string name = "boi";

            IEnumerable<Hero> filtered = heroesService.SearchHeroes(name);

            Assert.AreEqual(0, filtered.Count());
        }

        // Do not move this method from it's place
        [TestMethod]
        public void Remove_ShouldRemoveSpecifiedHero_WhenExistingIdPassed()
        {
            HeroesService heroesService = new HeroesService();

            heroesService.Remove(5);

            Assert.AreEqual(4, heroesService.GetHeroes().Count());
        }
    }
}
