using System;
using System.Net.Http;
using System.Threading.Tasks;
using CameraControl.Common;

namespace CameraControl.WebUI.Data
{
    public class CameraControlService
    {
        private readonly HttpClient _client;

        public CameraControlService(HttpClient clent)
        {
            _client = clent;
        }

        public async Task Pan(int cameraNumber, Direction direction)
        {
            string url = $"/Camera/{cameraNumber}/Pan?";
            switch(direction)
            {
                case Direction.Left:
                    url += "direction=Left";
                    break;
                case Direction.Right:
                    url += "direction=Right";
                    break;
                default:
                    url += "direction=Stop";
                    break;
            }
            await _client.GetAsync(url);
        }

        public async Task Tilt(int cameraNumber, Direction direction)
        {
            string url = $"/Camera/{cameraNumber}/Tilt?";
            switch(direction)
            {
                case Direction.Up:
                    url += "direction=Up";
                    break;
                case Direction.Down:
                    url += "direction=Down";
                    break;
                default:
                    url += "direction=Stop";
                    break;
            }
            await _client.GetAsync(url);
        }

        public async Task PanTilt(int cameraNumber, Direction panDirection, Direction tiltDirection)
        {
            string url = $"/Camera/{cameraNumber}/PanTilt?";
            switch(panDirection)
            {
                case Direction.Left:
                    url += "panDirection=Left";
                    break;
                case Direction.Right:
                    url += "panDirection=Right";
                    break;
                case Direction.Stop:
                    url += "panDirection=Stop";
                    break;
            }

            url += "&";

            switch(tiltDirection)
            {
                case Direction.Up:
                    url += "tiltDirection=Up";
                    break;
                case Direction.Down:
                    url += "tiltDirection=Down";
                    break;
                default:
                    url += "tiltDirection=Stop";
                    break;
            }
            await _client.GetAsync(url);
        }

        public async Task Zoom(int cameraNumber, Direction direction)
        {
            string url = $"/Camera/{cameraNumber}/Zoom";
            switch(direction)
            {
                case Direction.In:
                    url += "direction=In";
                    break;
                case Direction.Up:
                    url += "direction=Up";
                    break;
                default:
                    url += "direction=Stop";
                    break;
            }
            await _client.GetAsync(url);
        }
    }
}