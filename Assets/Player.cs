using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] bool isGrounded;
    [SerializeField] float jumpForce;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;

    [SerializeField] Transform leftFoot, rightFoot;
    [SerializeField] LayerMask mask;

    public Animator animator;
    private SpriteRenderer mySprite;

    float moveDirection, jumpTimer;
    bool isPressingJump;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	animator = GetComponent<Animator>();
	mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
	
        moveDirection = Input.GetAxisRaw("Horizontal");
	if (moveDirection != 0) {
	 //Debug.Log(moveDirection);
	 animator.SetBool("running", true);
	  if (moveDirection > 0) {
		mySprite.flipX = false;
	  } else {
	   	mySprite.flipX = true;
	  }
	}else {
	 //Debug.Log("stopped");
	 animator.SetBool("running", false);	
	}
	
	
	
        isPressingJump = isPressingJump || Input.GetKey(KeyCode.Space);

        jumpTimer += Time.deltaTime;
	
	    

        //ground check
        RaycastHit2D hitLeft = Physics2D.Raycast(leftFoot.position, Vector2.down, 0.05f, mask);
        Debug.DrawRay(leftFoot.position, Vector2.down * 0.1f, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(rightFoot.position, Vector2.down, 0.05f, mask);
        Debug.DrawRay(rightFoot.position, Vector2.down * 0.1f, Color.red);
        isGrounded = hitLeft.collider != null || hitRight.collider != null;

	 Debug.Log(isGrounded);
	if (isGrounded) {
	 Debug.Log("set false");
	 animator.SetBool("jumping", false);
	}else {
	 Debug.Log("set true");
	 animator.SetBool("jumping", true);
	}    
    }

    private void FixedUpdate()
    {
        if(isPressingJump)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpTimer = 0;
            }
            isPressingJump = false;
        }

        Vector3 vel = rb.velocity;
        if (Mathf.Abs(moveDirection) < 0.1f) vel.x = 0;
        else
        {
            vel.x += acceleration * moveDirection;
            vel.x = Mathf.Clamp(vel.x, -maxSpeed, maxSpeed);
        }
        rb.velocity = vel;
    }
}
