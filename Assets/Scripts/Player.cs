using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using System.Linq;

public class Player : MonoBehaviour
{

    static List<int> ids = new List<int>();

    public bool allowInput = false;
    [SerializeField] bool isGrounded;
    [SerializeField] float jumpForce;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;

    [SerializeField] Transform leftFoot, rightFoot;
    [SerializeField] LayerMask mask;

    public Animator animator;
    private SpriteRenderer sr;

    [SerializeField] bool isPlayer1;

    float moveDirection;
    bool isPressingJump;
    bool acJump;
    float acDirection;
    bool isInvulnerable;



    [SerializeField] bool isACInput;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	    animator = GetComponent<Animator>();
	    sr = GetComponent<SpriteRenderer>();
    }

    public void FeedACInput(bool acJump, float acDirection)
    {
        this.acJump = acJump;
        this.acDirection = acDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //ground check
        RaycastHit2D hitLeft = Physics2D.Raycast(leftFoot.position, Vector2.down, 0.05f, mask);
        RaycastHit2D hitRight = Physics2D.Raycast(rightFoot.position, Vector2.down, 0.05f, mask);
        //Debug.DrawRay(leftFoot.position, Vector2.down * 0.1f, Color.red);
        //Debug.DrawRay(rightFoot.position, Vector2.down * 0.1f, Color.red);
        isGrounded = hitLeft.collider != null || hitRight.collider != null;
        animator.SetBool("jumping", !isGrounded);

        if (!allowInput)
        {
            moveDirection = 0;
            animator.SetBool("running", Mathf.Abs(moveDirection) > 0.01f);
            return;
        }

        moveDirection = (isACInput ? acDirection : Input.GetAxisRaw("Horizontal"));
        animator.SetBool("running", Mathf.Abs(moveDirection) > 0.01f);
        isPressingJump = isPressingJump || (isACInput ? acJump : Input.GetKey(KeyCode.Space));
        if (moveDirection < -0.1) sr.flipX = true;
        if (moveDirection > 0.1) sr.flipX = false;

        
    }

    private void FixedUpdate()
    {
        if (isPressingJump)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            isPressingJump = false;
        }

        Vector3 vel = rb.velocity;
        if (Mathf.Abs(moveDirection) < 0.1f) vel.x = 0;
        else vel.x = Mathf.Clamp(vel.x + acceleration * moveDirection, -maxSpeed, maxSpeed);
        rb.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            if(!isInvulnerable) StartCoroutine(Stun());
        }
    }

    IEnumerator Stun()
    {
        Invulnerable(4);
        allowInput = false;
        animator.SetBool("stun", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("stun", false);
        allowInput = true;
    }

    public void Invulnerable(float time) => StartCoroutine(InvulnerableRoutine(time));
    IEnumerator InvulnerableRoutine(float time)
    {
        isInvulnerable = true;
        float startTime = Time.time;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        while (Time.time - startTime < time)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sr.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Player");
        isInvulnerable = false;
    }

    public void TakeDamage()
    {
        if (!isInvulnerable) StartCoroutine(Stun());
    }
}
