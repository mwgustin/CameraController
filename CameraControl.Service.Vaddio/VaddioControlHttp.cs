using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CameraControl.Common;
using Microsoft.Extensions.Logging;

namespace CameraControl.Service.Vaddio
{
    public class VaddioControlHttp : ICamera, IDisposable
    {
        const string stateEndpoint = "/api/config/video/input/0/device/state";
        const string sessionEndpoint = "/api/config/session";
        const string presetEndpoint = "/api/config/video/input/0/device/preset";
        private readonly HttpClient _client;
        private readonly ILogger<VaddioControlHttp> _logger;

        public VaddioControlHttp(HttpClient client, ILogger<VaddioControlHttp> logger)
        {
            _client = client;
            _logger = logger;

        }

        public void Dispose()
        {
            _client.Dispose();
        }
        
        private async Task GetSessionAsync()
        {
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsync(sessionEndpoint, content);
        }

        private async Task ExecuteStateCallAsync(VaddioCameraStateRequest request)
        {
            var content = JsonContent.Create<VaddioCameraStateRequest>(request);
            await ExecuteCall(stateEndpoint, content);
        }

        private async Task ExecutePresetCallAsync(VaddioCameraPresetRequest request)
        {
            var content = JsonContent.Create<VaddioCameraPresetRequest>(request);
            await ExecuteCall(presetEndpoint, content);
        }
        private async Task ExecuteCall(string endpoint, HttpContent content)
        {
            var resp = await _client.PatchAsync(endpoint, content);
            if(resp.StatusCode == HttpStatusCode.Forbidden)
            {
                await GetSessionAsync();
                await _client.PatchAsync(endpoint, content);
            }
        }

        public async Task Pan(Direction direction, int speed)
        {
            string directionValue;
            int finalSpeed = speed > 0 && speed <= 24 ? speed : 12;

            switch(direction)
            {
                case Direction.Left:
                    directionValue = "left";
                    break;
                case Direction.Right:
                    directionValue = "right";
                    break;
                default:
                    directionValue = "stop";
                    break;
            }

            var message = new VaddioCameraStateRequest()
            {
                pan = new VaddioCameraStateDirections() { speed = finalSpeed, direction = directionValue}
            };

            await ExecuteStateCallAsync(message);
           
        }

        public async Task Tilt(Direction direction, int speed)
        {
            string directionValue;
            int finalSpeed = speed > 0 && speed <= 20 ? speed : 10;
            
            switch(direction)
            {
                case Direction.Up:
                    directionValue = "up";
                    break;
                case Direction.Down:
                    directionValue = "down";
                    break;
                default:
                    directionValue = "stop";
                    break;
            }
             var message = new VaddioCameraStateRequest()
             {
                 tilt = new VaddioCameraStateDirections() { speed = finalSpeed, direction = directionValue}
             };

             await ExecuteStateCallAsync(message);
        }

        public async Task Zoom(Direction direction, int speed)
        {
            string directionValue;
            int finalSpeed = speed > 0 && speed <= 7 ? speed : 3;
            
            switch(direction)
            {
                case Direction.In:
                    directionValue = "in";
                    break;
                case Direction.Out:
                    directionValue = "out";
                    break;
                default:
                    directionValue = "stop";
                    break;
            }
             var message = new VaddioCameraStateRequest()
             {
                 zoom = new VaddioCameraStateDirections() { speed = finalSpeed, direction = directionValue}
             };

             await ExecuteStateCallAsync(message);
        }

        public async Task RecallPreset(int presetNum)
        {
            int finalPresetNum = presetNum-1 >= 0 ? presetNum-1 : 0;
            var message = new VaddioCameraPresetRequest()
            {
                recall = new VaddioCameraPresetDirections() { id = presetNum-1}
            };
            await ExecutePresetCallAsync(message);
        }

        public async Task StorePreset(int presetNum)
        {
            int finalPresetNum = presetNum-1 >= 0 ? presetNum-1 : 0;
            var message = new VaddioCameraPresetRequest()
            {
                store = new VaddioCameraPresetDirections() { id = presetNum-1}
            };
            await ExecutePresetCallAsync(message);
        }

    }
}