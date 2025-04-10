using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Client.System
{
    public static class SettingsManager
    {

        private static UniversalRenderPipelineAsset _currentAsset = UniversalRenderPipeline.asset;
        public static void Initialize()
        {

        }
        public static void EnableVSync(int enable)
        {
            QualitySettings.vSyncCount = enable;
        }

        public static void EnableMSAA(int value)
        {
            _currentAsset.msaaSampleCount = value;
        }
    }
}