using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThrough : MonoBehaviour
{
    public bool onPlatform;
    GameObject otherPlatform;
    public KeyCode fallKey;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            otherPlatform = other.gameObject;
            onPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform") && otherPlatform != null)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), otherPlatform.transform.parent.GetComponent<Collider2D>(), false);
            otherPlatform = null;
            onPlatform = false;
        }
    }

    private void Update()
    {
        if (onPlatform && otherPlatform != null)
        {
            if (Input.GetKeyDown(fallKey))
            {
                Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), otherPlatform.transform.parent.GetComponent<Collider2D>(), true);
            }
        }
    }
}
