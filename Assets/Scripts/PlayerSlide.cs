using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public PlayerMovement PL;
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D regullarColl;
    public BoxCollider2D slideCollider;
    public float slideSpeed = 5f;
    [SerializeField] private LayerMask jumpableGround;

    public bool isSliding = false;
    public bool reverse = false;
    private void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        if (reverse)
        {
            if (verticalMovement > 0.5f && isGroundedUp())
            {
                performSlide();
            }
        }
        else
        {
            if (verticalMovement < 0f && isGrounded())
            {
                performSlide();
            }
        }
    }

    private void performSlide()
    {
        isSliding = true;
        anim.SetBool("isSlide", true);
        regullarColl.enabled = false;
        slideCollider.enabled = true;
        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("isSlide", false);
        regullarColl.enabled = true;
        slideCollider.enabled = false;
        isSliding = false;
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(regullarColl.bounds.center, regullarColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private bool isGroundedUp()
    {
        return Physics2D.BoxCast(regullarColl.bounds.center, regullarColl.bounds.size, 0f, Vector2.up, .1f, jumpableGround);
    }

}
