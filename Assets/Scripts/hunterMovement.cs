using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class hunterMovement : MonoBehaviour
{
    public Rigidbody2D hunter;
    public BoxCollider2D hunterBoxCollider;
    public GameObject ground;
    public GameObject player;
    public Collision2D coll;
    public LayerMask platformLayer;
    public Animator anim;
    public float initialX;
    public int direction;
    public int distance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        hunter = GetComponent<Rigidbody2D>();
        hunterBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        initialX = transform.position.x;
        direction = 1;
        distance = 5;
        speed = -5;
    }

    public bool isGrounded()
    {
        float extraHeight = 1f;
        Vector3 v = new Vector3(hunterBoxCollider.bounds.center.x + (speed / (Math.Abs(speed))) * 1, hunterBoxCollider.bounds.center.y, hunterBoxCollider.bounds.center.z);
        RaycastHit2D rayCastHit = Physics2D.Raycast(v, Vector2.down, hunterBoxCollider.bounds.extents.y + extraHeight, platformLayer);
        return rayCastHit.collider != null;
    }

    public bool haveWallInFront()
    {
        //Debug.Log("wall");
        float extraHeight = 0.1f;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(hunterBoxCollider.bounds.center, hunterBoxCollider.bounds.size, 0f, Vector2.right * (speed / (Math.Abs(speed))), extraHeight, platformLayer);
        return rayCastHit.collider != null;
    }

    // Update is called once per frame
    async void FixedUpdate()
    {
        if (!isGrounded() || haveWallInFront())
        {
            Debug.Log("if");
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed *= -1;
            transform.position = new Vector3(transform.position.x + (speed / (Math.Abs(speed))) * (0.1f), transform.position.y, transform.position.z);
        }

        hunter.velocity = new Vector2(speed, 0);

        if (Math.Abs(transform.position.x - player.transform.position.x) <= 3f && (transform.position.x - player.transform.position.x) * (hunter.velocity.x) < 0)
        {
            Debug.Log("Yes");
            anim.SetBool("attack", true);
            Vector2 v = hunter.velocity;
            hunter.velocity = new Vector2(0, 0);
            await Task.Delay(500);
            player.SetActive(false);
            player.transform.position = new Vector3(-100, 0, 0);
            hunter.velocity = new Vector2(v[0], v[1]);
            anim.SetBool("attack", false);
        }

    }

}
