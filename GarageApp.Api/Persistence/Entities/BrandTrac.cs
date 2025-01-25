using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class BrandTrac
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ModelTrac> ModelTracs { get; set; } = new List<ModelTrac>();
}
