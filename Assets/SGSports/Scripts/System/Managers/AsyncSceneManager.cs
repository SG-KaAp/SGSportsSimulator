using UnityEngine;
using UnityEngine.SceneManagement;

namespace SGSports.System
{
    public static class AsyncSceneManager
    {
        private static AsyncOperation _level;
        public static AsyncOperation Level => _level;
        public static void AsyncSceneLoad(string sceneName)
        {
            _level = SceneManager.LoadSceneAsync(sceneName);
            _level.allowSceneActivation = true;
        }
    }
}