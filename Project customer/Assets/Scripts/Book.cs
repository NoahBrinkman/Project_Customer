using UnityEngine;

/// <summary>
/// Class responsible for the book behaviour
/// </summary>
public class Book : MonoBehaviour
{
    [SerializeField] private GameObject bookUI;
   
    public void OnClick()
    {
        bookUI.SetActive(!bookUI.activeSelf);
        GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
        AudioManager.Instance.PlaySound("OpenBook");
    }
    //Comment to get the unity back on track
}
