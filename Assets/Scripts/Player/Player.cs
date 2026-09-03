using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;

    public float forceJump = 15f;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //rb.MovePosition(rb.position - velocity * Time.deltaTime);
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }

        if(rb.linearVelocity.x > 0)
        {
            rb.linearVelocity += friction;
        }
        else if (rb.linearVelocity.x < 0)
        {
            rb.linearVelocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * forceJump;
        }
    }
}
