using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAttack : MonoBehaviour
{
    public GameObject yellowAttack;
    [HideInInspector] public GameObject player;
    [HideInInspector] public string otherPlayer;
    GameObject attack;
    

    // Start is called before the first frame update
    void Start()
    {
        attack = Instantiate(yellowAttack, transform.position, Quaternion.identity);
        for (int i = 0; i < attack.transform.childCount; i++)
        {
            attack.transform.GetChild(i).GetComponent<SpinHit>().player = gameObject;
            attack.transform.GetChild(i).GetComponent<SpinHit>().otherPlayerTag = otherPlayer;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        attack.transform.position = transform.position;
        for (int i = 0;i < attack.transform.childCount; i++)
        {
            attack.transform.GetChild(i).GetComponent<SpinHit>().SpinUpdate();
        }

    }
}
