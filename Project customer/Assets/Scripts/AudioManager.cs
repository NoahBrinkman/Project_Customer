using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    [SerializeField] private List<NamedSound> sounds = new List<NamedSound>();
    [SerializeField] private List<NamedSound> musics = new List<NamedSound>();
    public static AudioManager Instance { get; private set; }
    private AudioSource source;
    [SerializeField] private GameObject audioPlayerPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(this);
        }

        source = GetComponent<AudioSource>();

    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (sounds[i].name == name)
            {
                //source.clip = sounds[i].clip;
                //source.Play();
                GameObject g = GameObject.Instantiate(audioPlayerPrefab, transform);
                g.GetComponent<AudioPlayer>().Play(sounds[i].clip);
                
                //AudioSource
            }
        }
    }
    public void PlayMusic(string name)
    {
        for (int i = 0; i < musics.Count; i++)
        {
            if (musics[i].name == name)
            {
                if(source.clip == musics[i].clip) return;
                source.Stop();
                source.loop = true;
                source.clip = musics[i].clip;
                source.Play();
                //AudioSource
            }
        }
    }
}



[Serializable]
public class NamedSound
{
    public string name;
    public AudioClip clip;
}
