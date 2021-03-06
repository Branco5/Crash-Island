using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;
    
	public AudioMixerGroup mixerGroup;


    void Awake()
    {
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}


        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
        }
    }


    void Start() {
        Play("Theme");
    }
   public void Play(string name){
       Sound s  = Array.Find(sounds, sound => sound.name == name);
       if(s == null){
           Debug.Log("Sound" + name + "not found!");
           return;
       }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
       s.source.Play();
   }
}
