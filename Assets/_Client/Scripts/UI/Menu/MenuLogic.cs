using UnityEngine;
using DG.Tweening;
using _Client.System;
using System;

namespace _Client.UI.Menu
{
    public class MenuLogic : MonoBehaviour
    {
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject[] controllersIcons;
        [SerializeField] private Controller[] controllers;
        public void Awake()
        {
            MenuMoveIn(mainPanel);
        }
        public void MenuMoveIn(GameObject panel)
        {
            panel.SetActive(true);
            panel.transform.DOMoveX(375, 1.5f);
        }

        public void MenuMoveOut(GameObject panel)
        {
            panel.transform.DOMoveX(-375, 1.5f) .OnComplete(() =>
            {
                panel.SetActive(false);
            });
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

        public void SetLanguage (int lang) => SettingsManager.SetLanguage(lang);
        public void AsyncLoadScene(string sceneName) => _Client.System.AsyncSceneManager.AsyncSceneLoad(sceneName);
        public void ApplicationQuit() => Application.Quit();
        public void ControllerConnected()
        {
            print("Aboaba");
            controllers[1] = new Controller();
            controllers[1].ControllerInit(controllersIcons[1], 1);
        }
    }
    [Serializable]
    public class Controller
    {
        [SerializeField] private GameObject controllerIcon;
        [SerializeField] private int controllerId;
        public GameObject GetControllerIcon() => controllerIcon;
        public int GetControllerId() => controllerId;
        public void ControllerInit(GameObject icon, int id)
        {
            controllerIcon = icon;
            controllerId = id;
        }
    }
}