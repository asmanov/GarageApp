using Supabase.Postgrest.Attributes;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("sites")]
    public class Site : BaseModelApp
    {
        [Column("name")]
        public string Name { get; set; } = default!;

        [Column("fuel_tank")]
        public int FuelTank { get; set; }

        //[Reference(typeof(ModelTrack))]
        //public List<ModelTrack> ModelTracks { get; set; } = default!;
    }
}
