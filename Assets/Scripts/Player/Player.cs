using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    public float speedRun;
    private float _currentSpeed;

    public Vector2 friction = new Vector2(.1f, 0);

    public float forceJump = 15f;

    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        //Movimentação de corrida
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        //Movimentação do personagem
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-_currentSpeed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(_currentSpeed, rb.linearVelocity.y);
        }

        //Aplicação da fricção no jogo
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
        //Pulo do personagem
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * forceJump;
        }
    }
}
