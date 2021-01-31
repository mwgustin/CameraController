using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using CameraControl.WebUI;
using CameraControl.WebUI.Shared;
using CameraControl.WebUI.Data;
using Microsoft.Extensions.Logging;

namespace CameraControl.WebUI.Pages
{
    public partial class FetchData
    {
        private async Task Pan(MouseEventArgs e, Common.Direction direction)
        {
            switch(e.Type)
            {
                case "mousedown":
                    await CameraService.Pan(1, direction);
                    break;
                default:
                    await CameraService.Pan(1, Common.Direction.Stop);
                    break;  
            }
        }
        private async Task Tilt(MouseEventArgs e, Common.Direction direction)
        {
            switch(e.Type)
            {
                case "mousedown":
                    await CameraService.Tilt(1, direction);
                    break;
                default:
                    await CameraService.Tilt(1, Common.Direction.Stop);
                    break;  
            }
        }
        private async Task PanTilt(MouseEventArgs e, Common.Direction panDirection, Common.Direction tiltDirection)
        {
            switch(e.Type)
            {
                case "mousedown":
                    await CameraService.PanTilt(1, panDirection, tiltDirection);
                    break;
                default:
                    await CameraService.PanTilt(1, Common.Direction.Stop, Common.Direction.Stop);
                    break;  
            }
        }
        private async Task Zoom(MouseEventArgs e, Common.Direction direction)
        {
            switch(e.Type)
            {
                case "mousedown":
                    await CameraService.Zoom(1, direction);
                    break;
                default:
                    await CameraService.Zoom(1, Common.Direction.Stop);
                    break;  
            }
        }
    }
}