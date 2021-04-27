using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement
{
    STOPPED,
    LEFT,
    RIGHT,
    JUMP
}


public class MovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float gravityScale = 2.5f;
    
    private Rigidbody2D rb;
    private Movement movement;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = Movement.STOPPED;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(movement == Movement.RIGHT)
        {
            rb.velocity = new Vector2(1 * movementSpeed, rb.velocity.y);
        }
        else if(movement == Movement.LEFT)
        {
            rb.velocity = new Vector2(-1 * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0 * movementSpeed, rb.velocity.y);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityScale - 1) * Time.deltaTime;
        }

    }

    public void Move(string direction)
    {
        switch(direction)
        {
            case "left":
                movement = Movement.LEFT;
                break;
            case "right":
                movement = Movement.RIGHT;
                break;
            case "stop":
                movement = Movement.STOPPED;
                break;
            case "jump":
                rb.velocity = Vector2.up * jumpVelocity;
                break;
        }
    }
}
