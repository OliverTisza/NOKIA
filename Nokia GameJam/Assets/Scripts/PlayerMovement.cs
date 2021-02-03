using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public int jumpForce;
    bool isJumping = false;

    public Rigidbody2D rb2D;

    void Start()
    {
        
    }

    void Update()
    {
        
        gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        if(Input.GetAxis("Horizontal") < 1.0f)
        {
            //gameObject.transform.position += new Vector3(0, 0, 0);
            
        }

        if (gameObject.GetComponent<Rigidbody2D>() && Input.GetAxis("Vertical") > 0.0f && !isJumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag.Equals(gameObject.tag) || collision.gameObject.tag.Equals("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Ground") { }
        else if (collision.gameObject.tag != gameObject.tag)
        {       
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        

    }


}
