using System;
using System.Collections.Generic;

namespace GarageApp.Api.Persistence.Entities;

public partial class GarageView
{
    public string? Номер { get; set; }

    public string? Марка { get; set; }

    public string? Модель { get; set; }

    public int? ГодВыпуска { get; set; }
}
