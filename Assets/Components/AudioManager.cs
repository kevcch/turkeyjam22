using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;

    public Sound[] sounds;
    private bool cutscene0Change = false;
    private bool cutscene2Change = false;
    private bool cutscene4Change = false;

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
        //Play("happyMusic");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "CutScene2" && !cutscene2Change)
        {
            cutscene2Change = true;
            Stop("happyMusic");
            Play("sadMusic");
        }
        if (SceneManager.GetActiveScene().name == "CutScene4" && !cutscene4Change)
        {
            cutscene4Change = true;
            cutscene2Change = false;
            cutscene0Change = false;
            Stop("sadMusic");
            Play("deathWind");

        }
        if (SceneManager.GetActiveScene().name == "Cutscene0" && !cutscene0Change)
        {
            cutscene0Change = true;
            Play("happyMusic");
            Stop("deathWind");
        }
    }

    // Play sound by name
    public void Play(string name)
    {
        Sound s = FindSound(name);
        Debug.Log("Play: " + name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = FindSound(name);
        if (s.source.isPlaying)
        {
            Debug.Log("Stop " + name);
            s.source.Stop();
        }
    }

    private Sound FindSound(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found");
        }
        return s;
    }


    // Play sound by name with random pitch
    public void PlayPitchRandom(string name,
        float minPitch = 0.7f, float maxPitch = 1.3f)
    {
        Sound s = FindSound(name);
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

    public void PlayWithNewVolume(string name, float volume = 1f)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found");
        }
        s.source.volume = volume;
        s.source.Play();
    }

}
