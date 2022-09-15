using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCycle : MonoBehaviour
{
    [SerializeField] private List<Sprite> images;
    [SerializeField] private Image image;
    private int index = -1;
    

    private void Start()
    {
        NextImage();
    }


    public void NextImage()
    {
        if (index + 1 < images.Count)
        {
            index++;
            image.sprite = images[index];
        }
    }

    public void PreviousImage()
    {
        if (index - 1 >= 0)
        {
            index--;
            image.sprite = images[index];
        }
    }
}
