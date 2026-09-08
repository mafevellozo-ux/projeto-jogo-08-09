using UnityEngine;
using UnityEngine.InputSystem;


public class controlplayer : MonoBehaviour
{
    private float speed = 5f;
    private float jumpforce = 5f;
    private Vector2 moveinput;
    private bool isJumping;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        moveinput = value.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        isJumping = value.isPressed;
        if (isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveinput.x*speed, rb.linearVelocity.y);
    }
}
