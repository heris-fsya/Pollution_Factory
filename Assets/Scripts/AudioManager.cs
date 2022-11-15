using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audio_src1;
    public AudioClip clip;
    public Sound[] sounds;
    [SerializeField] Slider volumeSlider, SFXslider;

    public void Awake()
    {
        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void PlaySoundButton1()
    {
        audio_src1.Play();
    }

    // ========= Partie Slider volume ======== //

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
       
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
  
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
      
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    
    }
    // ==================================== //
    // partie sounds effect




}
