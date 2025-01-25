using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class Garage
{
    public string Id { get; set; } = null!;

    public int? Model { get; set; }

    public string? Type { get; set; }

    public int? Year { get; set; }

    public int? FuelTank { get; set; }

    public string? Vin { get; set; }

    public int? Sites { get; set; }

    public string? Image { get; set; }

    public virtual ModelTrac? ModelNavigation { get; set; }

    public virtual ICollection<Refueling> Refuelings { get; set; } = new List<Refueling>();

    public virtual Site? SitesNavigation { get; set; }
}
