using System;
using TomskEdaRu.Domain.Enums;

namespace TomskEdaRu.Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}