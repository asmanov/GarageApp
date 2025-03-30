using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GarageApp.Shared.Features.ManageEquipment
{
    public class BaseModelApp : BaseModel
    {
        [PrimaryKey("id", false)] // Автоинкрементный первичный ключ
        public int Id { get; set; }
    }
}
