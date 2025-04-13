using Newtonsoft.Json.Linq;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("tacho_actions")]
    public class TachoAction : BaseModelApp
    {
        [Column("start")]
        public DateOnly Start { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Column("end")]
        public DateOnly End { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(2));

        [Column("track")]
        public int Track { get; set; }
    }
}
