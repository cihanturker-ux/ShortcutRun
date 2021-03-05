using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int woodCount;
    float mouseStart;
    public float deadZone = 0.1f;
    public float horizontalSpeed;
    Vector3 movementDelta;
    private Rigidbody rb;

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
    }

    void Move()
    {
        rb.MovePosition(rb.position + movementDelta * Time.deltaTime);
    }
}
