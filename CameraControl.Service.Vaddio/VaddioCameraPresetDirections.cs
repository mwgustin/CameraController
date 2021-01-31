namespace CameraControl.Service.Vaddio
{
    public class VaddioCameraPresetRecallDirections
    {
        public int id { get; set; }
    }
    
    //{"store":{"id":0,"user_label":"Band","focus":false,"color_correction":true}}
    public class VaddioCameraPresetStoreDirections
    {
        public int id { get; set; }
        public string user_label { get; set; }
        public bool focus { get; set; }
        public bool color_correction { get; set; }
    }
}