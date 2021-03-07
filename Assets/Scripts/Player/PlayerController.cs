using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    public int woodCount;
    float mouseStart;
    public float deadZone = 0.1f;
    public float horizontalSpeed;
    public float jumpSpeed = 10f;
    Vector3 movementDelta;
    Vector3 turnRotation;
    Vector3 movePoint = Vector3.zero;
    private Rigidbody rb;

    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!GameManager.isStarted)
            return;

    }

    private void FixedUpdate()
    {
        if (!GameManager.isStarted)
            return;
        movementDelta = Vector3.forward * speed;
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            turnRotation = new Vector3(movePoint.x, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(turnRotation - transform.position), turnspeed * Time.deltaTime);
            float delta = Input.mousePosition.x - mouseStart;
            mouseStart = Input.mousePosition.x;
            if (Mathf.Abs(delta) <= deadZone)
            {
                delta = 0;
            }
            else
            {
                delta = Mathf.Sign(delta);
            }
            movementDelta += Vector3.right * horizontalSpeed * delta;
        }
        Move();
        if (tag == "zıplama rampası")
        {
            Jump();
        }
    }

    void Move()
    {
        rb.MovePosition(rb.position + movementDelta * Time.deltaTime);
    }

    void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
}
