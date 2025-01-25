using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class Site
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public virtual ICollection<Garage> Garages { get; set; } = new List<Garage>();

    public virtual ICollection<Refueling> Refuelings { get; set; } = new List<Refueling>();
}
