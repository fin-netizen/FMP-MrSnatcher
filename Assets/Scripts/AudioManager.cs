using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.VFX;
public class AudioManager : MonoBehaviour
{
    public AudioSystem[] sounds;
    public static AudioManager instance;
    public float musicVol;
    public float sfxVol;
    public AudioMixer mixer;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (AudioSystem s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }
    public void Play(string name, float vol)
    {
        AudioSystem s = Array.Find(sounds, AudioSystem => AudioSystem.name == name);
        s.source.Play();
        s.source.volume = vol;
    }
    
    public void ChangeAudioSourceVolume(string name, float vol)
    {
        AudioSystem s = Array.Find(sounds, AudioSystem => AudioSystem.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not found!");
            return;
        }
        s.source.volume = vol;


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("Music") == true)
        {
            AudioManager.instance.musicVol = PlayerPrefs.GetFloat("Music");
        }
        if (PlayerPrefs.HasKey("Sfx") == true)
        {
            AudioManager.instance.sfxVol = PlayerPrefs.GetFloat("Sfx");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
