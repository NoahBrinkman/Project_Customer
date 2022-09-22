using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalDialogueManager : MonoBehaviour
{
    [SerializeField, TextArea] private List<string> dialogueByScore;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("End");
        int amountCorrect = SelectionPasser.Instance.AmountCorrect();
        if (amountCorrect >= 0 && amountCorrect < dialogueByScore.Count)
        {
            text.text = dialogueByScore[amountCorrect];
        }
    }
}
