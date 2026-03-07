using Supabase.Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Shared.Features.ManageEquipment
{
    [Table("odometer_readings")]
    public class Events : BaseModelApp
    {
        [Column("event_date")]
        public DateOnly EventDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Column("odometr")]
        public int? Odometr {  get; set; }

        [Column("event")]
        public string EventItem { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("equipment_id")]
        public int Track {  get; set; }

        [Column("cost")]
        public double? Cost { get; set; }
    }
}
