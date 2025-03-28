using UnityEngine;

namespace SGSports.System
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            InputHandler.Initialize();
            //FindFirstObjectByType<AsyncSceneManager>().AsyncSceneLoad("Menu");
        }
    }
}