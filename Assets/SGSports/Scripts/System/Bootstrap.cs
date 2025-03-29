using UnityEngine;

namespace SGSports.System
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private string nextScene;
        private void Start()
        {
            InputHandler.Initialize();
            AsyncSceneManager.AsyncSceneLoad(nextScene);
        }
    }
}