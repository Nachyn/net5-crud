using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Domain.Enums;
using TomskEdaRu.Logic.Common.ExternalServices.Database;
using TomskEdaRu.Logic.Common.ExternalServices.DateTimeService;

namespace TomskEdaRu.Logic.CQRS.Animals.Commands.PostAnimal
{
    public record PostAnimalCmd : IRequest<PostAnimalResponse>
    {
        public string Name { get; set; }

        public AnimalType Type { get; set; }
    }

    public class PostAnimalCmdHandler : IRequestHandler<PostAnimalCmd, PostAnimalResponse>
    {
        private readonly IAppDbContext _context;

        private readonly IDateTimeService _dateTimeService;

        private readonly IMapper _mapper;

        public PostAnimalCmdHandler(IAppDbContext context
            , IDateTimeService dateTimeService
            , IMapper mapper)
        {
            _context = context;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        public async Task<PostAnimalResponse> Handle(PostAnimalCmd request
            , CancellationToken cancellationToken)
        {
            var newAnimal = new Animal
            {
                Name = request.Name,
                Type = request.Type,
                CreatedUtc = _dateTimeService.NowUtc
            };

            _context.Animals.Add(newAnimal);

            await _context.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostAnimalResponse>(newAnimal);
        }
    }
}