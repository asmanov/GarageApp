using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class ModelTrac
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public int? BrandName { get; set; }

    public int? MaxMass { get; set; }

    public int? ServMass { get; set; }

    public int? Capacity { get; set; }

    public virtual BrandTrac? BrandNameNavigation { get; set; }

    public virtual ICollection<Garage> Garages { get; set; } = new List<Garage>();
}
