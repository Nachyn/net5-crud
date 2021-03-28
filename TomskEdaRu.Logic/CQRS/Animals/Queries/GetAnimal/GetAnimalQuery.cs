using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Logic.Common.ExternalServices.Database;

namespace TomskEdaRu.Logic.CQRS.Animals.Queries.GetAnimal
{
    public record GetAnimalQuery : IRequest<Animal>
    {
        public int Id { get; set; }
    }

    public record GetAnimalQueryHandler : IRequestHandler<GetAnimalQuery, Animal>
    {
        private readonly IAppDbContext _context;

        public GetAnimalQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> Handle(GetAnimalQuery request
            , CancellationToken cancellationToken)
        {
            return await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == request.Id,
                    cancellationToken);
        }
    }
}