using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SGSports.System
{
    public static class SettingsManager
    {
        private static UniversalRenderPipelineAsset currentAsset = UniversalRenderPipeline.asset;
        public static void Initialize()
        {

        }
        public static void EnableVSync(int enable)
        {
            QualitySettings.vSyncCount = enable;
        }

        public static void EnableMSAA(int value)
        {
            currentAsset.msaaSampleCount = value;
        }
    }
}