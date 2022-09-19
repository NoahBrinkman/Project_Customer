using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCycle : MonoBehaviour
{
    [SerializeField,TextArea] private List<string> texts;
    [SerializeField] private TMP_Text textBox;
    private int index = -1;
    

    private void Start()
    {
        NextString();
    }


    public void NextString()
    {
        if (index + 1 < texts.Count)
        {
            index++;
            textBox.text = texts[index];
        }
    }

    public void PreviousString()
    {
        if (index - 1 >= 0)
        {
            index--;
            textBox.text = texts[index];
        }
    }

}
