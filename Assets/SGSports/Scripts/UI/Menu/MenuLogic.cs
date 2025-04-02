using UnityEngine;
using DG.Tweening;
using SGSports.System;
using System;

namespace SGSports.UI.Menu
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private Transform mainPanel;
        [SerializeField] private Controller[] controllersIcon;
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

        public void VSyncSet(bool enable) => SettingsManager.EnableVSync(enable ? 1 : 0);
        public void MSAASet(Int32 value)
        {
            if (value == 0)
                value = 1;
            else if (value == 1)
                value = 2;
            else if (value == 2)
                value = 4;
            else if (value == 3)
                value = 8;
            SettingsManager.EnableMSAA(value);
        }
        public void AsyncLoadScene(string sceneName) => SGSports.System.AsyncSceneManager.AsyncSceneLoad(sceneName);
        public void ApplicationQuit() => Application.Quit();
        public void ControllerConnected()
        {

        }
    }
    [Serializable]
    public class Controller
    {
        [SerializeField] private GameObject controllerIcon;
        [SerializeField] private int controllerId;
        public GameObject ControllerIcon => controllerIcon;
        public int ControllerId => controllerId;
    }
}