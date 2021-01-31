using System.Text.Json.Serialization;

namespace CameraControl.Service.Vaddio
{
    public class VaddioCameraPresetRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraPresetRecallDirections recall { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VaddioCameraPresetStoreDirections store { get; set; }
    }
}