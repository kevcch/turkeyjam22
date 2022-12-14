using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public string group;
    [HideInInspector] public AudioSource source;
    public AudioClip clip;
    [Range(0, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;

    public Sound(string group, string name, AudioClip clip, float volume,
        float pitch, bool loop)
    {
        this.group = group;
        this.name = name;
        this.clip = clip;
        this.volume = volume;
        this.pitch = pitch;
        this.loop = loop;
    }

}
