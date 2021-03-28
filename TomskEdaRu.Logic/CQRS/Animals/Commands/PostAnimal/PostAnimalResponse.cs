using System;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Domain.Enums;
using TomskEdaRu.Logic.Common.Mappings;

namespace TomskEdaRu.Logic.CQRS.Animals.Commands.PostAnimal
{
    public record PostAnimalResponse : IMapFrom<Animal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}