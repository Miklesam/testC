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

    public bool isSliding = false;

    private void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        if (verticalMovement < 0f)
        {
            performSlide();
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

}


