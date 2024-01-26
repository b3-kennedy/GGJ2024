using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float baseAcceleration;
    public float gravity = -9.81f;
    public float airDrag;
    public float jumpForce;
    public Transform groundCheck;
    public bool grounded;
    Vector2 moveVec;
    Rigidbody2D rb;
    float normalSpeed;
    float horizontal;
    bool airborn;

    float acceleration;

    public string axisName;
    public KeyCode jumpKey;

    float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalSpeed = speed;

    }

    void OnLand()
    {

        xSpeed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis(axisName);

        if (horizontal != 0)
        {
            acceleration += baseAcceleration + (speed * Time.deltaTime);
        }
        else
        {
            acceleration = 0;
        }

        acceleration = Mathf.Clamp(acceleration, 0, 10);

        xSpeed = horizontal * acceleration;


        if (!grounded)
        {
            if (!airborn)
            {
                airborn = !airborn;
            }
        }
        else
        {
            if (airborn)
            {
                OnLand();
                airborn = false;
            }
        }


        if (!grounded)
        {
            acceleration = airDrag;
        }
        else
        {

            acceleration = normalSpeed;
        }



        moveVec = new Vector2(xSpeed, rb.velocity.y);

        GroundCheck();
        //AirDrag();

        if (Input.GetKeyDown(jumpKey) && grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVec;
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, -transform.up, 0.2f);

        if (hit.collider)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void AirDrag()
    {
        if (!grounded)
        {
            rb.drag = airDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void Jump()
    {
        rb.velocity = rb.velocity + Vector2.up * jumpForce;
    }
}
