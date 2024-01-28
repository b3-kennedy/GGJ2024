using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShakeManager : MonoBehaviour
{
   public static CamShakeManager instance;

   // public float globlaShakeForce = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void cameraShake(CinemachineImpulseSource impulseSource,float shakeForce)
    {
        impulseSource.GenerateImpulseWithForce(shakeForce);
    }
}
