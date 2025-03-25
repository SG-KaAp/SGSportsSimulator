using UnityEngine;

namespace SGSports.System
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Manager[] managers;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            foreach (Manager manager in managers)
            {
                Instantiate(manager, gameObject.transform);
            }

            FindFirstObjectByType<AsyncSceneManager>().AsyncSceneLoad("Menu");
        }
    }
}