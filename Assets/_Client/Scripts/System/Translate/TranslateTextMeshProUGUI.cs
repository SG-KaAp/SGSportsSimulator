using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace _Client.System.Translate
{
    public class TranslatorTextMeshProUI : MonoBehaviour
    {
        [SerializeField] private bool translateOnStart = true;
        [SerializeField] private TextMeshProUGUI textObject;
        [SerializeField] private string translateFileName;
        [SerializeField] private string translateLanguage = "English";
        [SerializeField] private int translateNumber;
        private StreamReader translateFile;
        private List<string> translatesList = new List<string>();

        private void Start()
        {
            SettingsManager.ReloadTranslates += Translate;
            if (translateOnStart)
            {
                Translate();
            }
        }

        private void OnDestroy()
        {
            SettingsManager.ReloadTranslates -= Translate;
        }

        public void Translate()
        {
            translateLanguage = SettingsManager.Language;
            translateFile = new StreamReader("Translate/" + translateLanguage + "/" + translateFileName + ".txt");
            translatesList.Clear();
            while (!translateFile.EndOfStream)
            {
                translatesList.Add(translateFile.ReadLine());
            }
            textObject.text = translatesList[translateNumber];
        }
    }
}