using System.Threading.Tasks;

namespace CameraControl.Common
{
    public delegate ICamera CameraResolver(string name);
    public interface ICamera
    {
        Task Pan(Direction direction, int speed);
        Task Tilt(Direction direction, int speed);
        Task Zoom(Direction direction, int speed);
        Task RecallPreset(int presetNum);
        Task StorePreset(int presetNum);
    }
}