using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using TomskEdaRu.Domain.Enums;
using TomskEdaRu.Logic.Common.Exceptions.Api;
using TomskEdaRu.Logic.Common.ExternalServices.Database;
using TomskEdaRu.Logic.CQRS.Animals.Queries.GetAnimal;

namespace TomskEdaRu.Logic.CQRS.Animals.Commands.PutAnimal
{
    public record PutAnimalCmd : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }
    }

    public class PutAnimalCmdHandler : IRequestHandler<PutAnimalCmd, Unit>
    {
        private readonly IStringLocalizer<AnimalsResource> _animalLocalizer;
        
        private readonly IAppDbContext _context;

        //это IMediator
        private readonly ISender _sender;

        public PutAnimalCmdHandler(IAppDbContext context
            , ISender sender
            , IStringLocalizer<AnimalsResource> animalLocalizer)
        {
            _context = context;
            _sender = sender;
            _animalLocalizer = animalLocalizer;
        }

        public async Task<Unit> Handle(PutAnimalCmd request
            , CancellationToken cancellationToken)
        {
            var animal = await _sender.Send(new GetAnimalQuery
            {
                Id = request.Id
            });

            if (animal == null)
            {
                //обычно BadRequestException
                throw new NotFoundException(_animalLocalizer["AnimalNotFound"]);
            }

            //вернулась Entity EF Core 'Animal' --> может изменить данные в БД
            animal.Name = request.Name;
            animal.Type = request.Type;
            await _context.SaveChangesAsync(CancellationToken.None);

            return Unit.Value;
        }
    }
}