using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Moving setup")]
    public float speed;
    public float speedRun;
    private float _currentSpeed;
    public Vector2 friction = new Vector2(.1f, 0);
    public float forceJump = 15f;

    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

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
            rb.transform.localScale = Vector2.one;
            DOTween.Kill(rb.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()  
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
