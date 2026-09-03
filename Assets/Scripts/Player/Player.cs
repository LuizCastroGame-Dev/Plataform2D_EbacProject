using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 velocity;

    public float speed;

    //private void Start()
    //{
    //    if (rb == null) rb = GetComponent<Rigidbody2D>();
    //}

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            //rb.MovePosition(rb.position - velocity * Time.deltaTime);
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //rb.MovePosition(rb.position + velocity * Time.deltaTime);
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
    }
}
