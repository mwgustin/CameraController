using System.Text.Json.Serialization;

namespace CameraControl.Service.Vaddio
{
    public class VaddioCameraStateRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraStateDirections pan { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraStateDirections tilt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraStateDirections zoom { get; set; }

    }
}