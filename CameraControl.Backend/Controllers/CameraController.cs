using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraControl.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraControl.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CameraController : ControllerBase
    {

        private readonly ILogger<CameraController> _logger;
        private readonly CameraResolver _cameraResolver;

        public CameraController(ILogger<CameraController> logger, CameraResolver cameraResolver)
        {
            _logger = logger;
            _cameraResolver = cameraResolver;
        }

        [HttpGet("{cameraNumber}/Pan")]
        public async Task<IActionResult> GetPan([FromQuery]Direction direction, [FromQuery] int speed, [FromRoute] string cameraNumber)
        {
            var _camera = _cameraResolver(cameraNumber);
            await _camera.Pan(direction, speed);
            return Ok();
        }
        [HttpGet("{cameraNumber}/Tilt")]
        public async Task<IActionResult> GetTilt([FromQuery]Direction direction, [FromQuery] int speed, [FromRoute] string cameraNumber)
        {
            var _camera = _cameraResolver(cameraNumber);
            await _camera.Tilt(direction, speed);
            return Ok();
        }
        [HttpGet("{cameraNumber}/Zoom")]
        public async Task<IActionResult> GetZoom([FromQuery]Direction direction, [FromQuery] int speed, [FromRoute] string cameraNumber)
        {
            var _camera = _cameraResolver(cameraNumber);
            await _camera.Zoom(direction, speed);
            return Ok();
        }
        [HttpGet("{cameraNumber}/Preset/Recall")]
        public async Task<IActionResult> GetPresetRecall([FromQuery]int presetNumber, [FromRoute] string cameraNumber)
        {
            var _camera = _cameraResolver(cameraNumber);
            await _camera.RecallPreset(presetNumber);
            return Ok();
        }
        [HttpGet("{cameraNumber}/Preset/Store")]
        public async Task<IActionResult> GetPresetStore([FromQuery]int presetNumber, [FromRoute] string cameraNumber)
        {
            var _camera = _cameraResolver(cameraNumber);
            await _camera.StorePreset(presetNumber);
            return Ok();
        }
    }
}
