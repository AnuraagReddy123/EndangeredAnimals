using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Movement left and right
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(-1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = Vector2.one;

        // Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            Jump();

        // Setting animation parameters
        anim.SetBool("walk", horizontalInput != 0);
    }

    private void Jump()
    {
        isGrounded = false;
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
