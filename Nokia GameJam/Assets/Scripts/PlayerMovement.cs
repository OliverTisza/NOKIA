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

    void Start()
    {
        
    }

    void Update()
    {
       
        gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetAxis("Horizontal") < 1.0f)
        {
            //TODO: Instant Stop?
            
        }

        if (gameObject.GetComponent<Rigidbody2D>() && Input.GetAxis("Vertical") > 0.0f && !isJumping && rb2D.velocity.y <=0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {


        Debug.Log(collision.gameObject.GetComponentInParent<Transform>().rotation.eulerAngles.z);

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

        Debug.Log(collision.tag);
        if (collision.gameObject.tag == "Goal")
        {
            isFinished = false;
        }

        
    }

}
