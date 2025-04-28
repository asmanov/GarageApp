using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("model_tracks")]
    public class ModelTrack : BaseModelApp
    {
        [Column("name")]
        public string Name { get; set; } = default!;

        [Column("euro")]
        public int Euro { get; set; } = 0;

        [Column("max_mass")]
        public int MaxMass { get; set; }

        [Column("serv_mass")]
        public int ServMass { get; set; }

        [Column("engine_volume")]
        public int EngineVolume { get; set; }

        [Column("brand")]
        public int BrandId { get; set; }

    }
}
