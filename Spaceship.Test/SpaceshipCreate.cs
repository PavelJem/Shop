using Shop.Core.Dtos;
using Shop.Core.ServiceInterface;
using System;
using Xunit;

namespace Spaceship.Test
{
    public class SpaceshipCreate
    {

        private readonly ISpaceshipService _spaceship;
        public SpaceshipCreate(ISpaceshipService Spaceship)
        {
            Spaceship = _spaceship;
        }


        [Fact]
        public void When_CreateNewSpaceship_ThenItWillAddNewData()
        {
            var spaceship = new SpaceshipDto
            {
                Name = "Superman",
                Type = "Corvette",
                Mass = 123,
                Price = 123,
                ConstructedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Crew = 123
            };
            

            var result = _spaceship.Add(spaceship);

            //Assert.True(result);
        }
    }
}
