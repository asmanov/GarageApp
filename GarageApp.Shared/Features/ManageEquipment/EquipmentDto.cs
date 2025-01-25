using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace GarageApp.Shared.Features.ManageEquipment
{
    public class EquipmentDto
    {
        public string Id { get; set; } = default!;
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int? Year { get; set; }
        public int Mileage { get; set; }
        public string? Vin {  get; set; }
        public int VolumeFuelTank { get; set; }
    }

    public class EquipmentValidator : AbstractValidator<EquipmentDto>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Ведіть державний номер")
                .Length(8, 11)
                .WithMessage("Державний номер має 8 символів");
            RuleFor(x => x.ModelName)
                .NotEmpty()
                .WithMessage("Ведіть модель авто");
            RuleFor(x => x.BrandName)
                .NotEmpty()
                .WithMessage("Ведіть марку авто");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Ведіть тип авто");
            RuleFor(x => x.Year)
                .InclusiveBetween(2000, 2025)
                .WithMessage("Значення повино бути між 2000 та 2025")
                .NotEmpty()
                .WithMessage("Ведіть рік виробництва");
            RuleFor(x => x.Mileage)
                .NotEmpty()
                .WithMessage("Ведіть пробіг авто");
            RuleFor(x => x.Vin)
                .NotEmpty()
                .WithMessage("Ведіть VIN номер")
                .Length(17)
                .WithMessage("VIN номер повинен мати 17 символів");
            RuleFor(x => x.VolumeFuelTank)
                .NotEmpty()
                .WithMessage("Ведіть загальний об'єм паливного бака");
        }
    }
}
