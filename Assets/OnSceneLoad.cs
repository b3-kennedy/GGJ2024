using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
