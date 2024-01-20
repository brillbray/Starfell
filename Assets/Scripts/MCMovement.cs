using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MCMovement : MonoBehaviour
{
    public float movSpeed = 7f;
    public Rigidbody2D charbody;
    private Vector2 velocity;
    private Vector2 InputMovement;
    public bool isMovementEnabled = true;
    void Start()
    {
        velocity = new Vector2(movSpeed, movSpeed);
        charbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMovementEnabled)
        {
            InputMovement = new Vector2(Input.GetAxisRaw("Horizontal"),
                                        Input.GetAxisRaw("Vertical"));
        }
    }

    void FixedUpdate()
    {
        Vector2 delta = InputMovement * velocity * Time.fixedDeltaTime;
        Vector2 newPos = charbody.position + delta;
        charbody.position = newPos;
    }

    public void SetMovementEnabled(bool enable)
    {
        isMovementEnabled = enable;
    }
}