using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject hitBox;
    public Transform hitboxSpawn;
    public float timeBetweenHit;
    float timer;
    public KeyCode attackKey;
    public string otherPlayerTag;
    public float attackDmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }


        if(timer <= 0)
        {
            if (Input.GetKeyDown(attackKey))
            {
                GameObject hb = Instantiate(hitBox, hitboxSpawn.position, Quaternion.identity);
                hb.GetComponent<Hitbox>().tagToCompare = otherPlayerTag;
                hb.GetComponent<Hitbox>().damage = attackDmg;
                hb.GetComponent<Hitbox>().player = transform;
                hb.transform.SetParent(transform);
                Destroy(hb, 0.2f);
                timer = timeBetweenHit;
            }
        }

    }


}
