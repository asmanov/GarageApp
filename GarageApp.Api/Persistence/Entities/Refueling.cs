using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class Refueling
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int Site { get; set; }

    public string? Equipment { get; set; }

    public long Tguser { get; set; }

    public decimal Volume { get; set; }

    public virtual Garage? EquipmentNavigation { get; set; }

    public virtual Site SiteNavigation { get; set; } = null!;

    public virtual Tguser TguserNavigation { get; set; } = null!;
}
