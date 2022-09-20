using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for the actions of the button shown in the book
/// </summary>
public class CloseBookButton : MonoBehaviour
{
    [SerializeField] private GameObject masterParent;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        masterParent.SetActive(false);
    }
}
