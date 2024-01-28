using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public AudioClip bounce;
    public AudioClip jump;
    public AudioClip parry;
    public AudioClip shield;

    public AudioSource source;

    public void PlayBonce()
    {
        AudioSource.PlayClipAtPoint(bounce, Camera.main.transform.position);
    }

    public void PlayJump()
    {
        AudioSource.PlayClipAtPoint(jump, Camera.main.transform.position);
    }

    public void PlayParry()
    {
        AudioSource.PlayClipAtPoint(parry, Camera.main.transform.position);
    }

    public void PlayShield()
    {
        source.Play();
    }

    public void StopShield()
    {
        source.Stop();
    }
}
