using System;
using SGSports.System;
using UnityEngine;

namespace SGSports.UI.Menu
{
    public class MenuLogic : MonoBehaviour
    {
        private AsyncSceneManager asyncSceneManager;

        private void Awake()
        {
            asyncSceneManager = FindAnyObjectByType<AsyncSceneManager>();
        }

        public void AsyncLoadScene(string sceneName) => asyncSceneManager.AsyncSceneLoad(sceneName);
    }
}
