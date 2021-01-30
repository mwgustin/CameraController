using System.Text.Json.Serialization;

namespace CameraControl.Service.Vaddio
{
    public class VaddioCameraPresetRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraPresetDirections recall { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraPresetDirections store { get; set; }
    }
}