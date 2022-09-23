using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCycle : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    private int index = -1;
    

    private void Start()
    {
        NextImage();
    }


    public void NextImage()
    {
        if (index + 1 < images.Count)
        {
            images[index].enabled = false;
            index++;
            images[index].enabled = true;
        }
    }

    public void PreviousImage()
    {
        if (index - 1 >= 0)
        {
            images[index].enabled = false;
            index--;
            images[index].enabled = true;
        }
    }
}
