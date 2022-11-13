using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;

    public Sound[] sounds;

    void Awake()
    {
        // Create AudioSource Components
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        if (GameObject.Find("Audio Manager") != null)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Play sound by name
    public void Play(string name)
    {
        Array.Find(sounds, sound => sound.name == name).source.Play();
    }

    // Play sound by name with random pitch
    public void PlayPitchRandom(string name,
        float minPitch = 0.7f, float maxPitch = 1.3f)
    {
        AudioSource s = Array.Find(sounds, sound => sound.name == name).source;
        s.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        s.Play();
    }

    // Play sounds from group randomly with random pitch
    public void PlayGroupRandomPitch(string group,
        float minPitch = 0.8f, float maxPitch = 1.2f)
    {
        var g = Array.FindAll(sounds, sound => sound.group == group);
        int index = UnityEngine.Random.Range(0, g.Length);
        g[index].source.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        g[index].source.Play();
    }
}
