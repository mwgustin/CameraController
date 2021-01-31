Initial pass at a standardized camera control interface with pluggable camera modules. 

Structure:
- CameraControl.Backend is a backend webapi that handles the injection of the various cameras and the central api for directing controls.
- CameraControl.Common is a set of standard classes, enums and interfaces.
- CameraControl.Service.* This will be the set of camera control modules for different protocols, implementing CameraControl.Common
- CameraControl.WebUI is a Blazor web ui that connects to the Backend.

Notes:
- Uses Docker and docker-compose currently to connect the frontend and backend. 
  - may migrate to kubernetes eventually.
- Currently camera services are plugged in via Dependency Injection (Backend > Startup.cs) and numbered/resolved via a CameraResolver service.



TODO:
- Finish implementing frontend.
  - Presets
- Auto config of frontend from a metadata endpoint
  - Configure number of camers, camera names, preset names, etc
- Figure out system configuration..
  - define cameras, names, types
  - define endpoints
  - Docker env variable configurations
- General refactor
  - Can movement commands be combined? Especially Pan/Tilt?
- More cameras
