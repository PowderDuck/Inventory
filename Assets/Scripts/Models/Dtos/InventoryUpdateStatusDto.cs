using Assets.Scripts.Enums;
using Newtonsoft.Json;

namespace Assets.Scripts.Models.Dtos
{
    public class InventoryUpdateStatusDto
    {
        [JsonProperty(PropertyName = "type")]
        public PickableType Type { get; set; }

        [JsonProperty(PropertyName = "isSet")]
        public bool IsSet { get; set; }
    }
}