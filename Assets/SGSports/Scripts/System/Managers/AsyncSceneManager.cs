using UnityEngine;
using UnityEngine.SceneManagement;

namespace SGSports.System
{
    public class AsyncSceneManager : MonoBehaviour
    {
        private AsyncOperation level;
        public void AsyncSceneLoad(string sceneName)
        {
            level = SceneManager.LoadSceneAsync(sceneName);
            level.allowSceneActivation = true;
        }
    }
}