using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private float musicVolume;

    static AudioSource _musicSource;

    public static AudioClip bgMusic;

    void Start()
    {
        //Creation Of The Menu's AudioSourceComponent.
        _musicSource = gameObject.AddComponent<AudioSource>();
        _musicSource.playOnAwake = true;
        _musicSource.loop = true;
        _musicSource.spatialBlend = 0;
        _musicSource.volume = musicVolume;

        //Choosing a track and playing.
        _musicSource.clip = Resources.Load<AudioClip>("Audio/Background/MenuMusic");
        _musicSource.Play();
    }
}
