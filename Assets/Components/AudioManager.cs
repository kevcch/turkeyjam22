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
        AudioManager[] instances = GameObject.FindObjectsOfType<AudioManager>();
        if (instances.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            am = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Play("music");
    }

    // Play sound by name
    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found");
        }


        Debug.Log("PlayOneShot: " + s.source.clip);
        s.source.Play();
    }

    // Play sound by name with random pitch
    public void PlayPitchRandom(string name,
        float minPitch = 0.7f, float maxPitch = 1.3f)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found");
        }
        s.source.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        s.source.Play();
    }

    // Play sounds from group randomly with random pitch
    public void PlayGroupRandomPitch(string group,
        float minPitch = 0.8f, float maxPitch = 1.2f)
    {
        var g = Array.FindAll(sounds, sound => sound.group == group);
        if (g == null)
        {
            Debug.Log("Group " + group + " not found");
        }
        int index = UnityEngine.Random.Range(0, g.Length);
        g[index].source.pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        g[index].source.Play();
    }
}
