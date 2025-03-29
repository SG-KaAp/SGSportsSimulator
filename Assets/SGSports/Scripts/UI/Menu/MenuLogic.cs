using UnityEngine;
using DG.Tweening;

namespace SGSports.UI.Menu
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private Transform mainPanel;
        public void Awake()
        {
            MenuMoveIn(mainPanel);
        }

        public void MenuMoveIn(Transform transform)
        {
            transform.DOMoveX(375, 1.5f);
        }

        public void MenuMoveOut(Transform transform)
        {
            transform.DOMoveX(-375, 1.5f);
        }
        public void AsyncLoadScene(string sceneName) => SGSports.System.AsyncSceneManager.AsyncSceneLoad(sceneName);
        public void ApplicationQuit() => Application.Quit();
    }
}