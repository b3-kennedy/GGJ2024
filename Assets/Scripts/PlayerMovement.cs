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
    public LayerMask mask;

    float acceleration;

    public string axisName;
    public KeyCode jumpKey;

    float xSpeed;

    public bool hitStun;

    public PhysicsMaterial2D bounceMat;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalSpeed = speed;
        //bounceMat.bounciness = 0;

    }

    void OnLand()
    {

        xSpeed = 0;

    }

    void CheckIfLanded()
    {
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
    }

    void CancelHitstun()
    {
        if (hitStun)
        {
            rb.sharedMaterial = bounceMat;
            //bounceMat.bounciness = GetComponent<Health>().health / 100;


            if (rb.velocity.magnitude < 5f)
            {
                rb.sharedMaterial = null;
                hitStun = false;
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            if (hitStun)
            {
                //rb.sharedMaterial.bounciness /= 2;
                rb.velocity /= 2;

            }
        }
    }



    // Update is called once per frame
    void Update()
    {

        CancelHitstun();

        if (!hitStun)
        {
            horizontal = Input.GetAxis(axisName);
        }
        

        if (horizontal != 0)
        {
            acceleration += baseAcceleration + (speed * Time.deltaTime);
        }
        else
        {
            acceleration = 0;
        }

        if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        acceleration = Mathf.Clamp(acceleration, 0, 10);

        xSpeed = horizontal * acceleration;


        if (!grounded)
        {
            acceleration = airDrag;
        }
        else
        {

            acceleration = normalSpeed;
        }

        CheckIfLanded();

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
        if (!hitStun)
        {
            rb.velocity = moveVec;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(groundCheck.position, -Vector2.up * 0.2f);
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.2f, mask);



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
