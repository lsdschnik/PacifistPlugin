using Exiled.API.Interfaces;

namespace PacifistPlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool PacifistModeEnabled { get; set; } = true;
    }
}
