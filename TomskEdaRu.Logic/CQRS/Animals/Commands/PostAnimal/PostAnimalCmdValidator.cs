using FluentValidation;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using TomskEdaRu.Logic.Common.AppConfigs.Main;

namespace TomskEdaRu.Logic.CQRS.Animals.Commands.PostAnimal
{
    public class PostAnimalCmdValidator : AbstractValidator<PostAnimalCmd>
    {
        public PostAnimalCmdValidator(IOptions<AnimalConfig> animalConfigOptions
            , IStringLocalizer<AnimalsResource> animalLocalizer)
        {
            var animalConfig = animalConfigOptions.Value;

            RuleFor(v => v.Name)
                .MaximumLength(animalConfig.NameMaxLength)
                .WithMessage(animalLocalizer["AnimalNameMaxLength", animalConfig.NameMaxLength]);
        }
    }
}