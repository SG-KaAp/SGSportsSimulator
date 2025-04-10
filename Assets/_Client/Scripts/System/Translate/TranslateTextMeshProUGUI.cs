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
            translateFile = new StreamReader("Translate/" + translateLanguage + "/" + translateFileName + ".txt");
            while (!translateFile.EndOfStream)
            {
                translatesList.Add(translateFile.ReadLine());
            }
            if (translateOnStart)
            {
                Translate();
            }
        }

        public void Translate()
        {
            textObject.text = translatesList[translateNumber];
        }
    }
}