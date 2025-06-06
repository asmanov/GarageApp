﻿using Supabase.Postgrest.Attributes;
using FluentValidation;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("brand_tracks")]
    public class BrandTrack : BaseModelApp
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;
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
