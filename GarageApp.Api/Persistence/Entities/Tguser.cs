using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class Tguser
{
    public long Userid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public bool Access { get; set; }

    public virtual ICollection<Refueling> Refuelings { get; set; } = new List<Refueling>();
}
