using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public int jumpForce;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        if(Input.GetAxis("Horizontal") < 1.0f)
        {
            gameObject.transform.position += new Vector3(0, 0, 0);
        }
        
        
        if (gameObject.GetComponent<Rigidbody2D>() && Input.GetAxis("Vertical") > 0.0f && !jumping)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            jumping = true;
        }
        
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Untagged")
        {

        }
        else if (collision.gameObject.tag != gameObject.tag)
        {
            
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
