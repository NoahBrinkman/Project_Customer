using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySound("Confirm");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
