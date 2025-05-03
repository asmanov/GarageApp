using FluentValidation;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("garage")]
    public class Garage : BaseModelApp
    {
        [Column("registration_number")]
        public string RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                _registrationNumber = value;
                Image = SetImageName(value);
            }
        }

        private string _registrationNumber = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("volume_fuel_tank")]
        public int? VolumeFuelTank { get; set; }

        [Column("vin")]
        public string Vin { get; set; } = default!;

        [Column("image")]
        public string? Image { get; set; }

        [Column("model_id")]
        public int ModelId { get; set; }

        [Column("site_id")]
        public int? SiteId { get; set; }

        private static string SetImageName(string registrationNomber)
        {
            var saveName = registrationNomber;
            saveName = saveName.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
            saveName = saveName + ".jpg";
            return saveName;
        }
    }

    public class GarageValidator : AbstractValidator<Garage>
    {
        public GarageValidator()
        {
            RuleFor(x => x.RegistrationNumber)
                .NotEmpty()
                .WithMessage("Ведіть державний номер")
                .Length(8, 11)
                .WithMessage("Державний номер має 8 символів");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Ведіть тип авто");
            RuleFor(x => x.Year)
                .InclusiveBetween(2000, 2025)
                .WithMessage("Значення повино бути між 2000 та 2025")
                .NotEmpty()
                .WithMessage("Ведіть рік виробництва");
             RuleFor(x => x.Vin)
                .NotEmpty()
                .WithMessage("Ведіть VIN номер")
                .Length(17)
                .WithMessage("VIN номер повинен мати 17 символів");
        }
    }
}
