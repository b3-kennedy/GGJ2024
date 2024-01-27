using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaDamage : PowerUp
{
    float oldAttackDamage;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Attack>())
        {
            oldAttackDamage = GetComponent<Attack>().attackDmg;
            float newAttackValue = GetComponent<Attack>().attackDmg * 5;
            GetComponent<Attack>().attackDmg = newAttackValue;

            Destroy(this, 3);

        }
    }

    private void OnDestroy()
    {
        if (GetComponent<Attack>())
        {
            GetComponent<Attack>().attackDmg = oldAttackDamage;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
