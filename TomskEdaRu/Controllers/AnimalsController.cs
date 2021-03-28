using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Logic.CQRS.Animals.Commands.PostAnimal;
using TomskEdaRu.Logic.CQRS.Animals.Commands.PutAnimal;
using TomskEdaRu.Logic.CQRS.Animals.Queries.GetAnimal;

namespace TomskEdaRu.Controllers
{
    [Route("api/animals")]
    public class AnimalsController : ApiController
    {
        [HttpGet("{Id}")]
        public async Task<Animal> GetAnimal(
            [FromRoute] GetAnimalQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<PostAnimalResponse> PostAnimal(
            [FromBody] PostAnimalCmd cmd)
        {
            return await Mediator.Send(cmd);
        }

        [HttpPut]
        public async Task PostAnimal(
            [FromBody] PutAnimalCmd cmd)
        {
            await Mediator.Send(cmd);
        }
    }
}