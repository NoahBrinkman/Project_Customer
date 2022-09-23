using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void OnEnable()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        Destroy(gameObject, clip.length);
    }
    
    private void OnComplete()
    {
        
    }
}
