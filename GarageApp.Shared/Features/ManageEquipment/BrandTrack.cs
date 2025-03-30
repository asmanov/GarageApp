using Supabase.Postgrest.Attributes;
using FluentValidation;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("brand_tracks")]
    public class BrandTrack : BaseModelApp
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        //[Reference(typeof(ModelTrack))]
        //public List<ModelTrack> ModelTracks { get; set; } = default!;
    }

    public class BrandTrackValidator : AbstractValidator<BrandTrack> 
    {
        public BrandTrackValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ведіть марку авто");
        }
    }

}
