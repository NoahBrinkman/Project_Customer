using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Dialogue
{
    [Serializable]
    public class Dialogue
    {
        public TMP_Text text;
        public Image image;
        [SerializeField,TextArea] private string textSubstance;

        public void EnableText()
        {
            text.text = textSubstance;
            image.enabled = true;
            text.enabled = true;
        }

        public void DisableText()
        {
            text.text = String.Empty;
            image.enabled = false;
            text.enabled = false;
        }

        public string GetText()
        {
            return textSubstance;
        }
    }
}