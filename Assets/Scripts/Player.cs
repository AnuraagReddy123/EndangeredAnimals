using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject playerUI;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private AudioSource footsteps;// object for playing the audio sound of footsteps
    // Start is called before the first frame update
    void Start()
    {
        footsteps = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Movement left and right
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(-0.5f, 0.5f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(0.5f, 0.5f);

        // Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        // Setting animation parameters
        anim.SetBool("walk", horizontalInput != 0);
        // Debug.Log("value of isGrounded" + isGrounded());

        if(end.transform.position.x - transform.position.x <= 0)
        {
            playerUI.SetActive(false);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void Jump()
    {
        
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.CompareTag("Collider"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }


    // Make footstep noise when player is on the ground
    public void Footstep()
    {
        if (isGrounded())
        {
            footsteps.Play();// PLay the sound
        }
    }
}
