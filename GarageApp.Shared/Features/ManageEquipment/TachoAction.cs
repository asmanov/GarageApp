﻿using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    public class TachoAction : BaseModelApp
    {
        [Column("start")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly End { get; set; }

        [Column("track")]
        public int Track { get; set; }
    }
}
