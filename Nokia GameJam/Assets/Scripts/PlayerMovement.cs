using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public int jumpForce;
    bool isJumping = false;
    public bool isFinished = false;
    public string oppositeTag;

    public Rigidbody2D rb2D;

    private float xInput;

    void Update()
    {
        //gameObject.transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        // We set the velocity of rigidbody instead of handle directly the player's transform position.
        // This resolves the strange stuff where players try to push the wall
        xInput = Input.GetAxisRaw("Horizontal");
        if (xInput == 0)
            rb2D.velocity = new Vector2(0f, rb2D.velocity.y);

        if (gameObject.GetComponent<Rigidbody2D>() && Input.GetAxis("Vertical") > 0.0f && !isJumping && rb2D.velocity.y <=0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }

    }

    private void FixedUpdate()
    {
        // In general we handle physics in FixedUpdate
        rb2D.velocity = new Vector2(xInput * moveSpeed, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Equals(gameObject.tag) && collision.gameObject.GetComponentInParent<Transform>().rotation.eulerAngles.z != 90 || collision.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals(oppositeTag))
        {       
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "Goal")
        {
            isFinished = true;
        }

        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            isFinished = false;
        }
    }

}
