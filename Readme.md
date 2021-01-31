Initial pass at a standardized camera control interface with pluggable camera modules. 

Structure:
- CameraControl.Backend is a backend webapi that handles the injection of the various cameras and the central api for directing controls.
- CameraControl.Common is a set of standard classes, enums and interfaces.
- CameraControl.Service.* This will be the set of camera control modules for different protocols, implementing CameraControl.Common. Currently only Vaddio Roboshot via REST or telnet. 
- CameraControl.WebUI is a Blazor web ui that connects to the Backend.

Notes:
- Uses Docker and docker-compose currently to connect the frontend and backend. 
  - may migrate to kubernetes eventually.
- Currently camera services are plugged in via Dependency Injection (Backend > Startup.cs) and numbered/resolved via a CameraResolver service.



TODO:
- Finish implementing frontend.
  - multi-cam
  - Presets
  - Remove default blazor template
  - Mobile friendly
- Auto config of frontend from a metadata endpoint
  - Configure number of camers, camera names, preset names, etc
- Figure out system configuration..
  - define cameras, names, types
  - define endpoints
  - Docker env variable configurations
- General refactor
  - Can movement commands be combined? Especially Pan/Tilt?
- More cameras
- Does it make sense for camera modules to be individual docker services? Implemented via grpc, etc? More distributed, more pluggable. 


This is a personal project for me, but it is also intended to be used at a House of Worship to unify ptz camera control without needing a standalone controller. This is also a prototype for how an open source, container/k8s based, AV Control system might work. 