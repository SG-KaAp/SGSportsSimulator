using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Client.System
{
    public static class SettingsManager
    {
        public static string Language { get; private set; } = "English";
        private static UniversalRenderPipelineAsset _currentAsset = UniversalRenderPipeline.asset;
        public static event Action ReloadTranslates;
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

        public static void SetLanguage(int lang)
        {
            switch (lang)
            {
                case 0:
                    Language = "English";
                    break;
                case 1:
                    Language = "Russian";
                    break;
            }
            ReloadTranslates?.Invoke();
        }
    }
}