using System;
using System.Threading.Tasks;
using UnityEngine;

public class hunterMovement : MonoBehaviour
{
    private Rigidbody2D hunter;
    private BoxCollider2D hunterBoxCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask platformLayer;
    private Animator anim;
    [SerializeField] private float speed;       // Speed of hunter
    [SerializeField] private float minDistance;  // if player comes closer to hunter beyond this distance, then the hunter will kill player.


    // Start is called before the first frame update
    void Start()
    {
        hunter = GetComponent<Rigidbody2D>();
        hunterBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        Physics.IgnoreLayerCollision(7, 7);  // To ignore collisions between hunters.
    }

    // To check if the hunter is on ground or not
    public bool isGrounded()
    {
        float extraHeight = 0.5f;
        Vector3 v = new Vector3(hunterBoxCollider.bounds.center.x + (speed / (Math.Abs(speed)))*0.3f, hunterBoxCollider.bounds.center.y, hunterBoxCollider.bounds.center.z);
        RaycastHit2D rayCastHit = Physics2D.Raycast(v, Vector2.down, hunterBoxCollider.bounds.extents.y + extraHeight, platformLayer);
        return rayCastHit.collider != null;
    }

    // To check if wall is present in front of hunter, so that he can change direction
    public bool haveWallInFront()
    {
        //Debug.Log("wall");
        float extraHeight = 0.1f;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(hunterBoxCollider.bounds.center, hunterBoxCollider.bounds.size, 0f, Vector2.right * (speed / (Math.Abs(speed))), extraHeight, platformLayer);
        return rayCastHit.collider != null;
    }

    // Update is called once per frame
    async public void Update()
    {
        if (!isGrounded() || haveWallInFront())
        {
            //Debug.Log("if : " + speed);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed *= -1;
            transform.position = new Vector3(transform.position.x + (speed / (Math.Abs(speed))) * (0.1f), transform.position.y, transform.position.z);
        }

        hunter.velocity = new Vector2(speed, 0);
        //Debug.Log(speed);
        /*if (Math.Abs(transform.position.x - player.transform.position.x) <= minDistance && Math.Abs(transform.position.y - player.transform.position.y) <= 0.2f && (transform.position.x - player.transform.position.x) * (hunter.velocity.x) < 0)
        {
            Debug.Log("turning");
            anim.SetBool("attack", true);
            Vector2 v = hunter.velocity;
            hunter.velocity = new Vector2(0, 0);
            await Task.Delay(500);
            player.SetActive(false);
            player.transform.position = new Vector3(-100, 0, 0);
            hunter.velocity = new Vector2(v[0], v[1]);
            anim.SetBool("attack", false);
        }*/

    }

}
