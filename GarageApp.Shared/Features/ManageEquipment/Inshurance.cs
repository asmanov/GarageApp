using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("inshurance")]
    public class Inshurance : BaseModelApp
    {
        [Column("type")]
        public string Type { get; set; } = default!;

        [Column("nomber")]
        public int Nomber { get; set; }

        [Column("start")]
        public DateOnly Start { get; set; }

        [Column("end")]
        public DateOnly End { get; set; }

        [Column("cost")]
        public double Cost { get; set; }

        [Column("track")]
        public int Track { get; set; }
    }
}
