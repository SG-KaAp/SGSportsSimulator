using UnityEngine;

namespace SGSports.System
{
    public class Manager : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}