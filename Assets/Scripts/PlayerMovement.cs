using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float jumpForce = 28f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpableSoundEffect;
    public bool reverse = false;
    public bool reverseRun = false;

    private enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        Debug.Log("Start");
    }

    // Update is called once per frame
   private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (reverseRun)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
      

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        //MovementState state;
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (reverse)
        {
            if (verticalMovement < 0f && isGroundedUp())
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
                //jumpableSoundEffect.Play();
            }
        }
        else
        {
            if (verticalMovement > 0.5f && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                //jumpableSoundEffect.Play();
            }
        }
        

        //if (dirX > 0f)
        //{
        //    state = MovementState.running;
        //    sprite.flipX = false;
        //}
        //else if (dirX < 0f)
        //{
        //    state = MovementState.running;
        //    sprite.flipX = true;
        //}
        //else
        //{
        //    state = MovementState.idle;
        //}

        //if (rb.velocity.y > 0.1f)
        //{
        //    state = MovementState.jumping;
        //}
        //else if (rb.velocity.y < - 0.1f)
        //{
        //    state = MovementState.falling;
        //}
        //anim.SetInteger("state", (int)state);
    }

    private bool isGrounded() {
     return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool isGroundedUp()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.up, .1f, jumpableGround);
    }

}
