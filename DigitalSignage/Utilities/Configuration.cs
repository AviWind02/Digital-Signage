using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignage.Utilities
{
    internal class Configuration
    {
        private RegistrationManager registrationManager;

        public Configuration() {
            registrationManager = new RegistrationManager();
        }

        public void LoadConfiguration()
        {
            GlobalVariables.MaxPptPlaybackCount = registrationManager.ReadRegistryValue("MaxPlaybackCountPPT");
            GlobalVariables.MaxVideoPlaybackCount = registrationManager.ReadRegistryValue("MaxPlaybackCountVideo");
            GlobalVariables.PowerpointChance = registrationManager.ReadRegistryValue("PowerPointChance");
            GlobalVariables.VideoChance = registrationManager.ReadRegistryValue("VideoChance");
            GlobalVariables.DelayPerSlide = registrationManager.ReadRegistryValue("Slide Delay");
            GlobalVariables.FilePath = registrationManager.ReadRegistryValueString("File Path");
        }

        public void SaveConfiguration()
        {
            registrationManager.WriteRegistryValue("MaxPlaybackCountPPT", GlobalVariables.MaxPptPlaybackCount);
            registrationManager.WriteRegistryValue("MaxPlaybackCountVideo", GlobalVariables.MaxVideoPlaybackCount);
            registrationManager.WriteRegistryValue("PowerPointChance", GlobalVariables.PowerpointChance);
            registrationManager.WriteRegistryValue("VideoChance", GlobalVariables.VideoChance);
            registrationManager.WriteRegistryValue("Slide Delay", GlobalVariables.DelayPerSlide);
            registrationManager.WriteRegistryValueAsString("File Path", GlobalVariables.FilePath);

        }

        public void SaveFilePath()
        {
            registrationManager.WriteRegistryValueAsString("File Path", GlobalVariables.FilePath);
        }

    }
}
