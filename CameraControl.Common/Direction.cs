using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CameraControl.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Direction
    {
        Left, 
        Right, 
        Up,
        Down,
        In, 
        Out,
        Stop
    }
}