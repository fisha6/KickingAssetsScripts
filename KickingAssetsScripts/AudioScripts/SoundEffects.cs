using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private float effectsVolume;

    static AudioSource _effectSource1, _effectSource2;
    public static AudioClip jumpImpact, bodyFall, lockerSound, elevatorSound, detectedSound, gameOver;



    private void Start()
    {
        //Creation Of Player's Primary Sound Effect AudioSourceComponent.
        _effectSource1 = gameObject.AddComponent<AudioSource>();
        _effectSource1.playOnAwake = false;
        _effectSource1.loop = false;
        _effectSource1.spatialBlend = 0;
        _effectSource1.volume = effectsVolume;

        //Creation Of Player's Secondary Sound Effect AudioSourceComponent.
        _effectSource2 = gameObject.AddComponent<AudioSource>();
        _effectSource2.playOnAwake = false;
        _effectSource2.loop = false;
        _effectSource2.spatialBlend = 0;
        _effectSource2.volume = effectsVolume / 5;

        //Audio Clips
        jumpImpact = Resources.Load<AudioClip>("Audio/SFX/FallImpactSound");
        bodyFall = Resources.Load<AudioClip>("Audio/SFX/JumpLand");
        lockerSound = Resources.Load<AudioClip>("Audio/SFX/LockerShut");
        elevatorSound = Resources.Load<AudioClip>("Audio/SFX/ElevatorSound");
        detectedSound = Resources.Load<AudioClip>("Audio/SFX/EnemyDetected");
        gameOver = Resources.Load<AudioClip>("Audio/SFX/GameOver");
    }

    //The Function That Handles Playing All Sound Effects.
    public static void PlaySoundEffect(string sound)
    {
        switch (sound)
        {
            case "JumpImpact":
                 _effectSource1.PlayOneShot(jumpImpact);
                break;
            case "BodyFall":
                _effectSource1.PlayOneShot(bodyFall);
                break;
            case "LockerSound":
                _effectSource1.PlayOneShot(lockerSound);
                break;
            case "ElevatorSound":
                _effectSource1.PlayOneShot(elevatorSound);
                break;
            case "GameOver":
                _effectSource1.PlayOneShot(gameOver);
                break;
            case "EnemyDetected":
                _effectSource2.PlayOneShot(detectedSound);
                break;
        }
    }

    public static void StopSounds()
    {
        _effectSource1.Stop();
        _effectSource2.Stop();
    }
}
