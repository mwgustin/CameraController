using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CameraControl.Common;
using Microsoft.Extensions.Logging;

namespace CameraControl.Service.Vaddio
{
    public class VaddioControlTelnet : ICamera, IDisposable
    {
        private readonly ILogger<VaddioControlTelnet> _logger;

        private readonly PrimS.Telnet.Client _telnet;

        public VaddioControlTelnet(ILogger<VaddioControlTelnet> logger)
        {
            _logger = logger;
            // _telnet = new PrimS.Telnet.Client("10.0.0.5", 23, default);
            _telnet = new PrimS.Telnet.Client("localhost", 2701, default);
            _logger.LogInformation("Logging in");
            var result = _telnet.TryLoginAsync("admin", "password",1000).Result;
        }

        public async Task Pan(Direction direction, int speed)
        {
            string command = "camera pan ";
            var finalSpeed = speed > 0 && speed <= 24 ? speed : 12;

            switch(direction)
            {
                case Direction.Left:
                    command += $"left {finalSpeed}";
                    break;
                case Direction.Right:
                    command += $"right {finalSpeed}";
                    break;
                default:
                    command += "stop";
                    break;
            }

            await ExecuteCommandAsync(command);
        }

        public async Task Tilt(Direction direction, int speed)
        {
            string command = "camera tilt ";
            var finalSpeed = speed > 0 && speed <= 20 ? speed : 10;

            switch(direction)
            {
                case Direction.Up:
                    command += $"up {finalSpeed}";
                    break;
                case Direction.Down:
                    command += $"down {finalSpeed}";
                    break;
                default:
                    command += "stop";
                    break;
            }

            await ExecuteCommandAsync(command);
        }

        public async Task Zoom(Direction direction, int speed)
        {
            string command = "camera zoom ";
            var finalSpeed = speed > 0 && speed <= 7 ? speed : 3;

            switch(direction)
            {
                case Direction.In:
                    command += $"in {finalSpeed}";
                    break;
                case Direction.Out:
                    command += $"out {finalSpeed}";
                    break;
                default:
                    command += "stop";
                    break;
            }

            await ExecuteCommandAsync(command);
        }

        public async Task RecallPreset(int presetNum)
        {
            string command;
            switch(presetNum)
            {
                case 0:
                    command = "camera home";
                    break;
                default:
                    command = "camera preset recall " + presetNum;
                    break;
            }
            
            await ExecuteCommandAsync(command);
        }

        public async Task StorePreset(int presetNum)
        {
            string command;
            switch(presetNum)
            {
                case 0:
                    return;
                default:
                    command = "camera preset store " + presetNum;
                    break;
            }
            
            await ExecuteCommandAsync(command);
        }

        private async Task ExecuteCommandAsync(string command)
        {
            _logger.LogInformation($"Executing command: {command}");
            await _telnet.WriteLine(command + "\r");
        }


        public void Dispose()
        {
            _telnet.Dispose();
        }
        #region Helpers
        
        private int PresetNumToInt(PresetNumber number)
        {
            switch(number)
            {
                case PresetNumber.One:
                    return 1;
                case PresetNumber.Two:
                    return 2;
                case PresetNumber.Three:
                    return 3;
                case PresetNumber.Four:
                    return 4;
                case PresetNumber.Five:
                    return 5;
                case PresetNumber.Six:
                    return 6;
                case PresetNumber.Seven:
                    return 7;
                case PresetNumber.Eight:
                    return 8;
                case PresetNumber.Nine:
                    return 9;
                case PresetNumber.Ten:
                    return 10;
                case PresetNumber.Eleven:
                    return 11;
                case PresetNumber.Twelve:
                    return 12;
                default:
                    return 1;
            }
            
        }

        public Task PanTilt(Direction panDirection, Direction tiltDirection, int panSpeed, int tiltSpeed)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
