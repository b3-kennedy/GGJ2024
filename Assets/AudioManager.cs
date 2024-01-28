using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip takeDamage;
    public AudioClip squareBounce;
    public AudioClip yellowAttackHit;
    public AudioClip projectileHit;
    public AudioClip projectileParry;

    private void Awake()
    {
        Instance = this;
    }

}
