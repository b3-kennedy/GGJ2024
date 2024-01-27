using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    Vector3 nextPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNextPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, nextPos) <= 1f)
        {
            GenerateNextPos();
        }
        if(nextPos != null)
        {
            Vector2 dir = (nextPos - transform.position).normalized;
            transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
        }
        
    }

    void GenerateNextPos()
    {
        nextPos = new Vector3(Random.Range(GameManager.Instance.topLeft.x, GameManager.Instance.topRight.x),
    Random.Range(GameManager.Instance.topLeft.y, GameManager.Instance.bottomLeft.y),0);
    }
}
